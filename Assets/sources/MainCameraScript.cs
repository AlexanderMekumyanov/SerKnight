using UnityEngine;
using System;
using System.Collections;

public class MainCameraScript : MonoBehaviour 
{
    public float dampTime = 0.15f;  
    public Transform target;

    private Vector3 velocity = Vector3.zero;
    private Camera myCamera;
    private float startCameraSize;
    void Start()
    {
        myCamera = Camera.main;
        startCameraSize = myCamera.orthographicSize;
    }

	void Update () 
    {
        UpdateInwardAnimation();
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.75f, target.position.z) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}

    private float destCameraSize;
    private float delay;
    private bool bInwardAnimation = false;
    private GameObject insideChamber;
    private GameObject outsideChamber;
    public void StartInwardAnimation(GameObject insideChamber, GameObject outsideChamber, float destCameraSize, float delay)
    {
        this.delay = delay;
        this.destCameraSize = destCameraSize;
        this.insideChamber = insideChamber;
        this.outsideChamber = outsideChamber;
        bInwardAnimation = true;
    }

    private bool bZoom = false;
    void UpdateInwardAnimation()
    {
        if (bInwardAnimation)
        {
            if (!bZoom)
            {
                this.myCamera.orthographicSize = Mathf.Lerp(this.myCamera.orthographicSize, destCameraSize, delay * Time.deltaTime);
                if (Mathf.Abs(destCameraSize - this.myCamera.orthographicSize) < 0.2f)
                {
                    bZoom = true;
                    this.myCamera.orthographicSize = destCameraSize;
                    outsideChamber.SetActive(false);
                    insideChamber.SetActive(true);
                }
            }
            else
            {
                this.myCamera.orthographicSize = Mathf.Lerp(this.myCamera.orthographicSize, startCameraSize, delay * Time.deltaTime);
                if (Mathf.Abs(startCameraSize - this.myCamera.orthographicSize) < 0.2f)
                {
                    bZoom = false;
                    bInwardAnimation = false;
                    this.myCamera.orthographicSize = startCameraSize;
                }
            }
        }
    }
}
