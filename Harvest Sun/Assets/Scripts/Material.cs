using UnityEngine;
using System.Collections;

public class Material : MonoBehaviour, IPickable {

	public enum Type
	{
		Wood,
		Stone
	}
	
	//Number of hits to break
	protected int mResistance;
	
	//Resource stats
	protected Type mType;
	protected int mValue;
	
	//Current state
	private int mCurrentResistance;
	private bool mIsDestroyed;
	
	private void Awake () 
	{
		Init();
	}
	
	private void Init() 
	{
		mCurrentResistance = mResistance;
		mIsDestroyed = false;
	}
	
	public bool GetHit(int power) 
	{
		mResistance -= power;
		if (mResistance <= 0) 
		{
			mIsDestroyed = true;
		}
		return mIsDestroyed;
	}
	
	public Type GetType()
	{
		return mType;
	}
	
	public int GetValue()
	{
		return mValue;
	}
	
	private void Update () 
	{
		if (mIsDestroyed) 
		{
			//Destroy this
		}
	}
}
