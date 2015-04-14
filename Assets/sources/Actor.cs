using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Actor : MonoBehaviour, IAnimationActor, IMovableActor, IScriptableActor
{
    public bool ScriptFlag { get; set; }
    public string ScriptCommand { get; set; }
    public string[] ArrayOfParameter { get; set; }

    public Vector2 StartPos { get; set; }
    public Vector2 DestPos { get; set; }

    public Animator Animator { get; set; }
    public List<string> Animations { get; set; }

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        ScriptFlag = true;
        ScriptCommand = scriptParameter.ScriptCommand;
        ArrayOfParameter = scriptParameter.ArrayOfParameter;
    }

    public virtual void Move(Vector2 destPos, float delatTime)
    {
    }

    public virtual void InitAnimations()
    {
    }

    public virtual void PlayAnimation(string animationName)
    {
        Animator.SetBool(animationName, true);
    }

    public virtual void StopAllAnimation()
    {
        for (int i = 0; i < Animations.Count; i++)
        {
            Animator.SetBool(Animations[i], false);
        }
    }
}
