using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator Animator { get; protected set; }
    public Rigidbody2D Rigidbody { get; private set;}

    protected virtual void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponentInChildren<Rigidbody2D>();
    }
}

