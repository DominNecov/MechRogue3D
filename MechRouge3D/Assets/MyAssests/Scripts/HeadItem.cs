using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadItem : Item
{
    public HeadItem(ChestRarity chestRarityItCameOutOf)
    {
        EquipSlot = EquipSlot.head;
        switch (chestRarityItCameOutOf)
        {
            case ChestRarity.common:
                Modifier mod1 = new Modifier(
                    GameObject.FindObjectOfType<Hero>().PhysicalDefence, true, 10);
                ModList.Add(mod1);
                break;
            case ChestRarity.uncommon:
                Modifier mod1UC = new Modifier(
                    GameObject.FindObjectOfType<Hero>().PhysicalDefence, true, 10);
                ModList.Add(mod1UC);
                Modifier mod2UC = new Modifier(
                    GameObject.FindObjectOfType<Character>().GetRandomStat(), true, 10);
                ModList.Add(mod2UC);
                break;
            case ChestRarity.rare:
                Modifier mod1R = new Modifier(
                    GameObject.FindObjectOfType<Hero>().PhysicalDefence, true, 10);
                ModList.Add(mod1R);
                Modifier mod2R = new Modifier(
                    GameObject.FindObjectOfType<Character>().GetRandomStat(), true, 10);
                ModList.Add(mod2R);
                
                break;
            case ChestRarity.legendary:
                Modifier mod1L = new Modifier(
                    GameObject.FindObjectOfType<Hero>().PhysicalDefence, true, 10);
                ModList.Add(mod1L);
                Modifier mod2L = new Modifier(
                    GameObject.FindObjectOfType<Character>().GetRandomStat(), true, 10);
                ModList.Add(mod2L);
                break;
            case ChestRarity.epic:
                Modifier mod1E = new Modifier(
                    GameObject.FindObjectOfType<Hero>().PhysicalDefence, true, 10);
                ModList.Add(mod1E);
                Modifier mod2E = new Modifier(
                    GameObject.FindObjectOfType<Character>().GetRandomStat(), true, 10);
                ModList.Add(mod2E);
                break;

        }
            

    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

  
}
