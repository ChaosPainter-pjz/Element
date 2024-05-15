using UnityEngine;


public class HpView : MonoBehaviour
{
    private Hero hero;
    private Material material;
    private static readonly int Value = Shader.PropertyToID("_Value");

    void Start()
    {
        hero = GetComponentInParent<Hero>();
        material = new Material(GetComponent<MeshRenderer>().material);
        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        if (hero)
        {
            material.SetFloat(Value, hero.m_hp / hero.MaxHp);
        }
    }
}
