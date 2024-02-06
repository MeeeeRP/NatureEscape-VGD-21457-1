using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
        //This is Main Camera in the Scene
    public Camera Camera_1;
    //This is the second Camera and is assigned in inspector
    public Camera Camera_2;
    public int Manager;

    public PlayerInteractS playerInteract;
    public InventoryPage inventoryControl;

    private bool puzzleOne = false;
    private bool puzzleOver = false;

    public int cameraSwitch = 0;
    public int cameraSwitchBack = 0;


    private void Start() {
        //This gets the Main Camera from the Scene
        Camera_1 = Camera.main;
        //This enables Main Camera
        Camera_1.enabled = true;
        //Use this to disable secondary Camera
        Camera_2.enabled = false;
        PlayerInteractS.fairyTalk += PuzzleCamera;
    }

    private void OnDestroy()
{
    if (puzzleOne && !puzzleOver)
    {
        PlayerInteractS.fairyTalk -= PuzzleCamera;
        InventoryPage.gardenComplete += PuzzleEnd;

    }
    if (puzzleOver) {
        InventoryPage.gardenComplete -= PuzzleEnd;
    }
}

    public void ManagerCamera() {
        print("Manager run");
        if (Manager == 0) {
            Cam_2();
            Manager = 1;
        } else {
            Cam_1();
            Manager = 0;
        }
    }
    void Cam_1() {
        Camera_1.enabled = true;
        Camera_2.enabled = false;
        // Camera_1 = Camera.main;

    }

        void Cam_2() {
        Camera_2.enabled = true;
        Camera_1.enabled = false;
        // Camera_2 = Camera.main;
    }

    private void PuzzleCamera() {
        GetComponent<Animator>().SetTrigger("Change");
        print("change trigger");
        puzzleOne = true;
        cameraSwitch++;
        if (cameraSwitch == 2) {
        OnDestroy();
        }
    }

    private void PuzzleEnd() {
        GetComponent<Animator>().SetTrigger("Change");
        print("change trigger");
        puzzleOver = true;
        cameraSwitchBack++;
        if (cameraSwitchBack == 2) {
        OnDestroy();
        }
    }
    
}
