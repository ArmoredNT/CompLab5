using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour
{
    public Animator animator;
    public bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            // toggle if any key is pressed
            isWalking = !isWalking;
            animator.SetBool("isWalking", isWalking);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isWalking = false;
        print(isWalking);
    }
}
