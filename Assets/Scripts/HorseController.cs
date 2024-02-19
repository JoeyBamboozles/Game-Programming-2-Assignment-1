using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    #region RegionName
public class Horse : Animal
{
    public Horse(string name, int age, string species) : base(name, age, species)
    {
        Name = name;
        Age = age;
        Species = species;
    }
    public override void MakeSound()
    {
        Debug.Log("The horse neighs: ");
    }
    //public override void Display()
    //{
    //    Debug.Log($"Name: {Name}, Age: {Age}, Species: Horse");
    //}
    }
#endregion
public class HorseController : MonoBehaviour
{
    private Transform target;
    public float speed;
    private Vector2 movement;
    private Animator animator;
    Horse myHorse;
    private bool isInProximity = false;
    public Transform[] patrolPoints;
    public int targetPoint;
    IInteractable theInteraction = new InteractionClass();

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        myHorse = new Horse("Bob", 13, "Equine");
    }

    void Update()
    {
        Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;

        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        // Update animator parameters based on movement direction
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }

} 




        


       



