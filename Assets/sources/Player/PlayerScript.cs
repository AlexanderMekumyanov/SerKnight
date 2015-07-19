using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : PhysicableActor
{
    private Skeleton    skeleton;

    public GameObject RightHandArmor;
    public GameObject LeftHandArmor;
    public GameObject RightLegArmor;
    public GameObject LeftLegArmor;
    public GameObject BodyArmor;
    public GameObject HeadArmor;

    private GameObject weapon;

    public float Health = 3;
    public float defence = 1; 

    void Start()
    {
        
    }

    void Awake()
    {
        InitPhysics();

        direction = Direction.RIGHT;

        InitAnimations();

        skeleton = gameObject.GetComponentInChildren<Skeleton>();

        weapon = this.transform.Find("Weapon").gameObject;
    }

    public override void InitAnimations()
    {
        base.InitAnimations();

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
        if (!DialogSystem.GetDialogSystem().GetSetDialogStart)
        {
            BaseLogic();
        }
        else
        {
            StopAllAnimation();
            curSpeed = 0.0f;
            rigidBody.velocity = new Vector2(0.0f, 0.0f);
        }
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
        weapon.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
    }

    public void Equipt(string itemName)
    {
        switch (itemName)
        {
            case "ArmoredJacketEquipt":
            {
                PlayerInventory.GetPlayerInventory().AddNewItem("Jacket");
                break;
            }
            case "ArmoredTrousersEquipt":
            {
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

    public void WeaponEquipt(string name)
    {
        PlayerInventory.GetPlayerInventory().EquiptWeapon(name);

        WeaponBase myWeapon = PlayerInventory.GetPlayerInventory().GetCurrentWeapon().GetComponent<WeaponBase>();
        myWeapon.transform.SetParent(weapon.transform);
        myWeapon.transform.localPosition = myWeapon.weaponPosition;
        myWeapon.transform.Rotate(myWeapon.weaponRotation);

        AnimatorOverrideController overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = myAnimator.runtimeAnimatorController;
        overrideController["Attack"] = myWeapon.weaponAnim;
        myAnimator.runtimeAnimatorController = overrideController;
    }

    public void AddNewWeapon(string weaponName)
    {
        GameObject newWeapon = (GameObject)Instantiate(Resources.Load("prefabs/weapons/" + weaponName) as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        newWeapon.name = weaponName;

        PlayerInventory.GetPlayerInventory().AddNewWeapon(newWeapon.name, newWeapon);
        WeaponEquipt(newWeapon.name);
    }

    public void AddNewArmor(string armorName)
    {
        GameObject newArmor = (GameObject)Instantiate(Resources.Load("prefabs/armor/" + armorName) as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        ArmorScript armorScript = newArmor.GetComponent<ArmorScript>();

        switch (armorScript.armorType)
        {
            case ArmorType.Body:
            {
                BodyArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[0];
                break;
            }
            case ArmorType.Legs:
            {
                RightLegArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[0];
                LeftLegArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[1];
                break;
            }
            case ArmorType.Hands:
            {
                RightHandArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[0];
                LeftHandArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[1];
                break;
            }
            case ArmorType.Head:
            {
                HeadArmor.GetComponent<SpriteRenderer>().sprite = armorScript.sprites[0];
                break;
            }
        }
    }
}
