using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemStruct> inventoryItems;
}

[Serializable]
public struct InventoryItemStruct {
    public int quantity;
    public ItemSO item;
    public bool IsEmpty => item == null;


    public InventoryItemStruct ChangeQuantity(int newQuantity) {
        return new InventoryItemStruct
        {
            item = this.item, quantity = newQuantity,
        };
    }

    public static InventoryItemStruct getEmptyItem()
        => new InventoryItemStruct
        {
            item = null,
            quantity = 0,
        };
}