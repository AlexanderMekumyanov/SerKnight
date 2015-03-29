using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour 
{
    public float dampTime = 0.15f;  
    public Transform target;

    private Vector3 velocity = Vector3.zero;
	
    void Start()
    {

    }

	void Update () 
    {
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.75f, target.position.z) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}
}
