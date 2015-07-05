using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level3Manager : ScriptableActor 
{
    public DogScripts dog;

    public List<SpiderScript> spiders;

	void Start () 
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Alies"));
	}
	
	void Update () 
    {
    }

    public void LetsGo()
    {
        dog.WakeUp();
        for (int i = 0; i < spiders.Count; i++)
        {
            spiders[i].WakeUp();
        }
    }
}
