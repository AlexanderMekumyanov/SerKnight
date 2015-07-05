using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum Direction
{
    RIGHT,
    LEFT
}

public abstract class PhysicableActor : MovableActor, IPhysicableActor
{
    public float maxSpeed;
    public float curSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    protected CircleCollider2D physicsCircle;
    protected float physicsCircleRadius;
    protected Vector2 physicsCirclePos;

    protected bool grounded = false;
    protected Rigidbody2D rigidBody;
    protected Direction direction;

    public void PhysicsUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    public void Move()
    {

    }

    public void InitPhysics()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public Direction GetDirection
    {
        get
        {
            return direction;
        }
    }
}