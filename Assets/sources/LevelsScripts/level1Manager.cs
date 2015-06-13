using UnityEngine;
using System.Collections;

public class level1Manager : ScriptableActor 
{
    private bool bDressingClothes = false;
    private bool bHaveAxe = false;
    private bool bNextLevel = false;

    void Start () 
    {
        InitLevel();
	}

    void InitLevel()
    {
        GameObject.Find("InHouseDoor").GetComponent<Collider2D>().enabled = false;
    }

	void Update () 
    {
        if (!bDressingClothes && PlayerInventory.GetPlayerInventory().IsItem("Jacket") && PlayerInventory.GetPlayerInventory().IsItem("Trousers"))
        {
            bDressingClothes = true;
            ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_2" });
            GameObject.Find("InHouseDoor").GetComponent<Collider2D>().enabled = true;
        }

        if (bDressingClothes && !bHaveAxe && PlayerInventory.GetPlayerInventory().IsItem("Axe"))
        {
            bHaveAxe = true;
            ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_3" });
        }

        if (bDressingClothes && bHaveAxe && !bNextLevel)
        {
            bNextLevel = true;
            GameObject.Find("NextLevel").SetActive(true);
        }
	}

    public void NextLevel()
    {
        Application.LoadLevel("2_level");
    }
}
