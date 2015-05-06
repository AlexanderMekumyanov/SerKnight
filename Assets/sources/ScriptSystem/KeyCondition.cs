using UnityEngine;
using System.Collections;

public class KeyCondition : MonoBehaviour 
{
    public KeyCode    keyKode;
    public GameObject doingObject;
    public string     objectTag;
    public string     scriptCommand;
    public string[]   arrayOfParameter;
    public bool       isLimited = false;

    private Renderer objectRenderer;

	void Start () 
    {
        objectRenderer = this.GetComponent<Renderer>();
        objectRenderer.enabled = false;
	}
	
	void Update () 
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        objectRenderer.enabled = true;
        if (other.gameObject.tag == objectTag && Input.GetKey(keyKode))
        {
            ScriptSystem scriptSystem = ScriptSystem.GetInstance();
            scriptSystem.SetScriptCommand(doingObject, scriptCommand, arrayOfParameter);
            if (isLimited)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objectRenderer.enabled = false;
    }
}
