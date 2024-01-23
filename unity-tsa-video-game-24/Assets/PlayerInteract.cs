using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    Vector2 rightInteractOffset;
    Collider2D interactCollider;

    public void InteractRight() {
        print("Attack Right");
        interactCollider.enabled = true;
        transform.position = rightInteractOffset;
    }

    public void InteractLeft() {
        print("Attack Left");
        interactCollider.enabled = true;
        transform.position = new Vector2(rightInteractOffset.x * -1, rightInteractOffset.y);
    }

    public void StopInteract() {
        interactCollider.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactCollider = GetComponent<Collider2D>();
        rightInteractOffset = transform.position;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
