using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float statThatIsStored;
    private List<float> additiveMultipliers = new List<float>();
    private List<float> multipliers = new List<float>();
  

    public float getStat()
    {
        return statThatIsStored;
    }
    public void setStat(float newStat)
    {
        statThatIsStored = newStat;
    }
    public void subtractStat(float amountToSubtract)
    {
        statThatIsStored -= amountToSubtract;
    }
    public void addStat(float amountToAdd)
    {
        statThatIsStored += amountToAdd;
    }
    public void AddAdditive(float additiveMultiplier)
    {
        additiveMultipliers.Add(additiveMultiplier);
    }
    public void RemoveAdditive(float additiveMultiplier)
    {
        additiveMultipliers.Remove(additiveMultiplier);
    }
    public void AddMultiplier (float MultiplierToAdd)
    {
        multipliers.Add(MultiplierToAdd);
    }
    public void RemoveMultiplier (float MultiplierToRemove)
    {
        multipliers.Remove(MultiplierToRemove);
    }
}
