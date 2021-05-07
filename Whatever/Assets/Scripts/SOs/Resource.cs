using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unnamed Resource", menuName = "New Scriptable Object/Create New Resource Type", order = 10)]
public class Resource : ScriptableObject
{
    [SerializeField] string resourceName;
    [SerializeField] double resourceValue;
    [SerializeField] double resourceAmount;

    public string ResourceName { get => resourceName; }
    public double ResourceAmount { get => resourceAmount; set => resourceAmount = value; }

   
}
