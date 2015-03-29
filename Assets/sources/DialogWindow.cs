using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogWindow : GameObjectBase 
{
    public  float showingTime = 1;
    public  float destY = 0;

    private DialogSystem dialogSystem;
    private Text         dialogText;
    private float        showingTimer;
    private float        startPosY;
    

	void Start () 
    {
        dialogText      = GetComponentInChildren<Text>();
        dialogText.text = "";
        this.enabled    = false;

        showingTimer = 0;
        dialogSystem = DialogSystem.GetDialogSystem();
	}
	
	void Update () 
    {
	    if (scriptFlag)
        {
            ScriptLogic();
        }
	}

    void ScriptLogic()
    {
        switch (scriptCommand)
        {
            case "ShowDialog":
            {
                showingTimer += Time.deltaTime;
                if (showingTimer < showingTime)
                {
                    float p = showingTimer / showingTime;
                    this.transform.position = new Vector3(this.transform.position.x, destY * p + startPosY * (1.0f - p), 0.0f);
                }
                else
                {
                    dialogText.text = dialogSystem.GetDialogById(arrayOfParameter[0]);
                }
                break;
            }
        }
    }

}
