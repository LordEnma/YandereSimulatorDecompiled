using System;
using UnityEngine;

// Token: 0x02000294 RID: 660
public class DropsScript : MonoBehaviour
{
	// Token: 0x060013D3 RID: 5075 RVA: 0x000BC134 File Offset: 0x000BA334
	private void Start()
	{
		this.ID = 1;
		while (this.ID < this.DropNames.Length)
		{
			this.NameLabels[this.ID].text = this.DropNames[this.ID];
			this.ID++;
		}
		if (MissionModeGlobals.MissionMode)
		{
			this.CostLabels[6].text = "10";
			this.InfiniteSupply[6] = true;
			this.DropCosts[6] = 10;
		}
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x000BC1B4 File Offset: 0x000BA3B4
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = this.DropNames.Length - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > this.DropNames.Length - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (!this.Purchased[this.Selected] && this.InfoChanWindow.Orders < 11)
			{
				if (this.PromptBar.Label[0].text != string.Empty)
				{
					if (this.Inventory.PantyShots >= this.DropCosts[this.Selected])
					{
						this.Inventory.PantyShots -= this.DropCosts[this.Selected];
						if (!this.InfiniteSupply[this.Selected])
						{
							this.Purchased[this.Selected] = true;
						}
						this.InfoChanWindow.Orders++;
						this.InfoChanWindow.ItemsToDrop[this.InfoChanWindow.Orders] = this.Selected;
						this.InfoChanWindow.DropObject();
						this.UpdateList();
						this.UpdateDesc();
						component.clip = this.InfoPurchase;
						component.Play();
						if (this.Selected == 2)
						{
							SchemeGlobals.SetSchemeStage(3, 2);
							this.Schemes.UpdateInstructions();
						}
					}
				}
				else if (this.Inventory.PantyShots < this.DropCosts[this.Selected])
				{
					component.clip = this.InfoAfford;
					component.Play();
				}
				else
				{
					component.clip = this.InfoUnavailable;
					component.Play();
				}
			}
			else
			{
				component.clip = this.InfoUnavailable;
				component.Play();
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013D5 RID: 5077 RVA: 0x000BC434 File Offset: 0x000BA634
	public void UpdateList()
	{
		this.ID = 1;
		while (this.ID < this.DropNames.Length)
		{
			UILabel uilabel = this.NameLabels[this.ID];
			if (!this.Purchased[this.ID])
			{
				this.CostLabels[this.ID].text = this.DropCosts[this.ID].ToString();
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 1f);
			}
			else
			{
				this.CostLabels[this.ID].text = string.Empty;
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
			}
			this.ID++;
		}
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x000BC530 File Offset: 0x000BA730
	public void UpdateDesc()
	{
		if (!this.Purchased[this.Selected])
		{
			if (this.Inventory.PantyShots >= this.DropCosts[this.Selected])
			{
				this.PromptBar.Label[0].text = "Purchase";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
		this.DropIcon.mainTexture = this.DropIcons[this.Selected];
		this.DropDesc.text = this.DropDescs[this.Selected];
		this.UpdatePantyCount();
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x000BC649 File Offset: 0x000BA849
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x04001D92 RID: 7570
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04001D93 RID: 7571
	public InputManagerScript InputManager;

	// Token: 0x04001D94 RID: 7572
	public InventoryScript Inventory;

	// Token: 0x04001D95 RID: 7573
	public PromptBarScript PromptBar;

	// Token: 0x04001D96 RID: 7574
	public SchemesScript Schemes;

	// Token: 0x04001D97 RID: 7575
	public GameObject FavorMenu;

	// Token: 0x04001D98 RID: 7576
	public Transform Highlight;

	// Token: 0x04001D99 RID: 7577
	public UILabel PantyCount;

	// Token: 0x04001D9A RID: 7578
	public UITexture DropIcon;

	// Token: 0x04001D9B RID: 7579
	public UILabel DropDesc;

	// Token: 0x04001D9C RID: 7580
	public UILabel[] CostLabels;

	// Token: 0x04001D9D RID: 7581
	public UILabel[] NameLabels;

	// Token: 0x04001D9E RID: 7582
	public bool[] InfiniteSupply;

	// Token: 0x04001D9F RID: 7583
	public bool[] Purchased;

	// Token: 0x04001DA0 RID: 7584
	public Texture[] DropIcons;

	// Token: 0x04001DA1 RID: 7585
	public int[] DropCosts;

	// Token: 0x04001DA2 RID: 7586
	public string[] DropDescs;

	// Token: 0x04001DA3 RID: 7587
	public string[] DropNames;

	// Token: 0x04001DA4 RID: 7588
	public int Selected = 1;

	// Token: 0x04001DA5 RID: 7589
	public int ID = 1;

	// Token: 0x04001DA6 RID: 7590
	public AudioClip InfoUnavailable;

	// Token: 0x04001DA7 RID: 7591
	public AudioClip InfoPurchase;

	// Token: 0x04001DA8 RID: 7592
	public AudioClip InfoAfford;
}
