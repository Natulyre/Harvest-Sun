using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour {

	public enum Triggers
	{
		Shop,
		House,
		Signpost
	}

	public Triggers mType;
	public BoxCollider2D mZone;

	public void ActivateTrigger()
	{
		switch (mType) 
		{
		case Triggers.House:
		break;
		case Triggers.Shop:
		break;
		case Triggers.Signpost:
		break;
		}
	}
}
