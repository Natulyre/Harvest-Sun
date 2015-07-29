using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour, ITimeBound {

	private bool mIsOpen;

	void Start () 
	{
	
	}
	
	public void DayPassed()
	{}
	
	public void MomentChanged(Time.Moment newMoment)
	{
		switch (newMoment) 
		{
		case Time.Moment.Morning:
			mIsOpen = false;
			break;
		case Time.Moment.Noon:
			mIsOpen = true;
			break;
		case Time.Moment.Afternoon:
			mIsOpen = false;
			break;
		case Time.Moment.Night:
			mIsOpen = false;
			break;
		}
	}
}
