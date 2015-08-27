using UnityEngine;
using System;
using System.Collections.Generic;

public enum States
{
    IDLE,
    ATTACK_BEGIN,
    JUMP_BEGIN,
    JUMP,
    SLEEP,
    ATTACK,
    MOVING,
    FINDING_ENEMY,
    ATTACKING,
    ATTACK_END,
    DEATH,
    DEATH_END,
    DAMAGING
}

public abstract class Actor : MonoBehaviour//, IAnimationActor, IMovableActor, IScriptableActor
{
    public delegate void Action();
    private States curState = States.SLEEP;

    public void SetState(States newState)
    {
        curState = newState;
        Debug.Log(curState.ToString());
    }

    public States GetCurrState()
    {
        return curState;
    }
}
