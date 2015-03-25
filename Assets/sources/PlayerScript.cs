using UnityEngine;
using System.Collections;

public class PlayerScript : GameObjectBase 
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
    private Animator    animator;
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
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Walk", true);
            curSpeed = maxSpeed;
            if (direction == Direction.LEFT)
            {
                Flip();
                direction = Direction.RIGHT;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk", true);
            curSpeed = -maxSpeed;
            if (direction == Direction.RIGHT)
            {
                Flip();
                direction = Direction.LEFT;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            curSpeed = 0.0f;
        }
        rigidBody.velocity = new Vector2(curSpeed, rigidBody.velocity.y);
        Debug.Log("curSpeed = " + curSpeed);
    }

    void Flip()
    {
        skeleton.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
    }     
}
