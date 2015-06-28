using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : PhysicableActor
{
    private Skeleton    skeleton;

    private GameObject  ArmoredJacket;
    private GameObject  ArmoredTrousers;

    void Start()
    {
        InitPhysics();
        
        direction  = Direction.RIGHT;

        ArmoredJacket   = GameObject.Find("ArmoredJacket");
        ArmoredTrousers = GameObject.Find("ArmoredTrousers");
        ArmoredTrousers.GetComponent<Renderer>().enabled = false;
        ArmoredJacket.GetComponent<Renderer>().enabled   = false;
        InitAnimations();

        skeleton = gameObject.GetComponentInChildren<Skeleton>();
    }

    public override void InitAnimations()
    {
        Animator = gameObject.GetComponent<Animator>();
        Animations = new List<string>();
        Animations.Add("Yeah");
        Animations.Add("Walk");
        Animations.Add("Attack");
    }
    
    void FixedUpdate()
    {
        PhysicsUpdate();
    }

    void Update()
    {
        BaseLogic();
    }

    void BaseLogic()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayAnimation("Attack");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayAnimation("Yeah");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayAnimation("Walk");
            curSpeed = maxSpeed;
            if (direction == Direction.LEFT)
            {
                Flip();
                direction = Direction.RIGHT;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayAnimation("Walk");
            curSpeed = -maxSpeed;
            if (direction == Direction.RIGHT)
            {
                Flip();
                direction = Direction.LEFT;
            }
        }
        else
        {
            StopAllAnimation();
            curSpeed = 0.0f;
        }
        rigidBody.velocity = new Vector2(curSpeed, rigidBody.velocity.y);
    }

    void Flip()
    {
        skeleton.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
    }

    public void Equipt(string itemName)
    {
        switch (itemName)
        {
            case "ArmoredJacketEquipt":
            {
                ArmoredJacket.GetComponent<Renderer>().enabled = true;
                PlayerInventory.GetPlayerInventory().AddNewItem("Jacket");
                break;
            }
            case "ArmoredTrousersEquipt":
            {
                ArmoredTrousers.GetComponent<Renderer>().enabled = true;
                PlayerInventory.GetPlayerInventory().AddNewItem("Trousers");
                break;
            }
            case "AxeEquipt":
            {
                PlayerInventory.GetPlayerInventory().AddNewItem("Axe");
                break;
            }
        }
    }

    public bool isAttacking
    {
        get;
        set;
    }

    public void CanAttack()
    {
        isAttacking = true;
    }

    public void CannotAttack()
    {
        isAttacking = false;
    }
}
