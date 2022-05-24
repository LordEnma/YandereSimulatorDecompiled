using System;
using UnityEngine;

// Token: 0x02000343 RID: 835
public class InventoryTestScript : MonoBehaviour
{
	// Token: 0x0600191D RID: 6429 RVA: 0x000FC1B0 File Offset: 0x000FA3B0
	private void Start()
	{
		this.RightGrid.localScale = new Vector3(0f, 0f, 0f);
		this.LeftGrid.localScale = new Vector3(0f, 0f, 0f);
		Time.timeScale = 1f;
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x000FC208 File Offset: 0x000FA408
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Open = !this.Open;
		}
		AnimationState animationState = this.SkirtAnimation["InverseSkirtOpen"];
		AnimationState animationState2 = this.GirlAnimation["f02_inventory_00"];
		if (this.Open)
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 0.37f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 1f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			this.Alpha = Mathf.Lerp(this.Alpha, 1f, Time.deltaTime * 10f);
			this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
			this.GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
			if (Input.GetKeyDown("right"))
			{
				this.Column++;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("left"))
			{
				this.Column--;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("up"))
			{
				this.Row--;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("down"))
			{
				this.Row++;
				this.UpdateHighlight();
			}
		}
		else
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 1f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 0f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			this.Alpha = Mathf.Lerp(this.Alpha, 0f, Time.deltaTime * 10f);
			this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
			this.GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
		}
		for (int i = 0; i < this.Items.Length; i++)
		{
			if (this.Items[i].Clicked)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Item width is ",
					this.Items[i].InventoryItem.Width.ToString(),
					" and item height is ",
					this.Items[i].InventoryItem.Height.ToString(),
					". Open space is: ",
					this.OpenSpace.ToString()
				}));
				if (this.Items[i].InventoryItem.Height * this.Items[i].InventoryItem.Width < this.OpenSpace)
				{
					Debug.Log("We might have enough open space to add the item to the inventory.");
					this.CheckOpenSpace();
					if (this.UseGrid == 1)
					{
						this.Items[i].transform.parent = this.LeftGridItemParent;
						float inventorySize = this.Items[i].InventoryItem.InventorySize;
						this.Items[i].transform.localScale = new Vector3(inventorySize, inventorySize, inventorySize);
						this.Items[i].transform.localEulerAngles = new Vector3(90f, 180f, 0f);
						this.Items[i].transform.localPosition = this.Items[i].InventoryItem.InventoryPosition;
						int j = 1;
						if (this.UseColumn == 1)
						{
							while (j < this.Items[i].InventoryItem.Height + 1)
							{
								this.LeftSpaces1[j] = true;
								j++;
							}
						}
						else if (this.UseColumn == 2)
						{
							while (j < this.Items[i].InventoryItem.Height + 1)
							{
								this.LeftSpaces2[j] = true;
								j++;
							}
						}
						if (this.UseColumn > 1)
						{
							this.Items[i].transform.localPosition -= new Vector3(0.05f * (float)(this.UseColumn - 1), 0f, 0f);
						}
					}
				}
				this.Items[i].Clicked = false;
			}
		}
	}

	// Token: 0x0600191F RID: 6431 RVA: 0x000FC844 File Offset: 0x000FAA44
	private void CheckOpenSpace()
	{
		this.UseColumn = 0;
		this.UseGrid = 0;
		int i;
		for (i = 1; i < this.LeftSpaces1.Length; i++)
		{
			if (this.UseGrid == 0 && !this.LeftSpaces1[i])
			{
				this.UseColumn = 1;
				this.UseGrid = 1;
			}
		}
		i = 1;
		if (this.UseGrid == 0)
		{
			while (i < this.LeftSpaces2.Length)
			{
				if (this.UseGrid == 0 && !this.LeftSpaces2[i])
				{
					this.UseColumn = 2;
					this.UseGrid = 1;
				}
				i++;
			}
		}
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x000FC8D0 File Offset: 0x000FAAD0
	private void UpdateHighlight()
	{
		if (this.Column == 5)
		{
			if (this.Grid == 1)
			{
				this.Grid = 2;
			}
			else
			{
				this.Grid = 1;
			}
			this.Column = 1;
		}
		else if (this.Column == 0)
		{
			if (this.Grid == 1)
			{
				this.Grid = 2;
			}
			else
			{
				this.Grid = 1;
			}
			this.Column = 4;
		}
		if (this.Row == 6)
		{
			this.Row = 1;
		}
		else if (this.Row == 0)
		{
			this.Row = 5;
		}
		if (this.Grid == 1)
		{
			this.Highlight.transform.parent = this.LeftGridHighlightParent;
		}
		else
		{
			this.Highlight.transform.parent = this.RightGridHighlightParent;
		}
		this.Highlight.localPosition = new Vector3((float)this.Column, (float)(this.Row * -1), 0f);
	}

	// Token: 0x0400276B RID: 10091
	public SimpleDetectClickScript[] Items;

	// Token: 0x0400276C RID: 10092
	public Animation SkirtAnimation;

	// Token: 0x0400276D RID: 10093
	public Animation GirlAnimation;

	// Token: 0x0400276E RID: 10094
	public GameObject Skirt;

	// Token: 0x0400276F RID: 10095
	public GameObject Girl;

	// Token: 0x04002770 RID: 10096
	public Renderer SkirtRenderer;

	// Token: 0x04002771 RID: 10097
	public Renderer GirlRenderer;

	// Token: 0x04002772 RID: 10098
	public Transform RightGridHighlightParent;

	// Token: 0x04002773 RID: 10099
	public Transform LeftGridHighlightParent;

	// Token: 0x04002774 RID: 10100
	public Transform RightGridItemParent;

	// Token: 0x04002775 RID: 10101
	public Transform LeftGridItemParent;

	// Token: 0x04002776 RID: 10102
	public Transform Highlight;

	// Token: 0x04002777 RID: 10103
	public Transform RightGrid;

	// Token: 0x04002778 RID: 10104
	public Transform LeftGrid;

	// Token: 0x04002779 RID: 10105
	public float Alpha;

	// Token: 0x0400277A RID: 10106
	public bool Open = true;

	// Token: 0x0400277B RID: 10107
	public int OpenSpace = 1;

	// Token: 0x0400277C RID: 10108
	public int UseColumn;

	// Token: 0x0400277D RID: 10109
	public int UseGrid;

	// Token: 0x0400277E RID: 10110
	public int Column = 1;

	// Token: 0x0400277F RID: 10111
	public int Grid = 1;

	// Token: 0x04002780 RID: 10112
	public int Row = 1;

	// Token: 0x04002781 RID: 10113
	public bool[] LeftSpaces1;

	// Token: 0x04002782 RID: 10114
	public bool[] LeftSpaces2;

	// Token: 0x04002783 RID: 10115
	public bool[] LeftSpaces3;

	// Token: 0x04002784 RID: 10116
	public bool[] LeftSpaces4;

	// Token: 0x04002785 RID: 10117
	public bool[] RightSpaces1;

	// Token: 0x04002786 RID: 10118
	public bool[] RightSpaces2;

	// Token: 0x04002787 RID: 10119
	public bool[] RightSpaces3;

	// Token: 0x04002788 RID: 10120
	public bool[] RightSpaces4;
}
