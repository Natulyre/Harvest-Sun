using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {
	
	public float mMinimum_X;
	public float mMinimum_Y;
	public float mMaximum_X;
	public float mMaximum_Y;

	//private Player mPlayer;
	private Camera mCamera;
	private int CAMERA_Z = -10;

	void Awake () 
	{
		Init ();
	}

	void Init() 
	{
		//mPlayer = gameObject.GetComponents<Player> ();
		mCamera = Camera.main;
	}

	void Update()
	{
		PositionCamera ();
	}

	void PositionCamera()
	{	
		//Get the player position
		float xPos = gameObject.transform.position.x;
		float yPos = gameObject.transform.position.y;

		//Clamp it to our specified camera's limits
		xPos = Mathf.Clamp(xPos, mMinimum_X, mMaximum_X);
		yPos = Mathf.Clamp(yPos, mMaximum_Y, mMinimum_Y);

		//Update the camera accordingly
		mCamera.transform.position = new Vector3 (xPos, yPos, CAMERA_Z);
	}
}
