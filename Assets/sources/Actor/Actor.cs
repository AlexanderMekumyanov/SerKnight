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
    DEATH_END
}

public abstract class Actor : MonoBehaviour//, IAnimationActor, IMovableActor, IScriptableActor
{
    public delegate void Action();
    protected States curState = States.SLEEP;
}
