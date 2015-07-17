using UnityEngine;
using System;
using System.Collections.Generic;


public abstract class Actor : MonoBehaviour//, IAnimationActor, IMovableActor, IScriptableActor
{
    public delegate void Action();
    public LayerMask whatIsGround;
}
