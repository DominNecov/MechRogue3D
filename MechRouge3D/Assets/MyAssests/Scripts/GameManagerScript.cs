using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<ChestRarity> ChestToOpen = new List<ChestRarity>();
    private float[] weights = {0,0,0,0,0};
    public float total;

    public void AddChestToList(float commonChance, float uncommonChance, float rareChance, 
                float epicChance, float legendaryChance)
    {
        weights[0] = commonChance;
        weights[1] = uncommonChance;
        weights[2] = rareChance;
        weights[3] = epicChance;
        weights[4] = legendaryChance;
        float randomNumber = Random.Range(0, 100);
        Debug.Log(randomNumber);
        foreach(float weight in weights)
        {
            total += weight;
        }
        for(int i = 0; i < weights.Length; i++)
        {
            if (randomNumber <= weights[i])
            {
                if (i == 0)
                {
                    ChestToOpen.Add(ChestRarity.common);
                } else if (i ==1)
                {
                    ChestToOpen.Add(ChestRarity.uncommon);
                }
                else if (i == 2)
                {
                    ChestToOpen.Add(ChestRarity.rare);
                }
                else if (i == 3)
                {
                    ChestToOpen.Add(ChestRarity.epic);
                }
                else if (i == 4)
                {
                    ChestToOpen.Add(ChestRarity.legendary);
                }
                break;
            } else
            {
                randomNumber -= weights[i];
            }
        }

        
    }
    public void PrintChest()
    {
        foreach(ChestRarity enumToPrint in ChestToOpen)
        {
            Debug.Log(enumToPrint);
        }
    }
}
