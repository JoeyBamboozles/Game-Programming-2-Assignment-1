using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Piggy : Animal
    {
        public Piggy(string name, int age, string species) : base(name, age, species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public override void MakeSound()
        {
            Debug.Log("The piggy goes Oink!: ");
        }
    }

    public class PiggyController : MonoBehaviour
    {
        private Transform target;
        public float speed;
        private Vector2 movement;
        private Animator animator;
        Piggy myPiggy;
        private bool isInProximity = false;
        public Transform[] patrolPoints;
        public int targetPoint;

        // Start is called before the first frame update
        void Start()
        {
            // target = GameObject.Find("Player").GetComponent<Transform>();
            animator = GetComponent<Animator>();
            myPiggy = new Piggy("Tom", 13, "Piglet");
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
    }

}

