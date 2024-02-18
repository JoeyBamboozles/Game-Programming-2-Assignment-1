using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaController : MonoBehaviour
{
    [SerializeField] public Transform[] patrolPoints;
    [SerializeField] public int targetPoint;
    [SerializeField] public float speed;
     private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
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