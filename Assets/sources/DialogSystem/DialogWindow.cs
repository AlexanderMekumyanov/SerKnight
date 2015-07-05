using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogWindow : ScriptableActor 
{
    public float showingTime = 1;
    public float hidingTime  = 1;
    public float destY = 0.0f;

    private DialogSystem dialogSystem;
    private Text         uiText;
    
    private float        startPosY;
    private List<string> dialogTexts;
    private int          currText;

    private bool         showing;
    private float        showingTimer;
    private bool         hiding;
    private float        hidingTimer;

	void Start() 
    {
        uiText      = this.gameObject.GetComponentInChildren<Text>();
        startPosY   = this.transform.localPosition.y;
        uiText.text = "";
        
        dialogSystem = DialogSystem.GetDialogSystem();

        showing      = false;
        showingTimer = 0;

        hiding       = false;
        hidingTimer  = 0;
	}
	
	void Update() 
    {
        if (showing)
        {
            Show();
        }
        else if (hiding)
        {
            Hide();
        }
	}

    public void ShowDialog(string textID)
    {
        showing = true;
        dialogTexts = dialogSystem.GetDialogById(textID);//arrayOfParameter[0]);
        uiText.text = dialogTexts[0];
        currText = 0;
    }

    private void Show()
    {
        showingTimer += Time.deltaTime;
        if (showingTimer < showingTime)
        {
            float p                 = showingTimer / showingTime;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, destY * p + startPosY * (1.0f - p), 0.0f);
        }
        else
        {
            showing = false;
            showingTimer = 0;
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, destY);
        }
    }

    private void Hide()
    {
        hidingTimer += Time.deltaTime;
        if (hidingTimer < hidingTime)
        {
            float p                 = hidingTimer / hidingTime;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, startPosY * p + destY * (1.0f - p), 0.0f);
        }
        else
        {
            hiding = false;
            hidingTimer = 0;
            this.transform.localPosition = new Vector2(this.transform.localPosition.x, startPosY);
        }
    }

    public void NextDialog()
    {
        currText++;
        if (currText > dialogTexts.Count - 1)
        {
            hiding = true;
            return;
        }
        uiText.text = dialogTexts[currText];
    }
}
