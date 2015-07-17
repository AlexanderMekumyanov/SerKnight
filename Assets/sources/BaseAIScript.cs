using UnityEngine;
using System.Collections;

public class BaseAIScript : PhysicableActor 
{
    public PlayerScript playerScript;

    protected bool MovingToPlayer(float betweenDistance, string MovingAnimationName)
    {
        float deltaX = playerScript.transform.position.x - this.transform.position.x;
        if (Mathf.Abs(deltaX) < betweenDistance)
        {
            StopAnimation(MovingAnimationName);
            return true;
        }
        else
        {
            Vector3 destPos = new Vector3(playerScript.gameObject.transform.position.x - maxSpeed * Time.deltaTime, playerScript.transform.position.y, playerScript.transform.position.z);
            Move(destPos, MovingType.MoveTowards, maxSpeed);
            MoveUpdate();
            PlayAnimation(MovingAnimationName);
            return false;
        }
    }
}
