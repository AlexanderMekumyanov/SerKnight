using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderBoss : BaseAIScript 
{
    public float canAttackDistance;

    public bool isWake = false;

    void Start () 
    {
        states = new Dictionary<string, bool>();

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
        if (!isWake)
        {
            return;
        }

        if (GetCurrState("Idle"))
        {
            PlayAnimation("Idle");
        }

        if (GetCurrState("AttackEnd"))
        {
            PlayAnimation("AttackEnd");
            SetCurrState("AttackEnd", false);
        }
        else if (!GetCurrState("crying"))
        {
            PlayAnimation("Cry");
            SetCurrState("crying", true);
        }
        else
        {
            //if (MovingToPlayer(canAttackDistance, "Moving"))
            //{
            //    Attacking();
            //}
        }
	}

    void Appearance()
    {
        
    }

    void Attacking()
    {
        myAnimator.SetTrigger("Attack");
    }

    void AttackEnd()
    {
    }

    public void WakePlease()
    {
        isWake = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void SleepPlease()
    {
        isWake = false;
    }
}
