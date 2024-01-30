using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryPage inventoryUI;

    public int inventorySize = 10;
    private void Start() {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }
    public void Update() {
        // need to change so it is not on button or update (key input)
        // Make a result of delegate
        if (Input.GetKeyDown(KeyCode.I)) {
            if (inventoryUI.isActiveAndEnabled == false) {
                inventoryUI.Show();
            } else {
                inventoryUI.Hide();
            }
        }
    }
}
