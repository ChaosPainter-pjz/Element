using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "HeroesPrefab", menuName = "ScriptableObject/HeroesPrefab", order = 0)]
public class HeroesPrefab : ScriptableObject
{
    public List<HeroKeyValuePair> Heroes;
}

[Serializable]
public struct HeroKeyValuePair
{
    [FormerlySerializedAs("Key")] public int Id;
    public GameObject Value;
}
