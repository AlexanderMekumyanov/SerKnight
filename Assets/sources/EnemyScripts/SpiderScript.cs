using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderScript : BaseAIScript
{
    public float attackJumpDistance;

    private bool start = true;
    private bool Attacking = false;

    public float preAttackTime;
    private float preAttackTimer;

    public int health;

    private bool prevGrounded = true;

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

        if (grounded && Attacking)
        {
            Attacking = false;
            StopAnimation("Attack");
        }
        prevGrounded = grounded;
    }

    void AttackUpdate()
    {
        PlayAnimation("Attack");
    }

    public void Attack()
    {
        preAttackTimer = preAttackTime;
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
                    Attacking = true;
                    preAttackTimer = preAttackTime;
                }
            }
            else
            {
                AttackUpdate();
            }
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
