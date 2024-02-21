using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
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

    private PlayerInteractS playerInteract;
    private InventoryPage inventoryUI;
    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;
    public string[] dialogue;
    public int index;
    private bool puzzleOne = false;
    private bool puzzleOver = false;
    public float wordSpeed;
    // public bool playerIsClose;

    private void StartLevel() {
        PlayerInteractS.fairyTalk -= PuzzleOneDialogue;
        puzzleOne = false;
        puzzleOver = false;
        PlayerInteractS.fairyTalk += PuzzleOneDialogue;
        CloseDialogue();
        index = 0;
    }
    // void Start() {

    // }
    // Update is called once per frame

    IEnumerator Typing() {
        foreach (char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void OnDestroy() {
        // if (puzzleOne) {
            print("destroy called");
        print("puzzleOne: "+puzzleOne +" and puzzleOver: "+puzzleOver);
        if (puzzleOne && !puzzleOver)
        print("destroy pass");
    {
        // if (cameraSwitch == 2)
        // {
        PlayerInteractS.fairyTalk -= PuzzleOneDialogue;
        print("remove dialogye");        // }
        InventoryPage.gardenComplete += EndPuzzle;
    }
    if (!puzzleOne && puzzleOver)
    {
        print("destroy 2 pass");

        InventoryPage.gardenComplete -= EndPuzzle;
    }
        // } ugh
    }

    public void NextLine() {
        if (index< dialogue.Length - 1) {
            index++;
            dialogueText.text="";
            StartCoroutine(Typing());
        } else {
            CloseDialogue();
        }
    }

    private void PuzzleOneDialogue() {
        puzzleOne = true;
        print("dialogue called");
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());

        index ++;
        OnDestroy();
        
    }

    private void EndPuzzle() {
        print("end puzzle run");
        CloseDialogue();
        OnDestroy();
    }

    private void CloseDialogue() {
        print("dialogue close");
        dialogueText.text="";
        // index=0;
        dialoguePanel.SetActive(false);
        puzzleOver = true;
    }

//hi
}
