using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderScript : BaseAIScript
{
    public float attackJumpDistance;

    public int health = 3;

    private float playerDestDirection;

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
        curState = States.FINDING_ENEMY;
    }

    public void Attack()
    {
       // Debug.Log("---------------ATTACK---------------");
        SetState(States.ATTACKING);
        if (playerDestDirection < 0)
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
        if (curState == States.SLEEP)
        {
            return;
        }

        PhysicsUpdate();
        myAnimator.SetBool("Grounded", grounded);

        switch (curState)
        {
            case States.SLEEP:
            {
                break;
            }
            case States.FINDING_ENEMY:
            {
                if (MovingToPlayer(attackJumpDistance, "Moving"))
                {
                    curState = States.ATTACK_BEGIN;
                    playerDestDirection = playerScript.transform.position.x - this.transform.position.x;
                }
                break;
            }
            case States.ATTACK_BEGIN:
            {
                myAnimator.SetTrigger("Attack_begin");
                break;
            }
            case States.IDLE:
            {
                myAnimator.SetBool("Idle", true);
                break;
            }
            case States.ATTACK:
            {
                Attack();
                break;
            }
            case States.ATTACK_END:
            {
                if (grounded)
                {
                    curState = States.FINDING_ENEMY;
                }
                break;
            }
            case States.DEATH:
            {
                myAnimator.SetTrigger("Death");
                break;
            }
            case States.DEATH_END:
            {
                Destroy(gameObject);
                break;
            }
        }

        Debug.Log(curState.ToString());
    }

    public override void Damaging()
    {
       // Debug.Log("---------------DAMAGING---------------");
        myAnimator.SetTrigger("Damaging");
        if (--health <= 0)
        {
            curState = States.DEATH;
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

    public void SetState(States newState)
    {
        curState = newState;
    }
}
