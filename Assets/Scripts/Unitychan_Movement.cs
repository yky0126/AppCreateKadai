using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychan_Movement : MonoBehaviour
{
    public AudioClip Clip;
    Animator animator;
    float horizontalMove;
    float verticalMove;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void AnimationUpdate()
    {
        if (horizontalMove == 0 && verticalMove == 0)
        {
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        AnimationUpdate();

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0.0f, 0.0f, 0.05f);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0.0f, 0.0f, -0.05f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -1.0f, 0.0f);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
        }
        ////////  Voice Clip ////////
        if(Input.GetKey(KeyCode.Space))
        {
            AudioSource audio_source = gameObject.GetComponent<AudioSource>();
            audio_source.PlayOneShot(Clip);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            animator.SetBool("isWin", true);
        }
        else if(other.tag == "Enemy")
        {
            animator.SetBool("isLose", true);
        }
    }
}
