using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecSpace : MonoBehaviour 
{
    public string               objectTag;
    public GameObject           doingObject;
    public GameObject           scriptManagerObject;
    public string               scriptCommand;
    public string[]             arrayOfParameter;
    
    private bool                flagScript;

	void Start ()
    {
        flagScript = false;
	}
	
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (flagScript)
        {
            return;
        }

        if (other.gameObject.tag == objectTag)
        {
            ScriptSystem scriptSystem = ScriptSystem.GetInstance();
            scriptSystem.SetScriptCommand(doingObject, scriptCommand, arrayOfParameter);
            flagScript = true;
            Destroy(gameObject);
        }
    }
}
