using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroesPrefab", menuName = "ScriptableObject/HeroesPrefab", order = 0)]
public class HeroesPrefab : ScriptableObject
{
    public List<HeroKeyValuePair> Heroes;
}

[Serializable]
public struct HeroKeyValuePair
{
    public int Key;
    public GameObject Value;
}
