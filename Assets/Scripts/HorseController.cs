using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{

    private Transform target;
    public float speed;
    private Vector2 movement;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = transform.position.x;
        movement.y = transform.position.y;

        animator.SetFloat("MoveY", movement.x);
        animator.SetFloat("MoveX", movement.y);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
