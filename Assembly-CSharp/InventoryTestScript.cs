using System;
using UnityEngine;

// Token: 0x0200033E RID: 830
public class InventoryTestScript : MonoBehaviour
{
	// Token: 0x060018EB RID: 6379 RVA: 0x000F96E4 File Offset: 0x000F78E4
	private void Start()
	{
		this.RightGrid.localScale = new Vector3(0f, 0f, 0f);
		this.LeftGrid.localScale = new Vector3(0f, 0f, 0f);
		Time.timeScale = 1f;
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x000F973C File Offset: 0x000F793C
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

	// Token: 0x060018ED RID: 6381 RVA: 0x000F9D78 File Offset: 0x000F7F78
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

	// Token: 0x060018EE RID: 6382 RVA: 0x000F9E04 File Offset: 0x000F8004
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

	// Token: 0x040026E9 RID: 9961
	public SimpleDetectClickScript[] Items;

	// Token: 0x040026EA RID: 9962
	public Animation SkirtAnimation;

	// Token: 0x040026EB RID: 9963
	public Animation GirlAnimation;

	// Token: 0x040026EC RID: 9964
	public GameObject Skirt;

	// Token: 0x040026ED RID: 9965
	public GameObject Girl;

	// Token: 0x040026EE RID: 9966
	public Renderer SkirtRenderer;

	// Token: 0x040026EF RID: 9967
	public Renderer GirlRenderer;

	// Token: 0x040026F0 RID: 9968
	public Transform RightGridHighlightParent;

	// Token: 0x040026F1 RID: 9969
	public Transform LeftGridHighlightParent;

	// Token: 0x040026F2 RID: 9970
	public Transform RightGridItemParent;

	// Token: 0x040026F3 RID: 9971
	public Transform LeftGridItemParent;

	// Token: 0x040026F4 RID: 9972
	public Transform Highlight;

	// Token: 0x040026F5 RID: 9973
	public Transform RightGrid;

	// Token: 0x040026F6 RID: 9974
	public Transform LeftGrid;

	// Token: 0x040026F7 RID: 9975
	public float Alpha;

	// Token: 0x040026F8 RID: 9976
	public bool Open = true;

	// Token: 0x040026F9 RID: 9977
	public int OpenSpace = 1;

	// Token: 0x040026FA RID: 9978
	public int UseColumn;

	// Token: 0x040026FB RID: 9979
	public int UseGrid;

	// Token: 0x040026FC RID: 9980
	public int Column = 1;

	// Token: 0x040026FD RID: 9981
	public int Grid = 1;

	// Token: 0x040026FE RID: 9982
	public int Row = 1;

	// Token: 0x040026FF RID: 9983
	public bool[] LeftSpaces1;

	// Token: 0x04002700 RID: 9984
	public bool[] LeftSpaces2;

	// Token: 0x04002701 RID: 9985
	public bool[] LeftSpaces3;

	// Token: 0x04002702 RID: 9986
	public bool[] LeftSpaces4;

	// Token: 0x04002703 RID: 9987
	public bool[] RightSpaces1;

	// Token: 0x04002704 RID: 9988
	public bool[] RightSpaces2;

	// Token: 0x04002705 RID: 9989
	public bool[] RightSpaces3;

	// Token: 0x04002706 RID: 9990
	public bool[] RightSpaces4;
}
