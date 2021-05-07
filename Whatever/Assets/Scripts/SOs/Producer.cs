using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unnamed Producer", menuName = "New Scriptable Object/Create New Producer Type", order = 20)]
public class Producer : ScriptableObject
{
    [SerializeField] string producerName;
    [SerializeField] double baseCost;
    [SerializeField] double baseAmountProduced;
    [SerializeField] double baseMultiplier;
    [SerializeField] float baseProductionTime;

    public string ProducerName { get => producerName; }
    public double BaseCost { get => baseCost; }
    public double BaseAmountProduced { get => baseAmountProduced; }
    public double BaseMultiplier { get => baseMultiplier; }
    public float BaseProductionTime { get => baseProductionTime; }
}
