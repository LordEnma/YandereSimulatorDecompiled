using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DropsScript : MonoBehaviour
{
	// Token: 0x060013BA RID: 5050 RVA: 0x000BA760 File Offset: 0x000B8960
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

	// Token: 0x060013BB RID: 5051 RVA: 0x000BA7E0 File Offset: 0x000B89E0
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

	// Token: 0x060013BC RID: 5052 RVA: 0x000BAA60 File Offset: 0x000B8C60
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

	// Token: 0x060013BD RID: 5053 RVA: 0x000BAB5C File Offset: 0x000B8D5C
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

	// Token: 0x060013BE RID: 5054 RVA: 0x000BAC75 File Offset: 0x000B8E75
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x04001D55 RID: 7509
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04001D56 RID: 7510
	public InputManagerScript InputManager;

	// Token: 0x04001D57 RID: 7511
	public InventoryScript Inventory;

	// Token: 0x04001D58 RID: 7512
	public PromptBarScript PromptBar;

	// Token: 0x04001D59 RID: 7513
	public SchemesScript Schemes;

	// Token: 0x04001D5A RID: 7514
	public GameObject FavorMenu;

	// Token: 0x04001D5B RID: 7515
	public Transform Highlight;

	// Token: 0x04001D5C RID: 7516
	public UILabel PantyCount;

	// Token: 0x04001D5D RID: 7517
	public UITexture DropIcon;

	// Token: 0x04001D5E RID: 7518
	public UILabel DropDesc;

	// Token: 0x04001D5F RID: 7519
	public UILabel[] CostLabels;

	// Token: 0x04001D60 RID: 7520
	public UILabel[] NameLabels;

	// Token: 0x04001D61 RID: 7521
	public bool[] InfiniteSupply;

	// Token: 0x04001D62 RID: 7522
	public bool[] Purchased;

	// Token: 0x04001D63 RID: 7523
	public Texture[] DropIcons;

	// Token: 0x04001D64 RID: 7524
	public int[] DropCosts;

	// Token: 0x04001D65 RID: 7525
	public string[] DropDescs;

	// Token: 0x04001D66 RID: 7526
	public string[] DropNames;

	// Token: 0x04001D67 RID: 7527
	public int Selected = 1;

	// Token: 0x04001D68 RID: 7528
	public int ID = 1;

	// Token: 0x04001D69 RID: 7529
	public AudioClip InfoUnavailable;

	// Token: 0x04001D6A RID: 7530
	public AudioClip InfoPurchase;

	// Token: 0x04001D6B RID: 7531
	public AudioClip InfoAfford;
}
