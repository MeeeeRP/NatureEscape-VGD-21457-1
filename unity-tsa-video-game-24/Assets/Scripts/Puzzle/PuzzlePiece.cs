using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{

    // private MouseFollower mouseFollowerS;
    private bool dragging;
    private Vector2 originalPosition;

    void Awake() {
        originalPosition = transform.position;
    }

    // void Update() {
    //     if(!_dragging) return;

    //     var mousePosition = mouseFollowerS.MousePosition();

    //     transform.position = mousePosition;
    // }
    void OnMouseDown() {
        dragging = true;
        
    }

    void OnMouseUp() {
        // transform.position = originalPosition;
        dragging=false;
    }

}
