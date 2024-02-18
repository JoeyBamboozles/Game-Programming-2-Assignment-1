using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

    public AudioSource theLion;
    public AudioSource theGorilla;
    public AudioSource theHorse;
    public AudioSource thePig;
    public string theAnimal;

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

        if (theAnimal == "Gorilla" && Input.GetKeyDown(KeyCode.F))
        {
            theGorilla.Play();
        }
        else if (theAnimal == "Lion" && Input.GetKeyDown(KeyCode.F))
        {
            theLion.Play();
        }
        else if (theAnimal == "Horse" && Input.GetKeyDown(KeyCode.F))
        {
            theHorse.Play();
        }
        else if (theAnimal == "Pig" && Input.GetKeyDown(KeyCode.F))
        {
            thePig.Play();
        }

    }
    private void Move()
    {
        Vector2 movement = new Vector2(moveMent.x, moveMent.y).normalized * moveSpeed * Time.deltaTime;
        // Apply movement
        transform.Translate(movement);
        //  Debug.Log("Movement: " + moveMent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gorilla")
        {
            Debug.Log("Colliding with Gorilla");
            theAnimal = "Gorilla";
        }
        else if (collision.gameObject.tag == "Horse")
        {
            Debug.Log("Colliding with Horse");
            theAnimal = "Horse";
        }
        else if (collision.gameObject.tag == "Lion")
        {
            Debug.Log("Colliding with Horse");
            theAnimal = "Lion";
        }
        else if (collision.gameObject.tag == "Pig")
        {
            Debug.Log("Colliding with Pig");
            theAnimal = "Pig";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
