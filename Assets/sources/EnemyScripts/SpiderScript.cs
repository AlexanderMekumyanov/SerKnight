using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderScript : BaseAIScript
{
    public float attackJumpDistance;

    private bool start = true;
    private bool Attacking = false;

    public int health = 3;

	void Start () 
    {
        InitPhysics();

        InitAnimations();
	}

    public override void InitAnimations()
    {
        base.InitAnimations();
        Animations.Add("Attack");
        Animations.Add("Moving");
    }

    public void WakeUp()
    {
        start = true;    
    }

    void FixedUpdate()
    {
        PhysicsUpdate();

        myAnimator.SetBool("Grounded", grounded);
    }

    public void Attack()
    {
        float deltaX = playerScript.transform.position.x - this.transform.position.x;
        if (deltaX < 0)
        {
            rigidBody.AddForce(new Vector2(-jumpForce, jumpForce));
        }
        else
        {
            rigidBody.AddForce(new Vector2(jumpForce, jumpForce));
        }
    }
	
	void Update () 
    {
        if (!start)
        {
            return;
        }
        if (grounded)
        {
            if (!Attacking)
            {
                if (MovingToPlayer(attackJumpDistance, "Moving"))
                {
                    myAnimator.SetTrigger("Attack");
                    Attacking = true;
                }
            }
        }
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Attacking = false;
        }
    }

    public void Damaging()
    {
        if (--health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float deltaX = playerScript.transform.position.x - this.transform.position.x;
            if (deltaX < 0)
            {
                rigidBody.AddForce(new Vector2(jumpForce, 0));
            }
            else
            {
                rigidBody.AddForce(new Vector2(-jumpForce, 0));
            }
        }
    }
}
