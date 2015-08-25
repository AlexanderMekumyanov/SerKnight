using UnityEngine;
using System.Collections;

public class BaseAIScript : PhysicableActor 
{
    public PlayerScript playerScript;

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

    public virtual void Damaging()
    {
    }
}
