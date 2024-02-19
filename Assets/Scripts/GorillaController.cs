using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gorilla : Animal 
    {
        public Gorilla(string name, int age, string species) : base(name, age, species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public override void MakeSound()
        {
            Debug.Log("Grumblebuns packs a vicious roar!"); 
        }
    }

    public class GorillaController : MonoBehaviour 
    {
        public Transform[] patrolPoints;
        public int targetPoint;
        public float speed;
        private Animator animator;
        Gorilla myGorilla; 

       
        void Start()
        {
            targetPoint = 0;
            animator = GetComponent<Animator>();
            myGorilla = new Gorilla("Grumblebuns", 20, "Gorilla"); // Changed Lion's info to Gorilla's info
        }

        
        void Update()
        {
            Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;

            if (transform.position == patrolPoints[targetPoint].position)
            {
                increaseTargetInt();
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

            
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }

        void increaseTargetInt()
        {
            targetPoint++;
            if (targetPoint >= patrolPoints.Length)
            {
                targetPoint = 0;
            }
        }
    }
}
