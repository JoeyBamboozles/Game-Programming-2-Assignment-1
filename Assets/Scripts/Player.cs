using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Animator component reference
    private Animator animator;
    // Input variables
    private float horizontalInput;
    private float verticalInput;
    // Speed and rotation variables
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    Vector2 moveMent;
    Rigidbody2D rb;
    private void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Get player input
        moveMent.x = Input.GetAxisRaw("Horizontal");
        // Debug.Log("X: " + moveMent.x);
        moveMent.y = Input.GetAxisRaw("Vertical");
        // Debug.Log("Y: " + moveMent.y);
        // Set animator parameters based on input
        animator.SetFloat("MoveY", moveMent.x);
        animator.SetFloat("MoveX", moveMent.y);
        // Move the player
        Move();
        // Rotate();
    }
    private void Move()
    {
        Vector2 movement = new Vector2(moveMent.x, moveMent.y).normalized * moveSpeed * Time.deltaTime;
        // Apply movement
        transform.Translate(movement);
        //  Debug.Log("Movement: " + moveMent);
    }
}
