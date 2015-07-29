using UnityEngine;
using System.Collections;

public interface ITimeBound
{
	void DayPassed();
	void MomentChanged(Time.Moment newMoment);
}
