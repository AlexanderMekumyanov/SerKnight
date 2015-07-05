using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogScripts : PhysicableActor
{
    public PlayerScript playerScript;
    public float playerBehindDistance;

    private bool start = false;

    void Start()
    {
        InitPhysics();

        InitAnimations();
    }

    public override void InitAnimations()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animations = new List<string>();
        Animations.Add("Moving");
    }

    public void WakeUp()
    {
        start = true;
    }

    void FixedUpdate()
    {
        PhysicsUpdate();
    }

    void MovingToPlayerBehind()
    {
        float deltaX = playerScript.transform.position.x - this.transform.position.x;

        if (System.Math.Abs(deltaX) < playerBehindDistance + 2)
        {
            if (deltaX > 0)
            {
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, this.transform.rotation.w);
            }
            else
            {
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 180, this.transform.rotation.z, this.transform.rotation.w);
            }
            return;
        }

        Vector3 destPos;

        if (playerScript.GetDirection == Direction.RIGHT)
        {
            destPos = new Vector3(playerScript.transform.position.x - playerBehindDistance - maxSpeed * Time.deltaTime, playerScript.transform.position.y, playerScript.transform.position.z);
        }
        else
        {
            destPos = new Vector3(playerScript.transform.position.x + playerBehindDistance - maxSpeed * Time.deltaTime, playerScript.transform.position.y, playerScript.transform.position.z);
        }

        Move(destPos, MovingType.MoveTowards, maxSpeed);
        MoveUpdate();
    }

    void Update()
    {
        if (start)
        {
            MovingToPlayerBehind();
        }
    }
}
