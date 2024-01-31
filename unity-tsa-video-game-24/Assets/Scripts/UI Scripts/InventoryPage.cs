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

    List<InventoryItem> listOfUIItems = new List<InventoryItem>();

    public Sprite image;
    // public int quantity;
    public string title, description;

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

    private void HandleShowItemActions(InventoryItem item)
    {

    }


    private void HandleEndDrag(InventoryItem item)
    {
        mouseFollower.Toggle(false);

    }


    private void HandleSwap(InventoryItem item)
    {

    }


    private void HandleBeginDrag(InventoryItem item)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image);
    }


    private void HandleItemSelection(InventoryItem item)
    {
        itemDescription.SetDescription(image, title, description);
        listOfUIItems[0].Select();
    }


    public void Show() {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image); //, quantity
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
