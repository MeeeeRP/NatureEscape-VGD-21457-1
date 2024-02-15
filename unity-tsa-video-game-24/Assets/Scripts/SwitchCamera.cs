using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCamera : MonoBehaviour
{
    // called first
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

        //This is Main Camera in the Scene
    public Camera Camera_1;
    //This is the second Camera and is assigned in inspector
    public Camera Camera_2;
    public int Manager;

    public PlayerInteractS playerInteract;
    public InventoryPage inventoryControl;

    public Animator changeAnimator;

    private bool puzzleOne = false;
    private bool puzzleOver = false;

    public int cameraSwitch = 0;
    public int cameraSwitchBack = 0;

    private void StartLevel() {
        changeAnimator = GetComponent<Animator>();
        //This gets the Main Camera from the Scene
        Camera_1 = Camera.main;
        //This enables Main Camera
        Camera_1.enabled = true;
        //Use this to disable secondary Camera
        Camera_2.enabled = false;
        PlayerInteractS.fairyTalk += PuzzleCamera;
        puzzleOne = false;
        puzzleOne = false;
    }

    private void Start() {
        // startLevel();
    }

private void OnDestroy()
{
    if (puzzleOne && !puzzleOver)
    {
        // if (cameraSwitch == 2)
        // {
            PlayerInteractS.fairyTalk -= PuzzleCamera;
        // }
        InventoryPage.gardenComplete += PuzzleEnd;
    }
    if (puzzleOver)
    {
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
        changeAnimator.SetTrigger("Change");
        print("change trigger");
        puzzleOne = true;
        cameraSwitch++;
        print("cameraSwitch: "+cameraSwitch);
        OnDestroy();
    
    }

    private void PuzzleEnd() {
        changeAnimator.SetTrigger("Change");
        print("change trigger");
        puzzleOver = true;
        // cameraSwitchBack++;
        print("cameraSwitchBack: "+cameraSwitchBack);
        OnDestroy();
    }
    
}
