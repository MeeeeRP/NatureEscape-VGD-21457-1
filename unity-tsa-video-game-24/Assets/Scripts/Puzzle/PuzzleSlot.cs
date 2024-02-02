using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField]
    private Sprite flowerSprite;

    public SpriteRenderer spriteRenderer;

    public void Placed() {
        spriteRenderer.sprite = flowerSprite;
    }

}