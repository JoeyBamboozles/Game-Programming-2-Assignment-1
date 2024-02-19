using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        public class PiggyController : MonoBehaviour
    {
        private Transform target;
        public float speed;
        private Vector2 movement;
        private Animator animator;
        private bool isInProximity = false;
        public Transform[] patrolPoints;
        public int targetPoint;
        IInteractable theInteraction = new InteractionClass();

    // Start is called before the first frame update
    void Start()
        {
            // target = GameObject.Find("Player").GetComponent<Transform>();
            animator = GetComponent<Animator>();
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



