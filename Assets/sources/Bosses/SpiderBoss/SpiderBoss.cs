using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderBoss : BaseAIScript 
{
    public float attackDistance;

    void Start () 
    {
        InitAnimations();
	}

    public override void InitAnimations()
    {
        base.InitAnimations();
        Animations.Add("Moving");
        Animations.Add("Idle");
        Animations.Add("Attack");
    }

    void Update () 
    {
        PhysicsUpdate();

        switch (GetCurrState())
        {
            case States.FINDING_ENEMY:
            {
                if (IsWithinReach(playerScript.gameObject, attackDistance))
                {
                    //SetState(States.ATTACK_BEGIN);
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
                myAnimator.SetBool("Moving", false);
                myAnimator.SetTrigger("Attack");
                SetState(States.ATTACKING);
                break;
            }
            case States.ATTACKING:
            {
                break;
            }
            case States.ATTACK_END:
            {
                SetState(States.FINDING_ENEMY);
                break;
            }
            case States.DEATH:
            {
                break;
            }
            case States.DEATH_END:
            {
                Destroy(gameObject);
                break;
            }
        }
	}

    public void WakePlease()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        SetState(States.FINDING_ENEMY);
    }

    public override void Damaging()
    {
        Debug.Log("----SPIDERBOSS_DAMAGING----");
        if (--health <= 0)
        {
            myAnimator.SetTrigger("Death");
            SetState(States.DEATH);
        }
    }

    public void Attack()
    {
        if (GetCurrState() != States.ATTACKING)
        {
            SetState(States.ATTACK_BEGIN);
        }
    }
}
