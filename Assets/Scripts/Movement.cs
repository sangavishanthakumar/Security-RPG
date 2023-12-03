using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private void Update()
    {
        // get key input
        float horizontal = Input.GetAxisRaw("Horizontal"); // left right
        float vertical = Input.GetAxisRaw("Vertical"); // up down

        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;

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
