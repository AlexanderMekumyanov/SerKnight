using UnityEngine;
using System;

interface IMovableActor
{
    Vector2 StartPos { get; set; }
    Vector2 DestPos { get; set; }

    void Move(Vector2 destPos, float delayTime);
}
