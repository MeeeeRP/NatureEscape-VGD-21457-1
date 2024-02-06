using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;
    private bool puzzleOne = false;

    // public int inventorySize = 10;
    public int showCount = 0;

    
    public List<InventoryItemStruct> initialItems = new List<InventoryItemStruct>();
    
    private void Start()
    {
        PrepareUI();
        PrepareInventoryData();
        PlayerInteractS.fairyTalk += InventoryShow;
    }

    private void PrepareInventoryData() {
        inventoryData.Initialize();
        inventoryData.OnInventoryUpdated += UpdateInventoryUI;
        foreach (InventoryItemStruct item in initialItems) {
            if (item.IsEmpty) {
                continue;
            }
            inventoryData.AddItem(item);
        }
    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItemStruct> inventoryState) {
        inventoryUI.ResetAllItems();
        foreach (var item in inventoryState) {
            inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage);
        }
    }
    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        // this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        
    }

    private void HandleDragging(int itemIndex)
    {
        InventoryItemStruct inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;
        inventoryUI.CreateDraggedItem(inventoryItem.item.ItemImage);
        // change for just picture
    }

    // private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
    // {
        
    // }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItemStruct inventoryItem = inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty) {
            inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
        inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
        
    }

private void OnDestroy()
{
    if (puzzleOne)
    {
        PlayerInteractS.fairyTalk -= InventoryShow;
    }
}

    private void InventoryShow() {
        // need to change so it is not on button or update (key input)
        // Make a result of delegate

            // if (inventoryUI.isActiveAndEnabled == false) {
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                    item.Value.item.ItemImage);
                }
                Invoke("ShowInventoryTemp", .40f);
                // inventoryUI.Show();
            // } else {
            //     inventoryUI.Hide();
            // }
        // PlayerInteractS.fairyTalk+= InventoryShow;
        puzzleOne= true;
        showCount++;
        if (showCount == 2) {
        OnDestroy();
        }
    }

    private void ShowInventoryTemp() {
        inventoryUI.Show();
    }


}
