using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public bool isMoving;


    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate() {
        // If movement input is not 0 try to move
//        if (!isMoving) {
            if (movementInput.x != 0) movementInput.y = 0;

            if(movementInput != Vector2.zero) {
                animator.SetFloat("moveX", movementInput.x);
                animator.SetFloat("moveY", movementInput.y);
                
                bool success = TryMove(movementInput);

                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));

                    if(!success) {
                        success = TryMove(new Vector2(0, movementInput.y));     
                        
                    }
                }

//                animator.SetBool("isMoving", success);
                isMoving = true;
            } else {
//                animator.SetBool("isMoving", false);
                isMoving = false;
            }

            UpdateAnimation();

//        }

    }

    private bool TryMove(Vector2 direction) {
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collision
            movementFilter, // List of settings that determine what the raycast can collide into and what it will ignore
            castCollisions, // List of collisions that store the results of the raycast
            moveSpeed * Time.fixedDeltaTime + collisionOffset); // the amount to cast equal to the movement plus an offset

            if (count == 0) {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
            }
            else {
                return false;
            }
    }

    void UpdateAnimation() {
//        if(!animLocked && canMove) {
        if(movementInput != Vector2.zero) {
            animator.Play("player_walk");
        } else {
            animator.Play("player_idle");
        }
//        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
