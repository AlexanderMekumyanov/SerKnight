using UnityEngine;
using System.Collections;

public class ColliderForDamage : BaseAIScript 
{
    private SpiderBoss spiderBossScript;

	void Start () 
    {
        myAnimator = GetComponentInParent<Animator>();
        spiderBossScript = GetComponentInParent<SpiderBoss>();
	}

    public override void Damaging()
    {
        myAnimator.SetTrigger("Damaging");

        spiderBossScript.Damaging();
    }
}
