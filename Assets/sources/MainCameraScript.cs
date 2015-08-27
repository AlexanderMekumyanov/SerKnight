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

    private bool bZooming = false;
    private float zoomingDestCameraSize;
    private float zoomingDelay;
    public void StartZoom(float destCameraSize, float delay)
    {
        bZooming = true;
        this.zoomingDelay = delay;
        this.zoomingDestCameraSize = destCameraSize;
    }

    private bool ZoomUpdate(float destCameraSize, float delay)
    {
        this.myCamera.orthographicSize = Mathf.Lerp(this.myCamera.orthographicSize, destCameraSize, delay * Time.deltaTime);
        if (Mathf.Abs(destCameraSize - this.myCamera.orthographicSize) < 0.2f)
        {
            return true;
        }
        return false;
    }
    
    private bool bInwardAnimation = false;
    private GameObject insideChamber;
    private GameObject outsideChamber;
    public void StartInwardAnimation(GameObject insideChamber, GameObject outsideChamber, float destCameraSize, float delay)
    {
        this.zoomingDelay = delay;
        this.zoomingDestCameraSize = destCameraSize;
        this.insideChamber = insideChamber;
        this.outsideChamber = outsideChamber;
        bInwardAnimation = true;
    }

    private bool bZoom = false;
    private bool UpdateInwardAnimation()
    {
        if (!bZoom)
        {
            if (ZoomUpdate(zoomingDestCameraSize, zoomingDelay))
            {
                bZoom = true;
                this.myCamera.orthographicSize = zoomingDestCameraSize;
                outsideChamber.SetActive(false);
                insideChamber.SetActive(true);
            }
        }
        else
        {
            if (ZoomUpdate(startCameraSize, zoomingDelay))
            {
                bZoom = false;
                this.myCamera.orthographicSize = startCameraSize;
                return true;
            }
        }
        return false;
    }

    void Update () 
    {
        if (bZooming)
        {
            if (ZoomUpdate(zoomingDestCameraSize, zoomingDelay))
            {
                bZooming = false;
            }
        }
        else if (bInwardAnimation)
        {
            if (UpdateInwardAnimation())
            {
                bInwardAnimation = false;
            }
        }
        if (target)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 1.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 1.75f, target.position.z) - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	}
}
