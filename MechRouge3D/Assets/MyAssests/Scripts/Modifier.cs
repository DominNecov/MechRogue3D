using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier 
{
    public Stat TheStatToMod;
    public bool additive;
    public float amountToChange;

    public Modifier(Stat stattoset, bool boolToSet, float amountToSet)
    {
        TheStatToMod = stattoset;
        additive = boolToSet;
        amountToChange = amountToSet;
    }
    
    public void SetStat(Stat stattoset)
    {
        TheStatToMod = stattoset;
    }
    public void SetAdditive(bool boolToSet)
    {
        additive = boolToSet;
    }
    public void SetAmountToChange (float amountToSet)
    {
        amountToChange = amountToSet;
    }
    public void SetModifier(Stat stattoset, bool boolToSet,float amountToSet)
    {
        TheStatToMod = stattoset;
        additive = boolToSet;
        amountToChange = amountToSet;
    }
    public void Equip()
    {
        if (additive)
        {
            TheStatToMod.AddAdditive(amountToChange);
        } else
        {
            TheStatToMod.AddMultiplier(amountToChange);
        }
        
    }
    public void Unequip()
    {
        if (additive)
        {
            TheStatToMod.RemoveAdditive(amountToChange);
        }
        else
        {
            TheStatToMod.RemoveMultiplier(amountToChange);
        }

    }
}
