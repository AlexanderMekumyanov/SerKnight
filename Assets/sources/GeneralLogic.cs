using UnityEngine;
using System.Collections.Generic;

public class GeneralLogic : MonoBehaviour
{
    [SerializeField]
    private List<SquadLogic> squadList = null;

    [SerializeField]
    private int controlledSquadID = 0;
	void Start ()
    {
        controlledSquadID = 0;
        squadList[controlledSquadID].Controlling = true;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            squadList[controlledSquadID].Controlling = false;
            controlledSquadID++;
            controlledSquadID = Mathf.Clamp(controlledSquadID, 0, squadList.Count - 1);
            squadList[controlledSquadID].Controlling = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            squadList[controlledSquadID].Controlling = false;
            controlledSquadID--;
            controlledSquadID = Mathf.Clamp(controlledSquadID, 0, squadList.Count - 1);
            squadList[controlledSquadID].Controlling = true;
        }
    }
}
