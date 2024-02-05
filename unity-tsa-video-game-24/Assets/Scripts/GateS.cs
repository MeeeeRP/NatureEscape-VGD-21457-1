using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateS : MonoBehaviour
{
    public Collider2D gateCollider;
    private bool puzzleOne = false;
    public SpriteRenderer Renderer;

    public Sprite openSprite;

    private void Start()
    {
        gateCollider.enabled = true;
        PlayerInteractS.fairyTalk += GateOpen;

        // interactCollider = GetComponent<Collider2D>();
        // fairyTalk += PuzzleOne;
    }


    private void GateOpen() {
        gateCollider.enabled = false;
        puzzleOne = true;
        Renderer.sprite = openSprite;

        OnDestroy();
    }

    private void OnDestroy()
{
    if (puzzleOne)
    {
        PlayerInteractS.fairyTalk -= GateOpen;
    }
}

}
