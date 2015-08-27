using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class level3Manager : ScriptableActor 
{
    public DogScripts dog;
    public List<SpiderScript> spiders;
    public SpiderBoss spiderBoss;
    
    public GameObject NextLevelTrigger;

    private GameManager gameManager;
    private bool goBoss = false;
    private bool bossIsDie = false;

	void Start () 
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("NonCollide"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Mobs"), LayerMask.NameToLayer("Mobs"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Mobs"), LayerMask.NameToLayer("NonCollide"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NonCollide"), LayerMask.NameToLayer("NonCollide"));

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.Player.AddNewWeapon("Axe");
        //LetsGo();
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

        if (bossIsDie == false && spiderBoss == null)
        {
            gameManager.GetMainCameraScript.StartZoom(4, 5);
            NextLevelTrigger.SetActive(true);
            bossIsDie = true;
        }
    }

    public void LetsGo()
    {
        dog.WakeUp();
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
            gameManager.GetMainCameraScript.StartZoom(7, 5);
        }
    }

    public void NextLevel()
    {
        ScriptSystem.GetInstance().SetScriptCommand(GameObject.Find("DialogWindow"), "ShowDialog", new string[1] { "DIALOG_5" });
    }
}
