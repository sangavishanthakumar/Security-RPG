using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private Vector3 direction;

    public Animator animator;

    private void Update()
    {
        // get key input
        float horizontal = Input.GetAxisRaw("Horizontal"); // left right
        float vertical = Input.GetAxisRaw("Vertical"); // up down

        direction = new Vector3(horizontal, vertical, 0);

        // move the player
        this.transform.position += direction.normalized * speed * Time.deltaTime;

        AnimateMovement(direction);

    }

    private void FixedUpdate()
    {
        // move the player
        this.transform.position += direction.normalized * speed * Time.deltaTime;
    }

    // animate player 
    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            // check if the player is moving
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
