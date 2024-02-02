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
    bool puzzleOne = false;

    // public int inventorySize = 10;
    private void Start()
    {
        PrepareUI();
        // inventoryData.Initialize();
        PlayerInteractS.fairyTalk += InventoryShow;
    }

    private void PrepareUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItems += HandleSwapItems;
        this.inventoryUI.OnStartDragging += HandleStartDragging;
        this.inventoryUI.OnItemActionRequested += HandleItemActionRequest;
    }

    private void HandleItemActionRequest(int itemIndex)
    {
        
    }

    private void HandleStartDragging(int itemIndex)
    {
        
    }

    private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
    {
        
    }

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

    public void InventoryShow() {
        // need to change so it is not on button or update (key input)
        // Make a result of delegate

            // if (inventoryUI.isActiveAndEnabled == false) {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                    item.Value.item.ItemImage);
                }
            // } else {
            //     inventoryUI.Hide();
            // }
        // PlayerInteractS.fairyTalk+= InventoryShow;
        puzzleOne= true;
        OnDestroy();
    }


}
