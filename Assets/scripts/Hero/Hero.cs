using System;
using UnityEngine;
using UnityEngine.Serialization;


public class Hero : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rigidbody;
    [SerializeField] private HeroData m_heroData;

    public HeroData HeroData => m_heroData;

    /// <summary>
    /// 当前状态
    /// </summary>
    public UnitState CurUnitState { get; protected set; } = UnitState.Idle;

    /// <summary>
    /// 阵营
    /// </summary>
    [FormerlySerializedAs("m_camp")] public Camp Camp;

    [FormerlySerializedAs("m_attackTarget")] public Hero Target;

    public float CurHp = 5;
    public float MaxHp = 1;

    public void Init()
    {
        MaxHp = HeroData.MaxHp;
        CurHp = HeroData.MaxHp;
        CurUnitState = UnitState.Idle;
        Target = null;
    }

    public void Init(HeroData heroData)
    {
        m_heroData = heroData;
        Init();
    }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Target && Target.CurUnitState == UnitState.Die)
        {
            Target = null;
        }

        switch (CurUnitState)
        {
            case UnitState.Idle:
                if (BattleManager.Instance.TryGetEnemy(this, out Target))
                {
                    SetCurUnitState(UnitState.Move);
                    Debug.Log($"{name}找到敌人{Target.name}");
                }
                break;
            case UnitState.Move:
                if (Target)
                {
                    MoveTo(Target.transform.position);
                }

                break;
            case UnitState.BeatBack:
                if (Rigidbody.velocity.magnitude < 0.05f)
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
        Rigidbody.AddForce(moveDir * (Time.deltaTime * m_heroData.m_speed), ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Hero>(out var otherHero))
        {
            Debug.Log($"碰撞了：{otherHero.name} normal:{other.GetContact(0).normal}");
            AttackTarget(otherHero);

        }
    }

    virtual public void AttackTarget(Hero target)
    {
        target.Rigidbody.AddForce((target.transform.position - transform.position).normalized * m_heroData.ImpactForce, ForceMode.Impulse);
        target.BeAttacked(m_heroData.Attack);
        target.SetCurUnitState(UnitState.BeatBack);
    }

    /// <summary>
    /// 被攻击，仅扣血
    /// </summary>
    /// <returns>是否还活着</returns>
    public bool BeAttacked(float attackNumber)
    {
        if (CurHp < attackNumber)
        {
            CurHp = 0;
            CurUnitState = UnitState.Die;
            return false;
        }

        CurHp -= attackNumber;
        return true;
    }
}
