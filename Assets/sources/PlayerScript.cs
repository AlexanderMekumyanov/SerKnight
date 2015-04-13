using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : GameObjectBase, IMovableActor, IAnimationActor
{
    public float     maxSpeed     = 10f;
    public float     curSpeed     = 0.0f;
    public float     jumpForce    = 700f;
    public Transform groundCheck;
    public float     groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float     move;
    // TODO Переписать нахрен
    public List<string> animations
    {
        get
        {
            return animations;
        }
        set
        {
            animations = value;
        }
    }

    public Animator animator
    {
        get
        {
            return animator;
        }
        set
        {
            animator = value;
        }
    }

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
        animator   = GetComponent<Animator>();
        skeleton   = GameObject.Find("Skeleton").GetComponent<Skeleton>();
        direction  = Direction.RIGHT;
        scriptFlag = false;
    }
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void Update()
    {
        if (!scriptFlag)
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
            //animator.SetBool("Yeah", true);
            //animator.SetBool("Walk", false);
        }
        else 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //animator.SetBool("Walk", true);
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
            //animator.SetBool("Walk", true);
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
            //animator.SetBool("Walk", false);
            curSpeed = 0.0f;
        }
        rigidBody.velocity = new Vector2(curSpeed, rigidBody.velocity.y);
    }

    void ScriptLogic()
    {
        switch (scriptCommand)
        {
            case "Yeah":
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Yeah", true);
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
        scriptFlag = false;
        animator.SetBool("Yeah", false);
    }

    public void PlayAnimation(string AnimName)
    {
        for (int i = 0; i < animations.Count; i++)
        {
            animator.SetBool(animations[i], false);
        }

        animator.SetBool(AnimName, true);
    }

    public void Move(Vector2 destPos)
    {

    }

    public void StopAllAnimation()
    {
        for (int i = 0; i < animations.Count; i++)
        {
            animator.SetBool(animations[i], false);
        }
    }
}
