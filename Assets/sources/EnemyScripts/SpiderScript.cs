using UnityEngine;
using System.Collections;

public class SpiderScript : PhysicableActor
{
    public PlayerScript playerScript;
    public float attackJumpDistance;

    private bool start = false;
    private bool Attacking = false;

    public float preAttackTime;
    private float preAttackTimer;

    private bool prevGrounded = true;

	void Start () 
    {
        InitPhysics();
	}

    public void WakeUp()
    {
        start = true;    
    }

    void FixedUpdate()
    {
        PhysicsUpdate();

        if (!prevGrounded && grounded && Attacking)
        {
            Attacking = false;
        }
        prevGrounded = grounded;
    }

    void AttackUpdate()
    {
        if (preAttackTimer > 0)
        {
            preAttackTimer -= Time.deltaTime;
        }
        else
        {
            preAttackTimer = preAttackTime;
            float deltaX = playerScript.transform.position.x - this.transform.position.x;
            if (deltaX < 0)
            {
                rigidBody.AddForce(new Vector2(-jumpForce, jumpForce));
            }
            else
            {
                rigidBody.AddForce(new Vector2(jumpForce, jumpForce));
            }
        }
    }

    void MovingToPlayer()
    {
        float deltaX = playerScript.transform.position.x - this.transform.position.x;
        if (Mathf.Abs(deltaX) < attackJumpDistance)
        {
            Attacking = true;
            preAttackTimer = preAttackTime;
        }
        else
        {
            Move(playerScript.transform.position, MovingType.MoveTowards, Mathf.Abs(deltaX) / maxSpeed);
            MoveUpdate();
        }
    }
	
	void Update () 
    {
        if (!start)
        {
            return;
        }
        if (grounded)
        {
            if (!Attacking)
            {
                MovingToPlayer();
            }
            else
            {
                AttackUpdate();
            }
        }
    }
}
