using UnityEngine;
using System.Collections;

public class AxeWeaponScript : WeaponBase 
{
    PlayerScript playerScript;

	void Start () 
    {
        playerScript = GameObject.Find("GameManager").GetComponent<GameManager>().Player;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Spider" && playerScript.isAttacking)
        {
            other.gameObject.GetComponent<BaseAIScript>().Damaging();
            playerScript.CannotAttack();
            Debug.Log("!!!!!!!!!!!!" + other.gameObject.name + ".DAMAGE!!!!!!!!!!!!");
        }
    }
}
