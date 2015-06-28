using UnityEngine;
using System;
using System.Collections;

public class InwardDoor : MonoBehaviour 
{
    public float camSpeed;
    public float targetSize;
    public GameObject caveObject;
    public GameObject outsideObject;
    public GameObject cameraObject;

    private MainCameraScript mainCameraScript;

	void Start () 
    {
        mainCameraScript = cameraObject.GetComponent<MainCameraScript>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            mainCameraScript.StartInwardAnimation(caveObject, outsideObject, targetSize, camSpeed);
        }
    }
}
