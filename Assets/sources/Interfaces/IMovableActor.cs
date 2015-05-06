using UnityEngine;
using System;

interface IMovableActor
{
    Vector3 StartPos { get; set; }
    Vector3 DestPos { get; set; }
    bool    IsMoving { get; set; }
    float   TimeMoving { get; set; }
    float   TimerMoving { get; set; }

    void Move(Vector3 destPos, float delayTime);
    void MoveUpdate();
}
