using UnityEngine;
using System.Collections;

public class BaseAIScript : PhysicableActor 
{
    public PlayerScript playerScript;
    public int health;

    protected void MovingTo(GameObject target)
    {
        if (grounded)
        {
            Vector3 destPos = new Vector3(target.transform.position.x - maxSpeed * Time.deltaTime, target.transform.position.y, target.transform.position.z);
            Move(destPos, MovingType.MoveTowards, maxSpeed);
            MoveUpdate();
        }
    }

    protected bool IsWithinReach(GameObject target, float rangeDistance)
    {
        float deltaX = target.transform.position.x - this.transform.position.x;
        if (Mathf.Abs(deltaX) < rangeDistance)
        {
            return true;
        }
        return false;
    }

    protected void MovingToPlayerBehind(float playerBehindDistance)
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

    public virtual void Damaging()
    {
    }
}
