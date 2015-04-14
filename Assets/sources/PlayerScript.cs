using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : Actor
{
    public float     maxSpeed     = 10f;
    public float     curSpeed     = 0.0f;
    public float     jumpForce    = 700f;
    public Transform groundCheck;
    public float     groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float     move;

    private bool        grounded = false;
    private Rigidbody2D rigidBody;
    private Skeleton    skeleton;
    private Direction   direction;
    
    private enum Direction
    {
        RIGHT,
        LEFT
    }

    void Start()
    {
        rigidBody  = GetComponent<Rigidbody2D>();
        skeleton   = GameObject.Find("Skeleton").GetComponent<Skeleton>();
        direction  = Direction.RIGHT;
        ScriptFlag = false;
        InitAnimations();
    }

    void InitAnimations()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animations = new List<string>();
        Animations.Add("Yeah");
        Animations.Add("Walk");
    }
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Update()
    {
        if (!ScriptFlag)
        {
            BaseLogic();
        }
        else
        {
            ScriptLogic();
        }
        
    }

    void BaseLogic()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayAnimation("Yeah");
        }
        else 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayAnimation("Walk");
            curSpeed = maxSpeed;
            if (direction == Direction.LEFT)
            {
                Flip();
                direction = Direction.RIGHT;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayAnimation("Walk");
            curSpeed = -maxSpeed;
            if (direction == Direction.RIGHT)
            {
                Flip();
                direction = Direction.LEFT;
            }
        }
        else
        {
            StopAllAnimation();
            curSpeed = 0.0f;
        }
        rigidBody.velocity = new Vector2(curSpeed, rigidBody.velocity.y);
    }

    void ScriptLogic()
    {
        switch (ScriptCommand)
        {
            case "Yeah":
            {
                //animator.SetBool("Walk", false);
                //animator.SetBool("Yeah", true);
                StopAllAnimation();
                PlayAnimation("Yeah");
                break;
            }
        }
    }

    void Flip()
    {
        skeleton.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
    }

    public void StopScript()
    {
        ScriptFlag = false;
        Animator.SetBool("Yeah", false);
    }
}
