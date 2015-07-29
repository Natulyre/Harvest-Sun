using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {
	
	private List<Vector2> AoE;
	public Vector2[] mAreaOfEffect;
	public Sprite mSprite;
	public int mMoneyCost;
	public int mWoodCost;
	public int mStoneCost;
	public int mEnergyCost;
	public int mSlotNumber;
	
	void Awake()
	{
		AoE = new List<Vector2>();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			Use( Vector2.zero, Player.Direction.WEST);
		}
	}


	public void Use (Vector2 currentPosition, Player.Direction currentDirection) 
	{
		AoE.Clear ();
		switch (currentDirection) 
		{
		case Player.Direction.NORTH:
			foreach (Vector2 v in mAreaOfEffect)
			{
				AoE.Add(new Vector2(v.x, -v.y));
			}
			break;
		case Player.Direction.SOUTH:
			foreach (Vector2 v in mAreaOfEffect)
			{
				AoE.Add(new Vector2(v.x, v.y));
			}
			break;
		case Player.Direction.EAST:
			foreach (Vector2 v in mAreaOfEffect)
			{
				AoE.Add(new Vector2(v.y, v.x));
			}
			break;
		case Player.Direction.WEST:
			foreach (Vector2 v in mAreaOfEffect)
			{
				AoE.Add(new Vector2(-v.y, v.x));
			}
			break;
		}
		foreach (Vector2 v in AoE)
		{
			Action();
		}
	}

	protected virtual void Action(){Debug.Log ("Bad");}
}
