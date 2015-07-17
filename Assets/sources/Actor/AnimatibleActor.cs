using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class AnimatibleActor : ScriptableActor, IAnimationActor
{
    public Animator myAnimator { get; set; }
    public List<string> Animations { get; set; }

    public virtual void InitAnimations()
    {
        Animations = new List<string>();
        myAnimator = gameObject.GetComponent<Animator>();
    }

    public virtual void PlayAnimation(string animationName)
    {
        myAnimator.SetBool(animationName, true);
    }

    public virtual void StopAnimation(string animationName)
    {
        myAnimator.SetBool(animationName, false);
    }

    public virtual void StopAllAnimation()
    {
        for (int i = 0; i < Animations.Count; i++)
        {
            myAnimator.SetBool(Animations[i], false);
        }
    }
}