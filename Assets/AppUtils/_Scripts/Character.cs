using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class Character : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    public Rigidbody Rb
    {
        get
        {
            return rb;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
}
