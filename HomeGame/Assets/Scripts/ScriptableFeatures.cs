using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableFeatures", menuName = "Scriptable Objects/ScriptableFeatures")]
public class ScriptableFeatures : ScriptableObject
{
    public List<Feature> features = new List<Feature>();
}
[System.Serializable]
public class Feature
{
    public string name;
    public string description;
    public string flavourText;
    public string progressText;
}
