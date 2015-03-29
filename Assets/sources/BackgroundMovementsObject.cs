using UnityEngine;
using System.Collections;
using System;

public class BackgroundMovementsObject : GameObjectBase 
{
    private Animator animator;
    private float    flightTime;
    private float    flightTimer;
    private Vector2  startPos;

	void Start () 
    {
        animator    = GetComponent<Animator>();
        startPos    = new Vector2(this.transform.position.x, this.transform.position.y);
        flightTimer = 0.0f;
	}

	void Update () 
    {
	    if (!scriptFlag)
        {
            BaseLogic();
        }
        else
        {
            ScriptLogic();
        }
	}

    void BaseLogic()
    {

    }

    void ScriptLogic()
    {
        switch (scriptCommand)
        {
            case "DoFlight":
            {
                animator.SetBool("Fly", true);

                flightTimer += Time.deltaTime;
                flightTime   = Convert.ToSingle(arrayOfParameter[2]);
                if (flightTime < flightTimer)
                {
                    this.transform.position = new Vector3(Convert.ToSingle(arrayOfParameter[0]), Convert.ToSingle(arrayOfParameter[1]));
                    scriptFlag = false;
                }
                else
                { 
                    float p = flightTimer / flightTime;
                    this.transform.position = new Vector3(Convert.ToSingle(arrayOfParameter[0]) * p + startPos.x * (1.0f - p), Convert.ToSingle(arrayOfParameter[1]) * p + startPos.y * (1.0f - p), 0.0f);
                }

                break;
            }
        }
    }
}
