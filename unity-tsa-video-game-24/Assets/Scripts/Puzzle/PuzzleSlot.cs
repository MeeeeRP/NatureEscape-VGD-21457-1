using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;

    [SerializeField]
    private InventoryPage inventoryUI;

    private InventoryItem itemUI;

    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private int seedOrder;
    private bool puzzleOne = false;
    public Collider2D slotCollider;
    public Vector3 startPos;    
    [SerializeField]
    private Sprite flowerSprite;

    // private Vector3 mousePos;

    public void Start() {
        PlayerInteractS.fairyTalk += PuzzleStart;
        startPos = transform.position;
    }

    public void Placed() {
        transform.position = startPos;
        transform.Translate(0, 0.02f, 0);
        Renderer.sprite = flowerSprite;
    }

    private void OnMouseOver()
    {
        if (puzzleOne && inventoryUI.lastDraggedItemIndex != -1)
        {

                 if (Input.GetMouseButtonUp(0))
                {
                    InventoryItemStruct inventoryItem = inventoryData.GetItemAt(inventoryUI.lastDraggedItemIndex);
        if (inventoryItem.IsEmpty) {
            // inventoryUI.ResetSelection();
            return;
        }
        ItemSO item = inventoryItem.item;
            int selectedObject = item.WinOrder;
            if (selectedObject == seedOrder) {
                print("This is the one");
                Placed();
                //tell inventory to make it empty
        inventoryUI.listOfUIItems[inventoryUI.lastDraggedItemIndex].ResetData();
            }
            }
            return;


            // currentObject = Selection.objects.OfType<REPLACEME>().FirstOrDefault();
            
        }
    }

    private void OnDestroy() {
        if (puzzleOne) {
        PlayerInteractS.fairyTalk -= PuzzleStart;
        }
    }  
    private void PuzzleStart() {
        puzzleOne = true;
        OnDestroy();
    }

}