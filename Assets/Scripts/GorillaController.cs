using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaController : MonoBehaviour
{
    public float moveSpeed = 2.50f; 
    public float distanceBeforeTurn = 7.50f; 
    public Rigidbody2D rb;
    public Animator animator;

    
    private Vector2[] moveDirections = { Vector2.right, Vector2.down, Vector2.left, Vector2.up };
    private int currentDirectionIndex = 0;
    private Vector2 currentTarget;

    void Start()
    {
        
        currentTarget = rb.position + moveDirections[currentDirectionIndex] * distanceBeforeTurn;
    }

    void FixedUpdate()
    {
        
        Vector2 movementDirection = (currentTarget - rb.position).normalized;

        
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);

        
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.magnitude);

       
        if (Vector2.Distance(rb.position, currentTarget) <= 0.1f)
        {
            currentDirectionIndex = (currentDirectionIndex + 1) % moveDirections.Length;

            
            currentTarget = rb.position + moveDirections[currentDirectionIndex] * distanceBeforeTurn;
        }
    }
}

