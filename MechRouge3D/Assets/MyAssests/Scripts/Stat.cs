using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float statThatIsStored;
    [SerializeField]
    private float baseStat;
    private List<float> additiveMultipliers = new List<float>();
    private List<float> multipliers = new List<float>();
    private float totalmultiplier;
  

    public float getStat()
    {
        return statThatIsStored;
    }
    public void setStat(float newStat)
    {
        baseStat = newStat;
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
        updateValue();
    }
    public void RemoveAdditive(float additiveMultiplier)
    {
        additiveMultipliers.Remove(additiveMultiplier);
        updateValue();
    }
    public void AddMultiplier (float MultiplierToAdd)
    {
        multipliers.Add(MultiplierToAdd);
        updateValue();
    }
    public void RemoveMultiplier (float MultiplierToRemove)
    {
        multipliers.Remove(MultiplierToRemove);
        updateValue();
    }
    private void updateValue()
    {
        statThatIsStored = baseStat;
        foreach(float statToAdd in additiveMultipliers)
        {
            statThatIsStored += statToAdd;
        }
        totalmultiplier = 1;
        foreach(float statToMultiply in multipliers)
        {
            totalmultiplier += statToMultiply;
        }
        statThatIsStored = statThatIsStored * totalmultiplier;
    }
}
