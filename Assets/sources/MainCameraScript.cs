using UnityEngine;
using System;
using System.Collections;

public class MainCameraScript : Actor 
{
    public float dampTime = 0.15f;  
    public Transform target;

    private Vector3 velocity = Vector3.zero;
	
    void Start()
    {
    }

	void Update () 
    {
        if (ScriptFlag)
        {
            ScriptLogic();
        }
        else if (IsMoving)
        {
            MoveUpdate();
        }
        else if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.75f, target.position.z) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}

    void ScriptLogic()
    {
        switch(ScriptCommand)
        {
            case "GoToCave":
            {
                ScriptFlag = false;
                Move(new Vector3(transform.position.x, transform.position.y, Convert.ToSingle(ArrayOfParameter[0])), Convert.ToSingle(ArrayOfParameter[1]));
                break;
            }
        }
    }
}
