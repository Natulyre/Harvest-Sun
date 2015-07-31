using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryHUD : MonoBehaviour {
	public Image mInventoryIMG1;
	public Image mInventoryIMG2;
	public Image mInventoryIMG3;
	public Image mInventoryIMG4;
	public Image mInventoryIMG5;
	public Image mInventoryIMG6;
	public Image mInventoryIMG7;
	public Image mInventoryIMG8;

	public Image mInventoryBorder1;
	public Image mInventoryBorder2;
	public Image mInventoryBorder3;
	public Image mInventoryBorder4;
	public Image mInventoryBorder5;
	public Image mInventoryBorder6;
	public Image mInventoryBorder7;
	public Image mInventoryBorder8;

	private Image[] mInventoryIMGs;
	private Image[] mInventoryBorders;

	public Sprite mNonSelected;
	public Sprite mSelected;
	public Sprite mEmpty;

	void Awake()
	{
		mInventoryIMGs = new Image[8]{mInventoryIMG1, mInventoryIMG2, mInventoryIMG3, mInventoryIMG4
									 ,mInventoryIMG5, mInventoryIMG6, mInventoryIMG7, mInventoryIMG8};

		mInventoryBorders = new Image[8]{mInventoryBorder1, mInventoryBorder2, mInventoryBorder3, mInventoryBorder4
										,mInventoryBorder5, mInventoryBorder6, mInventoryBorder7, mInventoryBorder8};
	}

	//Update the border of every items from the inventory, highlighting the current selection
	//Updates each item slots with their appropriate items.
	public void UpdateInventory(int currentItemSelection, Item[] inventory)
	{
		for (int i = 0; i < 8; i ++) 
		{
			mInventoryBorders[i].sprite = mNonSelected;
			if (inventory[i] != null)
			{
				mInventoryIMGs[i].sprite = inventory[i].mSprite;
			}
		}
		mInventoryBorders [currentItemSelection].sprite = mSelected;
	}
}
