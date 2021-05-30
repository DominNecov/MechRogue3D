using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item 
{
    public EquipSlot EquipSlot;
    public ChestRarity Chestlevel;
    public List<Modifier> ModList = new List<Modifier>();
 
    public void UnequipItem()
    {
        foreach (Modifier modToUnequip in ModList)
        {
            modToUnequip.Unequip();
        }
    }

    public void EquipItem()
    {
        foreach (Modifier modToEquip in ModList)
        {
            modToEquip.Equip();
        }
    }
    public void AddModToList(Modifier modToAdd)
    {
        ModList.Add(modToAdd);
    }
    public void RemoveModFromList (Modifier modToRemove)
    {
        ModList.Remove(modToRemove);
    }
}
