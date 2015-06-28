using UnityEngine;
using System;
public enum MovingType
{
    Lerp,
    MoveTowards,
    Slerp
}
interface IMovableActor
{
    Vector3    StartPos { get; set; }
    Vector3    DestPos { get; set; }
    bool       IsMoving { get; set; }
    float      TimeMoving { get; set; }
    float      TimerMoving { get; set; }
    MovingType movingType {get; set;}
    float      speed { get; set; }

    void Move(Vector3 destPos, MovingType movingType, float delayTime);
    void Move(Vector3 destPos, float speed);
    void MoveUpdate();
}
