using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level3Manager : ScriptableActor 
{
    public DogScripts dog;

    public List<SpiderScript> spiders;

    public SpiderBoss spiderBoss;

    public bool goBoss = false;

	void Start () 
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Alies"));
        GameObject.Find("GameManager").GetComponent<GameManager>().Player.AddNewWeapon("Axe");
	}
	
	void Update () 
    {
        for (int i = 0; i < spiders.Count; i++)
        {
           if (spiders[i] != null)
           {
               return;
           }
        }

        GoBoss();

    }

    public void LetsGo()
    {
        //dog.WakeUp();
        for (int i = 0; i < spiders.Count; i++)
        {
            spiders[i].WakeUp();
            spiders[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public void GoBoss()
    {
        if (!goBoss)
        {
            spiderBoss.WakePlease();
            goBoss = true;
        }
    }
}
