using UnityEngine;

public class InventoryTestScript : MonoBehaviour
{
	public SimpleDetectClickScript[] Items;

	public Animation SkirtAnimation;

	public Animation GirlAnimation;

	public GameObject Skirt;

	public GameObject Girl;

	public Renderer SkirtRenderer;

	public Renderer GirlRenderer;

	public Transform RightGridHighlightParent;

	public Transform LeftGridHighlightParent;

	public Transform RightGridItemParent;

	public Transform LeftGridItemParent;

	public Transform Highlight;

	public Transform RightGrid;

	public Transform LeftGrid;

	public float Alpha;

	public bool Open = true;

	public int OpenSpace = 1;

	public int UseColumn;

	public int UseGrid;

	public int Column = 1;

	public int Grid = 1;

	public int Row = 1;

	public bool[] LeftSpaces1;

	public bool[] LeftSpaces2;

	public bool[] LeftSpaces3;

	public bool[] LeftSpaces4;

	public bool[] RightSpaces1;

	public bool[] RightSpaces2;

	public bool[] RightSpaces3;

	public bool[] RightSpaces4;

	private void Start()
	{
		RightGrid.localScale = new Vector3(0f, 0f, 0f);
		LeftGrid.localScale = new Vector3(0f, 0f, 0f);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Open = !Open;
		}
		AnimationState animationState = SkirtAnimation["InverseSkirtOpen"];
		AnimationState animationState2 = GirlAnimation["f02_inventory_00"];
		if (Open)
		{
			RightGrid.localScale = Vector3.MoveTowards(RightGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			LeftGrid.localScale = Vector3.MoveTowards(LeftGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 0.37f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 1f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			Alpha = Mathf.Lerp(Alpha, 1f, Time.deltaTime * 10f);
			SkirtRenderer.material.color = new Color(1f, 1f, 1f, Alpha);
			GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, Alpha);
			GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, Alpha);
			if (Input.GetKeyDown("right"))
			{
				Column++;
				UpdateHighlight();
			}
			if (Input.GetKeyDown("left"))
			{
				Column--;
				UpdateHighlight();
			}
			if (Input.GetKeyDown("up"))
			{
				Row--;
				UpdateHighlight();
			}
			if (Input.GetKeyDown("down"))
			{
				Row++;
				UpdateHighlight();
			}
		}
		else
		{
			RightGrid.localScale = Vector3.MoveTowards(RightGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			LeftGrid.localScale = Vector3.MoveTowards(LeftGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 1f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 0f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			Alpha = Mathf.Lerp(Alpha, 0f, Time.deltaTime * 10f);
			SkirtRenderer.material.color = new Color(1f, 1f, 1f, Alpha);
			GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, Alpha);
			GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, Alpha);
		}
		for (int i = 0; i < Items.Length; i++)
		{
			if (!Items[i].Clicked)
			{
				continue;
			}
			Debug.Log("Item width is " + Items[i].InventoryItem.Width + " and item height is " + Items[i].InventoryItem.Height + ". Open space is: " + OpenSpace);
			if (Items[i].InventoryItem.Height * Items[i].InventoryItem.Width < OpenSpace)
			{
				Debug.Log("We might have enough open space to add the item to the inventory.");
				CheckOpenSpace();
				if (UseGrid == 1)
				{
					Items[i].transform.parent = LeftGridItemParent;
					float inventorySize = Items[i].InventoryItem.InventorySize;
					Items[i].transform.localScale = new Vector3(inventorySize, inventorySize, inventorySize);
					Items[i].transform.localEulerAngles = new Vector3(90f, 180f, 0f);
					Items[i].transform.localPosition = Items[i].InventoryItem.InventoryPosition;
					int j = 1;
					if (UseColumn == 1)
					{
						for (; j < Items[i].InventoryItem.Height + 1; j++)
						{
							LeftSpaces1[j] = true;
						}
					}
					else if (UseColumn == 2)
					{
						for (; j < Items[i].InventoryItem.Height + 1; j++)
						{
							LeftSpaces2[j] = true;
						}
					}
					if (UseColumn > 1)
					{
						Items[i].transform.localPosition -= new Vector3(0.05f * (float)(UseColumn - 1), 0f, 0f);
					}
				}
			}
			Items[i].Clicked = false;
		}
	}

	private void CheckOpenSpace()
	{
		UseColumn = 0;
		UseGrid = 0;
		int i;
		for (i = 1; i < LeftSpaces1.Length; i++)
		{
			if (UseGrid == 0 && !LeftSpaces1[i])
			{
				UseColumn = 1;
				UseGrid = 1;
			}
		}
		i = 1;
		if (UseGrid != 0)
		{
			return;
		}
		for (; i < LeftSpaces2.Length; i++)
		{
			if (UseGrid == 0 && !LeftSpaces2[i])
			{
				UseColumn = 2;
				UseGrid = 1;
			}
		}
	}

	private void UpdateHighlight()
	{
		if (Column == 5)
		{
			if (Grid == 1)
			{
				Grid = 2;
			}
			else
			{
				Grid = 1;
			}
			Column = 1;
		}
		else if (Column == 0)
		{
			if (Grid == 1)
			{
				Grid = 2;
			}
			else
			{
				Grid = 1;
			}
			Column = 4;
		}
		if (Row == 6)
		{
			Row = 1;
		}
		else if (Row == 0)
		{
			Row = 5;
		}
		if (Grid == 1)
		{
			Highlight.transform.parent = LeftGridHighlightParent;
		}
		else
		{
			Highlight.transform.parent = RightGridHighlightParent;
		}
		Highlight.localPosition = new Vector3(Column, Row * -1, 0f);
	}
}
