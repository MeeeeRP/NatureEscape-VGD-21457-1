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
    private bool puzzleOne = true;//remember to go back and change
    private bool puzzleTwo = false;
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



     void OnMouseOver()
    {
        // Debug.Log(weight);
        // Debug.Log("mouse over "+Renderer.sprite.name);
        // (puzzleOne || puzzleTwo) &&
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
            if (puzzleOne) {
                print("one "+puzzleOne);
            if (selectedObject == seedOrder) {
                print("This is the one");
                Placed();
                //tell inventory to make it empty
        inventoryUI.listOfUIItems[inventoryUI.lastDraggedItemIndex].ResetData();
            }
            } else if (puzzleTwo) {
                print("two "+puzzleTwo);

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
        if (puzzleOne) {
        transform.Translate(0, 0.02f, 0);
        }
        print("Weight: "+weight);
        print("Seed Order: "+seedOrder);
        // logWeightArray[seedOrder]=weight;
        // for (int i=0; i<4; i++) {
        // Debug.Log(logWeightArray[i].ToString());
        // }
        if (puzzleTwo) {
        boatScript.AssignWeight(seedOrder, weight);
        }
        Renderer.sprite = flowerSprite;
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