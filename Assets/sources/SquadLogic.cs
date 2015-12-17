using UnityEngine;
using System.Collections.Generic;

public class SquadLogic : MonoBehaviour
{
    [SerializeField]
    private bool controlling = false;
    public  bool Controlling
    {
        get { return controlling;  }
        set { controlling = value; }
    }

    [SerializeField]
    private List<PlayerScript> soldiers = null;

    private PlayerScript firstSoldier;
    public PlayerScript FirstSoldier
    {
        get
        {
            if (direction == Direction.RIGHT)
            {
                return soldiers[soldiers.Count - 1];
            }
            return soldiers[0];
        }
    }

    [SerializeField]
    private Direction direction;

	void Start ()
    {
	
	}	
	
	void Update ()
    {
        if (Controlling)
        {
            ControllingLogic();
        }
        else
        {
            
        }
	}

    void ControllingLogic()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FirstSoldier.PlayAnimation("Attack");            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            FirstSoldier.PlayAnimation("Yeah");            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].GoRight();                
            }
            direction = Direction.RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].GoLeft();                
            }
            direction = Direction.LEFT;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].Jump();
            }
        }
        else
        {
            for (int i = 0; i < soldiers.Count; i++)
            {
                soldiers[i].Idle();
            }
        }
    }
}