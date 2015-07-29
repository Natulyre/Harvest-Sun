using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlotGenerator : MonoBehaviour {

	public static float mTileSize = 0.16f;
	public int mRows;
	public int mColumns;
	public int mRowsOffset;
	public int mColumnsOffset;
	private const float Z_POS = -2;
	public GameObject mPrefab;
	public static List<Plot> mPlots;

	void Awake()
	{
		mPlots = new List<Plot>();
	}
	// Use this for initialization
	void Start () {
		SpawnTiles();
	}

	void SpawnTiles()
	{
		float halfTile = mTileSize / 2;
		for (int i = 0; i < mColumns; i++) 
		{
			for (int j = 0; j < mRows; j++)
			{

				float xPos = (i+mColumnsOffset)*mTileSize;
				float yPos = (j+mRowsOffset)*-mTileSize;
				RaycastHit2D[] raycasted = Physics2D.RaycastAll(new Vector2(xPos+halfTile, yPos-halfTile), new Vector3(0, 0, 1));
				for (int h = 0; h < raycasted.Length; h ++)
				{
					if (raycasted[h].collider.CompareTag("PlotAllowed"))
					{
						Object o = Instantiate(mPrefab, new Vector3(xPos, yPos, Z_POS),Quaternion.identity);
						GameObject go = o as GameObject;
						if (go != null)
						{
							Plot p = go.GetComponent<Plot>();
							if (p != null)
							{
								PlotGenerator.mPlots.Add(p);
							}
						}
					}
				}
			}
		}
	}
}