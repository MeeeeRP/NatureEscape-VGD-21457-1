using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private bool _dragging;

    void Update() {
        if(!_dragging) return;

        // var mousePosition= (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);

        // transform.position= mousePosition;
    }
    void OnMouseDown() {
        _dragging = true;
        
    }

}
