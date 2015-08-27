using UnityEngine;
using System.Collections;

public class ColiderForAttackScript : MonoBehaviour 
{
    private SpiderBoss spiderBossScript;

    void Awake()
    {
        spiderBossScript = GetComponentInParent<SpiderBoss>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spiderBossScript.Attack();
        }
    }
}
