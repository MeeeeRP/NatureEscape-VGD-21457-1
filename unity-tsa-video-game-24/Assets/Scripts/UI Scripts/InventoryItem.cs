using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private Image borderImage;

    public event Action<InventoryItem> OnItemClicked,
        OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
        OnRightMouseBtnClick;
    // private SpriteRenderer sRenderer;
    // private PuzzleSlot pSlot;
        public bool empty = true;

        //this probably messes stuff up
    // public void Initialize(PuzzleSlot slot) {
    //     sRenderer.sprite = slot.Renderer.sprite;
    //     pSlot = slot;
    // }

        public void Awake() {
            ResetData();
            Deselect();
        }

        public void ResetData() {
            this.itemImage.gameObject.SetActive(false);
            empty = true;
            print("reset data run");
        }

        public void Deselect() {
            borderImage.enabled = false;
        }

        public void SetData(Sprite sprite) { 
            this.itemImage.gameObject.SetActive(true);
            this.itemImage.sprite = sprite;
            empty = false;
        }

        public void Select() {
            borderImage.enabled = true;
        }

    public void OnPointerClick(PointerEventData pointerData)
    {
        if (pointerData.button == PointerEventData.InputButton.Right) {
            OnRightMouseBtnClick?.Invoke(this);
        } else {
            OnItemClicked?.Invoke(this);
        }    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (empty) {
            return;
        }
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);

    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

}
