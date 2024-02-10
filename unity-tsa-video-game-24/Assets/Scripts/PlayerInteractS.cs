using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractS : MonoBehaviour
{
    public Collider2D interactCollider;
    Vector2 rightInteractOffset;
    public bool puzzleHappen = false;
    // public NPC npcScript;

    // event code =>
    public delegate void LevelOneEvent();
    public static event LevelOneEvent fairyTalk;


    // Start is called before the first frame update
    private void Start()
    {
        // interactCollider = GetComponent<Collider2D>();
        rightInteractOffset = transform.position;
        // fairyTalk += PuzzleOne;
    }

    public void InteractRight() {
        print("Talk Right");
        interactCollider.enabled = true;
        transform.localPosition = rightInteractOffset;
    }

    public void InteractLeft() {
        print("Talk Left");
        interactCollider.enabled = true;
        transform.localPosition = new Vector2(rightInteractOffset.x * -1, rightInteractOffset.y);
    }

    public void StopInteract() {
        interactCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "NPC") {
            // NPC talk
            print("npc talk trigger");
            if (!puzzleHappen) {
                fairyTalk?.Invoke();
                puzzleHappen=true;
            } else {
                print("already complete");
            }
            // npcScript.Talk();

            // print("1... Puzzle one start");

        } else if (other.tag == "Object") {
            // Pickup object
            // Add to inventory
        }
    }

    // void PuzzleOne() {
    //     print("2... puzzle one start");
    //     fairyTalk -= PuzzleOne;
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

}
