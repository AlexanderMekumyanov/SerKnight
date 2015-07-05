using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

    private PlayerScript player;
	void Awake () 
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
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

    public void GameExit()
    {
        Application.Quit();
    }
}
