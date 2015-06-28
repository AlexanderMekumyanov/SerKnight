using UnityEngine;
using System.Collections;
using System;

public class BackgroundMovementsObject : MovableActor 
{
    private Animator animator;
    private Vector2  startPos;

	void Start () 
    {
        animator = GetComponent<Animator>();
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
	}

	void Update () 
    {
        MoveUpdate();
	}

    void BaseLogic()
    {
        
    }

    public void DoFlight(string sX, string sY, string sDelay)
    {
        float x = Convert.ToSingle(sX);
        float y = Convert.ToSingle(sY);
        float delay = Convert.ToSingle(sDelay);
        animator.SetBool("Fly", true);
        Move(new Vector3(x, y, this.transform.position.z), MovingType.Lerp, delay);
    }
}
