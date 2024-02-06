using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Animator animator;
    private PlayerInteractS playerInteract;

    private void Talk() {
        animator.SetTrigger("Talk");
        print("npc talk aniamation");
        PlayerInteractS.fairyTalk -= Talk;

    }

    public void Awake() {
        animator= GetComponent<Animator>();   
    }    

    // Start is called before the first frame update
    void Start()
    {
    PlayerInteractS.fairyTalk -= Talk;
    // PlayerInteractS.fairyTalk -= Talk;
    PlayerInteractS.fairyTalk += Talk;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
