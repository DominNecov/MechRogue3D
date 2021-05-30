using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    public Dictionary<EquipSlot,Item> EquipedItems = new Dictionary<EquipSlot,Item>();
    private EquipSlot equipSlot;
    
    private void Start()
    {
        EquipedItems.Add(EquipSlot.head,null );
        EquipedItems.Add(EquipSlot.chest, null);
        EquipedItems.Add(EquipSlot.rightHand, null);
        EquipedItems.Add(EquipSlot.leftHand, null);
        EquipedItems.Add(EquipSlot.rightShoulder, null);
        EquipedItems.Add(EquipSlot.leftShoulder, null);
        EquipedItems.Add(EquipSlot.belt, null);
        EquipedItems.Add(EquipSlot.legs, null);
        EquipedItems.Add(EquipSlot.back, null);
        this.UpdateStats();
    }
    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
    }
    public void EquipItem(Item itemToEquip)
    {
        
        if(EquipedItems[itemToEquip.EquipSlot] != null)
        {
            if (EquipedItems[itemToEquip.EquipSlot] == itemToEquip)
            {
                return;
            } else
            {
                EquipedItems[itemToEquip.EquipSlot].UnequipItem();
            }
            
        }
        EquipedItems[itemToEquip.EquipSlot] = itemToEquip;
        itemToEquip.EquipItem();
    }
    public void RemoveItem (Item itemToRemove)
    {
        EquipedItems[itemToRemove.EquipSlot] = null;
        itemToRemove.UnequipItem();
    }
}
