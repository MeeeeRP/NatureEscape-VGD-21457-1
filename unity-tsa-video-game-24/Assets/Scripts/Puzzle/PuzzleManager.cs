using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private InventoryItem inventoryItem; // item?
    private MouseFollower draggedItem; // item?
    private InventoryPage itemInventory; // list

    [SerializeField] private List<PuzzleSlot> slotPrefabs;

    [SerializeField] private Transform slotParent, peiceParent;
    // [SerializeField]
    // private PuzzlePiece piecePrefab;

    void Spawn() {

    }
}
