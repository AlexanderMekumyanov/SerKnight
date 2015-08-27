using UnityEngine;
using System.Collections;

public class ForAnimationScript : MonoBehaviour
{

    public string playerWeapon;
	void Start () 
    {
        GameObject.Find("Player").GetComponent<PlayerScript>().AddNewWeapon(playerWeapon);
	}
	
	void Update () {
	
	}
}
