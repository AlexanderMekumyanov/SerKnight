using UnityEngine;
using System.Collections;

public class level2Manager : ScriptableActor 
{
    PlayerScript player;

	void Start () 
    {
        player = GameObject.Find("GameManager").GetComponent<GameManager>().Player;

        player.Equipt("ArmoredTrousersEquipt");
        player.Equipt("ArmoredJacketEquipt");
        player.AddNewWeapon("Axe");
	}

	void Update () 
    {
	
	}

    public void DialogInpass()
    {
        ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_4" });
    }

    public void RestartGame()
    {
        Application.LoadLevel("2_level");
    }

    public void TreeCome()
    {
        GameObject smallFallingBranch = GameObject.Find("smallFallingBranch");
        Rigidbody2D physicsBody = smallFallingBranch.GetComponent<Rigidbody2D>();
        physicsBody.isKinematic = false;
        physicsBody.fixedAngle = true;
        smallFallingBranch.transform.Rotate(new Vector3(0f, 0f, -30f));
    }

    public void FallTree()
    {
        GameObject fallingTreeBranch = GameObject.Find("fallingTreeBranch");
        Rigidbody2D physicsBody = fallingTreeBranch.GetComponent<Rigidbody2D>();
        physicsBody.isKinematic = false;
    }

    public void NextLevel()
    {
        ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_5" });
        //Application.LoadLevel("3_level");
    }
}
