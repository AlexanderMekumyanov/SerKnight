using UnityEngine;
using System.Collections;

public class level1Manager : ScriptableActor 
{
    private bool bDressingClothes = false;
    private bool bHaveAxe = false;
    private bool bNextLevel = false;
    private SpecSpace nextLevel;
    private GameObject inHouseDoor;

    void Start () 
    {
        InitLevel();
        nextLevel = GameObject.Find("NextLevel").GetComponent<SpecSpace>();
        nextLevel.gameObject.SetActive(false);
	}

    void InitLevel()
    {
        inHouseDoor = GameObject.Find("InHouseDoor");
        inHouseDoor.SetActive(false);
    }

	void Update () 
    {
        if (!bDressingClothes && PlayerInventory.GetPlayerInventory().IsItem("ArmoredJacket") && PlayerInventory.GetPlayerInventory().IsItem("ArmoredTrousers"))
        {
            bDressingClothes = true;
            ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_2" });
            inHouseDoor.SetActive(true);
        }

        if (bDressingClothes && !bHaveAxe && PlayerInventory.GetPlayerInventory().IsItem("Axe"))
        {
            bHaveAxe = true;
            ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_3" });
        }

        if (bDressingClothes && bHaveAxe && !bNextLevel)
        {
            bNextLevel = true;
            nextLevel.gameObject.SetActive(true);
            GameObject.Find("NextLevel").SetActive(true);
        }
	}

    public void NextLevel()
    {
        Application.LoadLevel("2_level");
    }
}
