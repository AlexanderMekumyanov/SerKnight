using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private MainCameraScript mainCamerScript;
    private PlayerScript player;
	void Awake () 
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
        mainCamerScript = Camera.main.GetComponent<MainCameraScript>();
	}
	
	void Update () 
    {
	    
	}

    public PlayerScript Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    public MainCameraScript GetMainCameraScript
    {
        get
        {
            return mainCamerScript;
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
