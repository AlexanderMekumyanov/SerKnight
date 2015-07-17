using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderBoss : BaseAIScript 
{
    public float canAttackDistance;

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
        if (GetCurrState("AttackEnd"))
        {
            PlayAnimation("AttackEnd");
            SetCurrState("AttackEnd", false);
        }
        if (GetCurrState("Idle"))
        {
            PlayAnimation("Idle");
        }
        else if (!GetCurrState("crying"))
        {
            PlayAnimation("Cry");
            SetCurrState("crying", true);
        }
        else
        {
            if (MovingToPlayer(canAttackDistance, "Moving"))
            {
                Attacking();
            }
        }
	}

    void Appearance()
    {
        
    }

    void Attacking()
    {
        PlayAnimation("Attack");
    }

    void AttackEnd()
    {
    }


}
