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
        ItemData NewItem = GameObject.FindObjectOfType<Hero>().GetRandomItemFromList();
        if(NewItem.NumberOfDefaultStats >= 1)
        {
            Stat DefaultStatToAdd = GameObject.FindObjectOfType<Hero>().FindStatInDictonary(NewItem.DefaultStat1);
            Modifier DefaultModToAdd = new Modifier(DefaultStatToAdd, 
                NewItem.DeFaultStatOneAdditive, NewItem.DefaultAmount1);
            ModList.Add(DefaultModToAdd);  
        }
        if (NewItem.NumberOfDefaultStats >= 2)
        {
            Stat DefaultStatToAdd = GameObject.FindObjectOfType<Hero>().FindStatInDictonary(NewItem.DefaultStat2);
            Modifier DefaultModToAdd = new Modifier(DefaultStatToAdd,
                NewItem.DeFaultStatTwoAdditive, NewItem.DefaultAmount2);
            ModList.Add(DefaultModToAdd);
        }
        if (NewItem.NumberOfDefaultStats >= 3)
        {
            Stat DefaultStatToAdd = GameObject.FindObjectOfType<Hero>().FindStatInDictonary(NewItem.DefaultStat3);
            Modifier DefaultModToAdd = new Modifier(DefaultStatToAdd,
                NewItem.DeFaultStatThreeAdditive, NewItem.DefaultAmount3);
            ModList.Add(DefaultModToAdd);
        }

        for (int a = 1; a <= NumberOfMods; a++)
        {
            switch (NewItem.Statpool)
            {
                case StatGroup.offensive:
                    Stat stattomod = GameObject.FindObjectOfType<Hero>().GetRandomStatOffensive();
                    int Coinflip2 = Random.Range(0, 1);
                    if(Coinflip2 == 1)
                    {
                        Modifier mod2UC = new Modifier(stattomod, true,
                         Random.Range(stattomod.minAdditive, stattomod.maxAdditive));
                        ModList.Add(mod2UC);
                    } else
                    {
                        Modifier mod2UC = new Modifier(stattomod, false,
                        Random.Range(stattomod.minMultiplier, stattomod.maxMultiplier));
                        ModList.Add(mod2UC);
                    }
                    
                    break;
                case StatGroup.defensive:
                    Stat stattomod2 = GameObject.FindObjectOfType<Hero>().GetRandomStatDeffensive();
                    int Coinflip = Random.Range(0, 1);
                    if(Coinflip == 1)
                    {
                        Modifier mod = new Modifier(stattomod2, true,
                         Random.Range(stattomod2.minAdditive, stattomod2.maxAdditive));
                        ModList.Add(mod);
                    } else
                    {
                        Modifier mod = new Modifier(stattomod2, false,
                       Random.Range(stattomod2.minMultiplier, stattomod2.maxMultiplier));
                        ModList.Add(mod);
                    }
                    break;
            }
                
        }
        NumberOfMods = 0;
        EquipSlot = NewItem.EquipmentSlot;
    }
}
