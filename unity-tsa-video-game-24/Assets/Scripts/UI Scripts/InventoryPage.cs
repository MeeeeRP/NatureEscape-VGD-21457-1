using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private InventoryDescription itemDescription;

    [SerializeField]
    private MouseFollower mouseFollower;

    public List<InventoryItem> listOfUIItems = new List<InventoryItem>();
    public int currentlyDraggedItemIndex = -1;
    public int lastDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    private void Awake() {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorySize) {
        for (int i = 0; i < inventorySize; i++) {
            InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    internal void ResetAllItems() {
        foreach (var item in listOfUIItems) {
            item.ResetData();
            item.Deselect();
        }
    }
    
    public void UpdateData(int itemIndex, Sprite itemImage) {
        if (listOfUIItems.Count > itemIndex) {
            listOfUIItems[itemIndex].SetData(itemImage);
        }
    }

    private void HandleShowItemActions(InventoryItem item)
    {

    }


    private void HandleEndDrag(InventoryItem item)
    {
        ResetDraggedItem();
    }


    private void HandleSwap(InventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);

    }

    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        lastDraggedItemIndex = currentlyDraggedItemIndex;
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(InventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if (index == -1) {
            return;
        }
        currentlyDraggedItemIndex = index;
        lastDraggedItemIndex=index;
        HandleItemSelection(item);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDraggedItem(Sprite sprite) {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite);
    }
    private void HandleItemSelection(InventoryItem item)
    {
        int index = listOfUIItems.IndexOf(item);
        if (index == -1)
            return;
        OnDescriptionRequested?.Invoke(index);
    }


    public void Show() {
        gameObject.SetActive(true);
        ResetSelection();

    }

    public void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    private void DeselectAllItems()
    {
        foreach (InventoryItem item in listOfUIItems) {
            item.Deselect();
        }
    }

    public void Hide() {
        gameObject.SetActive(false);
        ResetDraggedItem();
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        itemDescription.SetDescription(itemImage, name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
    }
}
