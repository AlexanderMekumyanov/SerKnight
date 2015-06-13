using UnityEngine;
using System.Collections;

public class AxeWeaponScript : MonoBehaviour 
{
    PlayerScript playerScript;

	void Start () 
    {
        playerScript = GameSystem.GetInstance().Player;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Spider" && playerScript.isAttacking)
        {
            Destroy(other.gameObject);
        }
    }
}
