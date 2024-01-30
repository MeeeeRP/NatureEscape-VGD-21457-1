using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Animator animator;

    public void Talk() {
        animator.SetTrigger("Talk");
        print("npc talk aniamation");
        PlayerInteractS.fairyTalk -= Talk;

    }
    

    // Start is called before the first frame update
    void Start()
    {
    animator= GetComponent<Animator>();   
    PlayerInteractS.fairyTalk += Talk;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
