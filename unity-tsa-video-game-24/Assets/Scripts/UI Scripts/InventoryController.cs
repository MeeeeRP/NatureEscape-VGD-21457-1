using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;
    bool puzzleOne = false;

    public int inventorySize = 10;
    private void Start() {
        inventoryUI.InitializeInventoryUI(inventorySize);
        PlayerInteractS.fairyTalk+= InventoryShow;
    }
        void Update() {
        if (puzzleOne) {
        PlayerInteractS.fairyTalk -= InventoryShow;

        }
    }
    public void InventoryShow() {
        // need to change so it is not on button or update (key input)
        // Make a result of delegate

            if (inventoryUI.isActiveAndEnabled == false) {
                inventoryUI.Show();
            } else {
                inventoryUI.Hide();
            }
        // PlayerInteractS.fairyTalk+= InventoryShow;
        puzzleOne= true;
    }


}
