using UnityEngine;
using System.Collections;

public class Seed : Item {

	protected Plant mPlantType;
	private int mQuantity;
	private const int SEED_ENERGY_COST = 0;
	private static Vector2[] SEED_AREA_OF_EFFECT = { new Vector2(-1,-1), new Vector2(-1,0), new Vector2(-1,1)
												   , new Vector2(0,-1) , new Vector2(0,0) , new Vector2(0,1)
												   , new Vector2(1,-1) , new Vector2(1,0) , new Vector2(1,1)}; 

	void Awake()
	{
		Init();
	}

	void Init()
	{
		mEnergyCost = SEED_ENERGY_COST;
	}
	
	protected virtual void Action(){Debug.Log ("Seeds");}
}
