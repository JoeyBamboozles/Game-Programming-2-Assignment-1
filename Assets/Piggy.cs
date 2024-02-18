using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    #region RegionName
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
        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.Find("Player").GetComponent<Transform>();
            animator = GetComponent<Animator>();
            myPiggy = new Piggy("Bob", 13, "Equine");
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
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                myPiggy.MakeSound();
                myPiggy.Display();
                isInProximity = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                myPiggy.MakeSound();
                isInProximity = false;
                myPiggy.Display();
            }
        }
    }






















}



