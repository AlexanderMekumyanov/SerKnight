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
                if (IsWithinReach(playerScript.gameObject, attackJumpDistance))
                {
                    SetState(States.ATTACK_BEGIN);
                    playerDestDirection = playerScript.transform.position.x - this.transform.position.x;
                    myAnimator.SetBool("Moving", false);
                }
                else
                {
                    MovingTo(playerScript.gameObject);
                    myAnimator.SetBool("Moving", true);
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
                break;
            }
            case States.ATTACK:
            {
                Attack();
                break;
            }
            case States.ATTACKING:
            {
                break;
            }
            case States.ATTACK_END:
            {
                if (grounded)
                {
                    SetState(States.FINDING_ENEMY);
                }
                break;
            }
            case States.DEATH:
            {
                break;
            }
            case States.DEATH_END:
            {
                Destroy(gameObject);
                SetState(States.SLEEP);
                break;
            }
            case States.DAMAGING:
            {
                break;
            }
        }
    }

    public override void Damaging()
    {
       // Debug.Log("---------------DAMAGING---------------");
        if (--health <= 0)
        {
            myAnimator.SetTrigger("Death");
            SetState(States.DEATH);
        }
        else
        {
            myAnimator.SetTrigger("Damaging");
            SetState(States.DAMAGING);
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
        Debug.Log(curState.ToString());
    }
}
