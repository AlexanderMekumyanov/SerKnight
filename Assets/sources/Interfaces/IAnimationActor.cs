using UnityEngine;
using System;
using System.Collections.Generic;

interface IAnimationActor
{
    Animator animator
    {
        get;
        set;
    }

    List<string> animations
    {
        get; 
        set;
    }

    void InitAnimations();
    void PlayAnimation(string animationName);
    void StopAllAnimation();
}
