using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogScripts : BaseAIScript
{
    public float playerBehindDistance;

    void Start()
    {
        InitPhysics();

        InitAnimations();

        SetState(States.SLEEP);
    }

    public override void InitAnimations()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        Animations = new List<string>();
        Animations.Add("Moving");
    }

    public void WakeUp()
    {
        SetState(States.MOVING);
    }

    void FixedUpdate()
    {
        PhysicsUpdate();
    }

    void Update()
    {
        switch(GetCurrState())
        {
            case States.MOVING:
            {
                MovingToPlayerBehind(playerBehindDistance);
                break;
            }
        }
    }
}
