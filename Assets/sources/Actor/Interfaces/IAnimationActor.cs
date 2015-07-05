﻿using UnityEngine;
using System;
using System.Collections.Generic;

interface IAnimationActor
{
    Animator myAnimator { get; set; }

    List<string> Animations{ get; set;}

    void InitAnimations();
    void PlayAnimation(string animationName);
    void StopAnimation(string animationName);
    void StopAllAnimation();
}
