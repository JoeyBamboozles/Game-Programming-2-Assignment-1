using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro; // Add this line to use TextMeshPro

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

    public TextMeshProUGUI gorillaText;
    public TextMeshProUGUI lionText;
    public TextMeshProUGUI horseText;
    public TextMeshProUGUI pigText;

    private bool isFKeyPressed = false;

    private void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Make the TextMeshPro UIs invisible at the start
        gorillaText.gameObject.SetActive(false);
        lionText.gameObject.SetActive(false);
        horseText.gameObject.SetActive(false);
        pigText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Get player input
        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");
        // Set animator parameters based on input
        animator.SetFloat("MoveY", moveMent.x);
        animator.SetFloat("MoveX", moveMent.y);
        // Move the player
        Move();

        // Check if F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFKeyPressed = true;
            PlayAnimalSound();
        }
    }

    private void PlayAnimalSound()
    {
        // Play animal sound based on theAnimal
        switch (theAnimal)
        {
            case "Gorilla":
                theGorilla.Play();
                gorillaText.gameObject.SetActive(false); // Hide text after F key is pressed
                break;
            case "Lion":
                theLion.Play();
                lionText.gameObject.SetActive(false); // Hide text after F key is pressed
                break;
            case "Horse":
                theHorse.Play();
                horseText.gameObject.SetActive(false); // Hide text after F key is pressed
                break;
            case "Pig":
                thePig.Play();
                pigText.gameObject.SetActive(false); // Hide text after F key is pressed
                break;
        }
    }

    private void Move()
    {
        Vector2 movement = new Vector2(moveMent.x, moveMent.y).normalized * moveSpeed * Time.deltaTime;
        // Apply movement
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Set theAnimal based on collision
        if (!isFKeyPressed)
        {
            switch (collision.gameObject.tag)
            {
                case "Gorilla":
                    theAnimal = "Gorilla";
                    gorillaText.gameObject.SetActive(true); // Show text when colliding with Gorilla
                    break;
                case "Lion":
                    theAnimal = "Lion";
                    lionText.gameObject.SetActive(true); // Show text when colliding with Lion
                    break;
                case "Horse":
                    theAnimal = "Horse";
                    horseText.gameObject.SetActive(true); // Show text when colliding with Horse
                    break;
                case "Pig":
                    theAnimal = "Pig";
                    pigText.gameObject.SetActive(true); // Show text when colliding with Pig
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset isFKeyPressed when exiting the trigger
        isFKeyPressed = false;

        // Make all TextMeshPro UIs invisible when not colliding
        gorillaText.gameObject.SetActive(false);
        lionText.gameObject.SetActive(false);
        horseText.gameObject.SetActive(false);
        pigText.gameObject.SetActive(false);
    }
}