using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private bool puzzleTwo = false;
    public Collider2D slotCollider;
    public Vector3 startPos;    
    [SerializeField]
    private Sprite flowerSprite;

    // public Camera main;
    // public Camera local;
    // public Camera cam;


    // private Vector3 mousePos;

    private void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        StartLevel();
    }

    private void OnDisable() {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void StartLevel() {
        PlayerInteractS.fairyTalk += PuzzleStart;
        startPos = transform.position;
    }
    public void Start() {
    }

    public void Placed() {
        transform.position = startPos;
        transform.Translate(0, 0.02f, 0);
        Renderer.sprite = flowerSprite;
    }

     void OnMouseOver()
    {
        // Debug.Log("mouse over "+Renderer.sprite.name);
        if ((puzzleOne || puzzleTwo) && inventoryUI.lastDraggedItemIndex != -1)
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
            if (selectedObject == seedOrder) {//hi
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
        if (puzzleTwo) {
        PlayerInteractS.fairyTalk -= PuzzleStart;
        }
    }  
    private void PuzzleStart() {
        if (!puzzleOne) {
        puzzleOne= true;
        } else if (puzzleOne) {
            puzzleOne = false;
            puzzleTwo = true;
        }
        OnDestroy();
    }

}