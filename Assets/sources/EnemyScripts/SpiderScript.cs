using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderScript : PhysicableActor
{
    public PlayerScript playerScript;
    public float attackJumpDistance;

    private bool start = false;
    private bool Attacking = false;

    public float preAttackTime;
    private float preAttackTimer;

    public int health;

    private bool prevGrounded = true;

	void Start () 
    {
        InitPhysics();

        InitAnimations();
	}

    public override void InitAnimations()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        Animations = new List<string>();
        Animations.Add("Attack");
        Animations.Add("Moving");
    }

    public void WakeUp()
    {
        start = true;    
    }

    void FixedUpdate()
    {
        PhysicsUpdate();

        if (grounded && Attacking)
        {
            Attacking = false;
            StopAnimation("Attack");
        }
        prevGrounded = grounded;
    }

    void AttackUpdate()
    {
        PlayAnimation("Attack");
    }

    public void Attack()
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

    void MovingToPlayer()
    {
        float deltaX = playerScript.transform.position.x - this.transform.position.x;
        if (Mathf.Abs(deltaX) < attackJumpDistance)
        {
            Attacking = true;
            preAttackTimer = preAttackTime;
            StopAnimation("Moving");
        }
        else
        {
            Vector3 destPos = new Vector3(playerScript.transform.position.x - maxSpeed * Time.deltaTime, playerScript.transform.position.y, playerScript.transform.position.z);
            Move(destPos, MovingType.MoveTowards, maxSpeed);
            MoveUpdate();
            PlayAnimation("Moving");
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

    public void Damaging()
    {
        if (--health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            float deltaX = playerScript.transform.position.x - this.transform.position.x;
            if (deltaX < 0)
            {
                rigidBody.AddForce(new Vector2(jumpForce, 0));
            }
            else
            {
                rigidBody.AddForce(new Vector2(-jumpForce, 0));
            }
        }
    }
}
