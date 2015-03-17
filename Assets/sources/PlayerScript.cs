using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    public float     maxSpeed     = 10f;
    public float     jumpForce    = 700f;
    public Transform groundCheck;
    public float     groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float     move;

    private bool        facingRight = true;
    private bool        grounded = false;
    private Rigidbody2D rigidBody;
    private Animator    animator;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator  = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        move     = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        //facingRight          = !facingRight;
        //Vector3 theScale     = transform.localScale;
        //theScale.x          *= -1;
        //transform.localScale = theScale;
    }     
}
