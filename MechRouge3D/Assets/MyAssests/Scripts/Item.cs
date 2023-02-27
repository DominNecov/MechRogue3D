using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public EquipSlot EquipSlot;
    public string ItemName;
    public ChestRarity Chestlevel;
    public List<Modifier> ModList = new List<Modifier>();

    private int NumberOfMods;

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

    public void CreateItem(ChestRarity chestraritylevel)
    {
        
        switch (chestraritylevel)
        {
            case ChestRarity.common:
                NumberOfMods = 0;
                break;
            case ChestRarity.uncommon:
                NumberOfMods = 1;
                break;
            case ChestRarity.rare:
                NumberOfMods = 2;
                break;
            case ChestRarity.legendary:
                NumberOfMods = 3;
                break;
            case ChestRarity.epic:
                NumberOfMods = 4;
                break;
        }
        int RandomInt = Random.Range(0, 8);
        if(RandomInt == 0)
        {
            EquipSlot = EquipSlot.head;
        } else if (RandomInt == 1)
        {
            EquipSlot = EquipSlot.chest;
        } else if (RandomInt == 2)
        {
            EquipSlot = EquipSlot.leftHand;
        }
        else if (RandomInt == 3)
        {
            EquipSlot = EquipSlot.rightHand;
        }
        else if (RandomInt == 4)
        {
            EquipSlot = EquipSlot.legs;
        }
        else if (RandomInt == 5)
        {
            EquipSlot = EquipSlot.back;
        }
        else if (RandomInt == 6)
        {
            EquipSlot = EquipSlot.rightShoulder;
        }
        else if (RandomInt == 7)
        {
            EquipSlot = EquipSlot.leftShoulder;
        }
        else if (RandomInt == 8)
        {
            EquipSlot = EquipSlot.belt;
        }
        for (int a = 1; a <= NumberOfMods; a++)
        {
            Modifier mod2UC = new Modifier(
                    GameObject.FindObjectOfType<Hero>().GetRandomStat(), true, Random.Range(0f, 10f));
            ModList.Add(mod2UC);
        }
    }
}
