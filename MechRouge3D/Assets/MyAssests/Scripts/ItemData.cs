using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemData", menuName = "NewItem")]
public class ItemData : ScriptableObject
{
    public List<Stat> PotentialStats = new List<Stat>();
    
}
