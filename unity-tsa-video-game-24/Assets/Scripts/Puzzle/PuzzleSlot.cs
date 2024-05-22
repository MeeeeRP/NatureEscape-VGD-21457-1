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
    private static bool switchOver;

    [SerializeField]
    private int seedOrder;
    public static bool puzzleOneSlot = false;//remember to go back and change - changed
    public static bool puzzleTwoSlot = false;
    public Collider2D slotCollider;
    public Vector3 startPos;    
    [SerializeField]
    private Sprite flowerSprite;

    public Boat boatScript;

    private int weight;

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
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        StartLevelSlot();
    }

    private void OnDisable() {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void StartLevelSlot() {
        switchOver = false;
        PlayerInteractS.fairyTalk += PuzzleStart;
        print("puzzle 1: "+puzzleOneSlot);
        print("puzzle 2: "+puzzleTwoSlot);
        startPos = transform.position;
    }
    public void Start() {
    }



     void OnMouseOver()
    {
        // Debug.Log(weight);
        // Debug.Log("mouse over "+Renderer.sprite.name);
        // (puzzleOneSlot || puzzleTwoSlot) &&
        if (inventoryUI.lastDraggedItemIndex != -1)
        {
                 if (Input.GetMouseButtonUp(0))
                {
                Debug.Log("mouse up "+Renderer.sprite.name);

                    InventoryItemStruct inventoryItem = inventoryData.GetItemAt(inventoryUI.lastDraggedItemIndex);
        if (inventoryItem.IsEmpty) {
            return;
        }
        ItemSO item = inventoryItem.item;
            int selectedObject = item.WinOrder;
            if (puzzleOneSlot) {
                print("one "+puzzleOneSlot);
            if (selectedObject == seedOrder) {
                print("This is the one");
                Placed();
                //tell inventory to make it empty
        inventoryUI.listOfUIItems[inventoryUI.lastDraggedItemIndex].ResetData();
            }
            } else if (puzzleTwoSlot) {
                print("two "+puzzleTwoSlot);

                print ("placed level two?");
                // if (selectedObject != seedOrder) {
                flowerSprite= item.ItemImage;
                weight = item.WinOrder;
                
                Placed();
        inventoryUI.listOfUIItems[inventoryUI.lastDraggedItemIndex].Deselect();


                //tell inventory to make it empty
        inventoryUI.listOfUIItems[inventoryUI.lastDraggedItemIndex].ResetData();
            // }
            }

            }
            return;


            // currentObject = Selection.objects.OfType<REPLACEME>().FirstOrDefault();
            
        }
    }

    public void Placed() {
        transform.position = startPos;
        if (puzzleOneSlot) {
        transform.Translate(0, 0.02f, 0);
        }
        print("Weight: "+weight);
        print("Seed Order: "+seedOrder);
        // logWeightArray[seedOrder]=weight;
        // for (int i=0; i<4; i++) {
        // Debug.Log(logWeightArray[i].ToString());
        // }
        if (puzzleTwoSlot) {
        Boat.AssignWeight(seedOrder, weight);
        }
        Renderer.sprite = flowerSprite;
    }

    private void OnDestroy() {
        if (puzzleOneSlot) {
        PlayerInteractS.fairyTalk -= PuzzleStart;
        }
        if (puzzleTwoSlot) {
        PlayerInteractS.fairyTalk -= PuzzleStart;
        }
    }  
    private void PuzzleStart() {
        if (!switchOver) {
            if (!puzzleOneSlot && !puzzleTwoSlot) {
                puzzleOneSlot= true;
                print("1 Set true");
                switchOver = true;
            }
        }
    if (!switchOver) {
        if (puzzleOneSlot) {
        print("2 Set true");
            puzzleOneSlot = false;
            puzzleTwoSlot = true;
        }
        switchOver = true;
        }
        OnDestroy();
    }

}