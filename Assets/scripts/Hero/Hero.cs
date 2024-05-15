using System;
using UnityEngine;


public class Hero : MonoBehaviour
{
    [HideInInspector] public Rigidbody m_rigidbody;
    [SerializeField] private HeroData m_heroData;

    /// <summary>
    /// 当前状态
    /// </summary>
    public UnitState CurUnitState { get; protected set; } = UnitState.Idle;

    public Camp m_camp;

    public Hero m_attackTarget;

    public float m_hp = 5;
    public float MaxHp => m_heroData.m_maxHp;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_attackTarget && m_attackTarget.CurUnitState == UnitState.Die)
        {
            m_attackTarget = null;
        }

        switch (CurUnitState)
        {
            case UnitState.Idle:
                if (BattleManager.Instance.TryGetEnemy(this, out m_attackTarget))
                {
                    SetCurUnitState(UnitState.Move);
                }

                break;
            case UnitState.Move:
                if (m_attackTarget)
                {
                    MoveTo(m_attackTarget.transform.position);
                }

                break;
            case UnitState.BeatBack:
                if (m_rigidbody.velocity.magnitude < 0.05f)
                {
                    SetCurUnitState(UnitState.Idle);
                }

                break;
            case UnitState.Attack:
            case UnitState.Die:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void SetCurUnitState(UnitState newUnitState)
    {
        if (CurUnitState != UnitState.Die)
        {
            CurUnitState = newUnitState;
        }
    }

    void MoveTo(Vector3 newPosition)
    {
        var position = transform.position;
        Vector3 moveDir = (newPosition - position).normalized;
        //rigidbody.MovePosition(position + moveDir * (Time.deltaTime * 10));
        m_rigidbody.AddForce(moveDir * (Time.deltaTime * m_heroData.m_speed), ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Hero>(out var otherHero))
        {
            Debug.Log($"碰撞了：{otherHero.name} normal:{other.GetContact(0).normal}");
            otherHero.m_rigidbody.AddForce((otherHero.transform.position - transform.position).normalized * 20, ForceMode.Impulse);
            otherHero.BeAttacked(1);
            otherHero.SetCurUnitState(UnitState.BeatBack);
        }
    }

    /// <summary>
    /// 被攻击，仅扣血
    /// </summary>
    /// <returns>是否还活着</returns>
    public bool BeAttacked(float attackNumber)
    {
        if (m_hp < attackNumber)
        {
            m_hp = 0;
            CurUnitState = UnitState.Die;
            return false;
        }

        m_hp -= attackNumber;
        return true;
    }
}
