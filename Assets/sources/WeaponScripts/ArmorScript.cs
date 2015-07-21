using UnityEngine;
using System.Collections;

public enum ArmorType
{
    Legs,
    Hands,
    Head,
    Body
}

public class ArmorScript : MonoBehaviour 
{
    public float defence = 1.0f;

    public ArmorType armorType = ArmorType.Body;

    public Sprite[] sprites;

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}
}
