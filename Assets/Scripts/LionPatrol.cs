using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Lion : Animal
    {
        public Lion(string name, int age, string species) : base(name, age, species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public override void MakeSound()
        {
            Debug.Log("Alex is all Roar no Bite");
        }
    }

    public class LionPatrol : MonoBehaviour
    {
        public Transform[] patrolPoints;
        public int targetPoint;
        public float speed;
        private Animator animator;
        Lion myLion;
        // Start is called before the first frame update
        void Start()
        {
            targetPoint = 0;
            animator = GetComponent<Animator>();
            myLion = new Lion("Alex", 15, "Lion");
        }

        // Update is called once per frame
        void Update()
        {

            Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;

            if (transform.position == patrolPoints[targetPoint].position)
            {
                increaseTargetInt();
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

            // Update animator parameters based on movement direction
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
