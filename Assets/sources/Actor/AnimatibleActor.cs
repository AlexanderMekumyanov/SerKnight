using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class AnimatibleActor : ScriptableActor, IAnimationActor
{
    public Animator Animator { get; set; }
    public List<string> Animations { get; set; }

    public virtual void InitAnimations()
    {
    }

    public virtual void PlayAnimation(string animationName)
    {
        Animator.SetBool(animationName, true);
    }

    public virtual void StopAnimation(string animationName)
    {
        Animator.SetBool(animationName, false);
    }

    public virtual void StopAllAnimation()
    {
        for (int i = 0; i < Animations.Count; i++)
        {
            Animator.SetBool(Animations[i], false);
        }
    }
}