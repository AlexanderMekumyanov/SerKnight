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
    private bool     active;

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
        if (gameObject.active)
        {
            
            if (other.gameObject.tag == objectTag)
            {
                objectRenderer.enabled = true;
                if (Input.GetKeyUp(keyKode))
                {
                    ScriptSystem scriptSystem = ScriptSystem.GetInstance();
                    scriptSystem.SetScriptCommand(doingObject, scriptCommand, arrayOfParameter);
                    if (isLimited)
                    {
                        gameObject.SetActive(false);
                        Destroy(gameObject);
                        Debug.Log("KetCondition: OK!!!");
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objectRenderer.enabled = false;
    }
}
