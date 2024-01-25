using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Collider2D interactCollider;
    Vector2 rightInteractOffset;

    // Start is called before the first frame update
    void Start()
    {
        // interactCollider = GetComponent<Collider2D>();
        rightInteractOffset = transform.position;
    }

    public void InteractRight() {
        print("Attack Right");
        interactCollider.enabled = true;
        transform.localPosition = rightInteractOffset;
    }

    public void InteractLeft() {
        print("Attack Left");
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
        } else if (other.tag == "Object") {
            // Pickup object
            // Add to inventory
        }
    }


    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
