using UnityEngine;
using System.Collections;

public class Time : MonoBehaviour {

	public enum Moment
	{
		Morning,
		Noon,
		Afternoon,
		Night
	}

	private const float MINUTE_DELAY = 0.6f;
	private const int MORNING_TIME = 8;
	private const int NOON_TIME = 12;
	private const int AFTERNOON_TIME = 16;
	private const int NIGHT_TIME = 20;

	private float mMinutes;
	private int mHours;
	private bool mTimeHasChanged;
	private bool mMomentHasChanged;
	private bool mMorningPassed;
	private bool mNoonPassed;
	private bool mAfternoonPassed;
	private bool mNightPassed;
	private bool mTimeIsRunning;

	public Moment mCurrentMoment;

	void Awake () {
		Init ();
	}

	void Init()
	{
		ResetDay ();
	}

	void ResetDay()
	{
		mHours = 8;
		mMinutes = 0;
		mCurrentMoment = Moment.Morning;
		mMorningPassed = false;
		mNoonPassed = false;
		mAfternoonPassed = false;
		mNightPassed = false;
		mTimeIsRunning = true;
		UpdateMoment();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mTimeIsRunning)
		{
			IncreaseTime(MINUTE_DELAY * UnityEngine.Time.deltaTime);
			if (mTimeHasChanged)
			{
				UpdateMoment();
			}
		}

	}

	void IncreaseTime(float minutes, int hours = 0)
	{
		mMinutes += minutes;
		while (mMinutes > 60) 
		{
			++mHours;
			mMinutes -= 60;
			mTimeHasChanged = true;
		}
	}

	void UpdateMoment()
	{
		mTimeHasChanged = false;
		mMomentHasChanged = false;
		if (mHours >= NIGHT_TIME && !mNightPassed) 
		{
			mCurrentMoment = Moment.Night;
			mMomentHasChanged = true;
			Night();
		}
		else if (mHours >= AFTERNOON_TIME && !mAfternoonPassed) 
		{
			mCurrentMoment = Moment.Afternoon;
			mMomentHasChanged = true;
			Afternoon();
		}
		else if (mHours >= NOON_TIME && !mNoonPassed) 
		{
			mCurrentMoment = Moment.Noon;
			mMomentHasChanged = true;
			Noon();
		}
		else if (mHours >= MORNING_TIME && !mMorningPassed) 
		{
			mCurrentMoment = Moment.Morning;
			mMomentHasChanged = true;
			Morning();
		}
		if (mMomentHasChanged) 
		{
			//ITimeBound[] timeBounds = UnityEngine.Object.FindObjectsOfType<ITimeBound>();
			//foreach (ITimeBound tb in timeBounds) 
			//{
			//	tb.MomentChanged(mCurrentMoment);
			//}
		}
	}

	void Morning()
	{
		//Play Cuckoo sound?
		//Morning music?
	}

	void Noon()
	{
		//Enable buying
		//Play Cuckoo sound?
	}

	void Afternoon()
	{
		//Disable buying?
		//Disable selling?
		//Play Bat sound?
		//Night music?
	}

	void Night()
	{
		NewDay();
	}

	void NewDay()
	{
		ResetDay();
		//ITimeBound[] timeBounds = UnityEngine.Object.FindObjectsOfType<ITimeBound> ();
		//foreach (ITimeBound tb in timeBounds) 
		//{
		//	tb.DayPassed();
		//}
		//New day stuff?
	}
}
