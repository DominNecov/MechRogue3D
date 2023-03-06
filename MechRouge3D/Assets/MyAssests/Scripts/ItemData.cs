using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemData", menuName = "NewItem")]
public class ItemData : ScriptableObject
{
    public string ItemName = null;
    public int NumberOfDefaultStats = 1;
    public bool DeFaultStatOneAdditive = true;
    public string DefaultStat1 = null;
    public float DefaultAmount1 = 0;
    public bool DeFaultStatTwoAdditive = true;
    public string DefaultStat2 = null;
    public float DefaultAmount2 = 0;
    public bool DeFaultStatThreeAdditive = true;
    public string DefaultStat3 = null;
    public float DefaultAmount3 = 0;
    public EquipSlot EquipmentSlot;
    public Sprite Icon = null;
    public StatGroup Statpool;

}


