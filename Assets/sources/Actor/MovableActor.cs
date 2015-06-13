using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class MovableActor : AnimatibleActor, IMovableActor
{
    public Vector3 StartPos { get; set; }
    public Vector3 DestPos { get; set; }
    public bool IsMoving { get; set; }
    public float TimeMoving { get; set; }
    public float TimerMoving { get; set; }
    public MovingType movingType { get; set; }
    public float speed { get; set; }

    public virtual void Move(Vector3 destPos, MovingType movingType, float delayTime)
    {
        IsMoving = true;
        DestPos = destPos;
        TimeMoving = delayTime;
        TimerMoving = 0;
        StartPos = transform.localPosition;
        this.movingType = movingType;
    }

    public virtual void Move(Vector3 destPos, float speed)
    {

    }

    public virtual void MoveUpdate()
    {
        if (IsMoving)
        {
            switch (movingType)
            {
                case MovingType.Lerp:
                    {
                        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, DestPos, TimeMoving * Time.deltaTime);
                        break;
                    }
                case MovingType.MoveTowards:
                    {
                        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, DestPos, TimeMoving * Time.deltaTime);
                        break;
                    }
                case MovingType.Slerp:
                    {
                        this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, DestPos, TimeMoving * Time.deltaTime);
                        break;
                    }
            }

            if ((transform.localPosition - DestPos).magnitude < 0.2)
            {
                IsMoving = false;
            }
        }
    }
}