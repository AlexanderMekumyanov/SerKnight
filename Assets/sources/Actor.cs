using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Actor : MonoBehaviour, IAnimationActor, IMovableActor, IScriptableActor
{
    public bool ScriptFlag { get; set; }
    public string ScriptCommand { get; set; }
    public string[] ArrayOfParameter { get; set; }

    public Vector3 StartPos { get; set; }
    public Vector3 DestPos { get; set; }
    public bool    IsMoving { get; set; }
    public float   TimeMoving { get; set; }
    public float   TimerMoving { get; set; }

    public Animator Animator { get; set; }
    public List<string> Animations { get; set; }
    public delegate void Action();

    public void ReceiveScriptFlag(ScriptParameter scriptParameter)
    {
        ScriptFlag = true;
        ScriptCommand = scriptParameter.ScriptCommand;
        ArrayOfParameter = scriptParameter.ArrayOfParameter;
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

    public virtual void Move(Vector3 destPos, float delayTime)
    {
        IsMoving = true;
        DestPos = destPos;
        TimeMoving = delayTime;
        TimerMoving = 0;
        StartPos = transform.position;
    }

    public virtual void MoveUpdate()
    {
        TimerMoving += Time.deltaTime;
        if (TimerMoving > TimeMoving)
        {
            this.transform.position = new Vector3(DestPos.x, DestPos.y, DestPos.z);
            IsMoving = false;
        }
        else
        {
            float p = TimerMoving / TimeMoving;
            this.transform.position = new Vector3(DestPos.x * p + StartPos.x * (1.0f - p), DestPos.y * p + StartPos.y * (1.0f - p), DestPos.z * p + StartPos.z * (1.0f - p));
        }
    }
}
