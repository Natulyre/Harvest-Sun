using UnityEngine;
using System.Collections;

public class Plant : Resource, ITimeBound, IPickable {

	//Various plant types
	public enum Type
	{
		Turnip,
		Potato,
		Corn
	}

	//Various plant phases
	protected enum Evolution
	{
		Seed,
		Sapling,
		Mature,
		Harvestable
	}

	//Will the plant keep producing fruits
	protected bool mRegrowth;

	//Gestation periods
	protected int mSeedPeriod;
	protected int mSaplingPeriod;
	protected int mMaturePeriod;
	protected int mHarvestablePeriod;

	//Money value
	protected int mValue;

	//Plant's appearance
	private Sprite mSeedSprite;
	private Sprite mSaplingSprite;
	protected Sprite mMatureSprite;
	protected Sprite mHarvestableSprite;

	//Tracked values
	private Evolution mCurrentState;
	private Sprite mCurrentSprite;
	private int mGestation;

	private void Awake()
	{
		Init ();
	}

	private void Init()
	{
		mGestation = 0;
		mCurrentState = Evolution.Seed;
		//IPickable.mIsPickable = false;
		//IPickable.mIsFragile = true;
	}

	public void DayPassed()
	{
		Grow();
	}

	public void MomentChanged(Time.Moment newMoment)
	{

	}

	public void Grow()
	{
		//Increase the plant's gestation
		++mGestation;

		//If the current gestation is higher than the gestation period, evolve.
		switch (mCurrentState) 
		{
		case Evolution.Seed:
			if (mGestation >= mSeedPeriod)
			{
				Evolve();
			}
			break;
		case Evolution.Sapling:
			if (mGestation >= mSaplingPeriod)
			{
				Evolve();
			}
			break;
		case Evolution.Mature:
			if (mGestation >= mMaturePeriod)
			{
				Evolve();
			}
			break;
		case Evolution.Harvestable:
			if (mGestation >= mHarvestablePeriod)
			{
				//IPickable.mIsPickable = true;
				Evolve();
			}
			break;
		}
	}

	private void Evolve()
	{
		if (mCurrentState == Evolution.Harvestable) 
		{
			//Destroy this
			//Destroy();
		}
		else 
		{
			++mCurrentState;
			UpdateSprite();
		}
	}

	private void UpdateSprite()
	{
		switch (mCurrentState) 
		{
		case Evolution.Seed:
			mCurrentSprite = mSeedSprite;
			break;
		case Evolution.Sapling:
			mCurrentSprite = mSaplingSprite;
			break;
		case Evolution.Mature:
			mCurrentSprite = mMatureSprite;
			break;
		case Evolution.Harvestable:
			mCurrentSprite = mHarvestableSprite;
			break;
		}
	}
}
