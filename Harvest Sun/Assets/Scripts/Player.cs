using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



	//Available player directions
	public enum Direction
	{
		NORTH = 0,
		SOUTH = 1,
		EAST = 2,
		WEST = 3
	}

	//Player's inventory
	public Item[] mInventory;
	private const int mInventorySize = 8;
	private int mCurrentItem;
	//private IPickable mPickedUpItem;

	//Player's state
	private bool mIsHoldingSomething;
	private bool mInTriggerZone;

	//Player's stats
	public float mSpeed;
	private int mEnergy;
	private int mMoney;
	private int mLogs;
	private int mRocks;

	//Energy
	private const int DAILY_ENERGY = 100;
	private const int FOOD_ENERGY = 15;

	//Player's inputs
	private bool mUpButton;
	private bool mDownButton;
	private bool mLeftButton;
	private bool mRightButton;
	private bool mActionButton;
	private bool mItemButton;
	private bool mInputAllowed;
	private bool mDebugButton;

	//Player's movement & position
	private const float POSITION_Y_OFFSET = -0.06f;
	private Vector2 mPosition;
	private Direction mDirection;
	private Rigidbody2D mRigidBody;

	void Awake()
	{
		Init ();
	}

	//Initialize all variables
	void Init()
	{
		mInputAllowed = true;
		mDirection = Direction.SOUTH;
		mRigidBody = GetComponent<Rigidbody2D>();
		mCurrentItem = 0;
		mMoney = 0;
		mRocks = 0;
		mLogs = 0;
		mIsHoldingSomething = false;
		mEnergy = 100;
		for (int i = 0; i<8; i++) 
		{
			//Fill the array with nada?
			//mInventory[i] = null;
		}
	}

	//Update the player's logic
	void Update () 
	{
		UpdatePosition();
		HandleInput();
		HandleActions ();
	}

	//Update the player's position in tiles
	void UpdatePosition()
	{
		mPosition.x = (int)(transform.position.x /PlotGenerator.mTileSize);
		mPosition.y = (int)((transform.position.y +POSITION_Y_OFFSET) /PlotGenerator.mTileSize);
	}

	//Update the input states
	void HandleInput()
	{
		mUpButton = Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow);
		mDownButton = Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow);
		mRightButton = Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow);
		mLeftButton = Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow);
		mActionButton = Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.Return);
		mItemButton = Input.GetKey (KeyCode.F) || Input.GetKey (KeyCode.RightShift);
		mDebugButton = Input.GetKey (KeyCode.Z);
	}

	//Handles the player actions based upon input
	void HandleActions()
	{
		if (mInputAllowed)
		{
			if (mUpButton) {
				Move(0,1);
				mDirection = Direction.NORTH;
			}else if (mDownButton) {
				Move(0,-1);
				mDirection = Direction.SOUTH;
			} else if (mLeftButton) {
				Move(-1,0);
				mDirection = Direction.WEST;
			} else if (mRightButton) {
				Move(1,0);
				mDirection = Direction.EAST;
			} 
			else if (mActionButton) 
			{
				if (mIsHoldingSomething)
				{
					Throw();
				}
				else if (mInTriggerZone)
				{
					ActivateTrigger();
				}
				else 
				{
					PickUp();
				}
			}
			else if (mItemButton)
			{
				if (!mIsHoldingSomething)
				{
					ActivateItem();
				}
			}
		}
	}

	//Move by the specified X/Y
	void Move(float pX, float pY)	
	{
		//transform.position = new Vector3 (transform.position.x + pX*Time.deltaTime,
		//                                  transform.position.y + pY*Time.deltaTime,
		//                                  transform.position.z);
		mRigidBody.AddForce( new Vector2(pX, pY));
	}

	//Whenever the day changes
	void DayPassed()
	{
		SpawnHome();
		mEnergy = DAILY_ENERGY;
	}

	//When the moment changes, the player eats
	void MomentChanged(Time.Moment newMoment)
	{
		Eat();
	}

	//Eat, recover some energy
	void Eat()
	{
		mEnergy += FOOD_ENERGY;
	}

	//Spawn the player back home
	void SpawnHome()
	{

	}

	void Throw()
	{
		//Check if you can throw said object in front of you
		//throw it if you can
		//mIsHoldingSomething = false;
	}

	void PickUp()
	{
		//Check if you can pick up said object in front of you
		//Pick it up if you can
		//mIsHoldingSomething = true;
	}

	void ActivateTrigger()
	{
	}

	void ActivateItem()
	{
		//If our current inventory slot has an item
		if (mInventory [mCurrentItem] != null) 
		{
			//If we have at least 1 energy && enough energy to use the current item.
			if (mEnergy != 0 && mEnergy > mInventory[mCurrentItem].mEnergyCost)
			{
				//Reduce our current energy and use the item
				mEnergy -= mInventory[mCurrentItem].mEnergyCost;
				mInventory[mCurrentItem].Use(mPosition, mDirection);
			}
			//Otherwise fall down
			else
			{
				FallDown();
			}
		}
	}

	//Falldown
	void FallDown()
	{

	}

}
