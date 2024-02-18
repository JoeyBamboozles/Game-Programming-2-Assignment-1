using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal
{
    public Horse(string name, int age, string species) : base(name, age, species)
    {
        this.Name = name;
        this.Age = age;
        this.Species = species;
    }
    public override void MakeSound()
    {
        Debug.Log("The horse neighs: ");
    }
    public override void Display()
    {
        Debug.Log($"Name: {Name}, Age: {Age}, Species: Horse");
    }
}

public class HorseCont : MonoBehaviour
{
    private Transform target;
    public float speed;
    private Vector2 movement;
    private Animator animator;
    Horse myHorse;
    private bool isInProximity = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        myHorse = new Horse("Bob", 13, "Equine");
    }
    // Update is called once per frame
    void Update()
    {
        if (isInProximity == true)
        {
            movement.x = transform.position.x;
            movement.y = transform.position.y;
            animator.SetFloat("MoveY", movement.x);
            animator.SetFloat("MoveX", movement.y);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", 0);
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myHorse.MakeSound();
            myHorse.Display();
            isInProximity = true;
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            myHorse.MakeSound();
            isInProximity = false;
            myHorse.Display();
        }
    }

}
