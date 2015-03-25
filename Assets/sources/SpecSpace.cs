using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecSpace : MonoBehaviour 
{
    public string               objectTag;
    public GameObject           doingObject;
    public GameObject           scriptManagerObject;

    private ScriptManagerScript scriptManagerScript;

	void Start ()
    {

	}
	
	void Update () 
    {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == objectTag)
        {
            //doingObject.
        }
    }
}
