using UnityEngine;
using System.Collections;

public class Axe : Tool {
	
	void awake()
	{
		Init ();
	}

	void Init()
	{
		mSprite = Resources.Load <Sprite> ("Sprites/Items/Axe");
	}

	protected override void Action()
	{
		Debug.Log ("CUT!");
	}
}
