using UnityEngine;
using System.Collections;

public class Plot : MonoBehaviour {

	private Resource mResource;
	private bool mHasBeenPlowed;
	private Vector2 mPosition;

	private void Awake()
	{
		Init();
	}

	private void Init()
	{
		mResource = null;
		SetPosition((int)(transform.position.x/PlotGenerator.mTileSize),
		            (int)(-transform.position.y/PlotGenerator.mTileSize));
	}
	
	public bool GetHasBeenPlowed()
	{
		return mHasBeenPlowed;
	}

	public void SetHasBeenPlowed(bool toggle)
	{
		mHasBeenPlowed = toggle;
	}

	public void SetPosition(int x, int y)
	{
		mPosition = new Vector2(x, y);
	}

	static Plot GetPlot(Vector2 tilePosition)
	{
		foreach (Plot p in PlotGenerator.mPlots)
		{
		}
		return null;
	}
}
