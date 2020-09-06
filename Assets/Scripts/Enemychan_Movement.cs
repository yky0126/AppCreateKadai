using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemychan_Movement : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalk", false);
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.destination != target.transform.position)
        {
            animator.SetBool("isWalk", true);
            nav.SetDestination(target.transform.position);
        }
        else
        {
            animator.SetBool("isWalk", false);
            nav.SetDestination(transform.position);
        }
    }
}
