using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DropsScript : MonoBehaviour
{
	// Token: 0x060013B2 RID: 5042 RVA: 0x000BA47C File Offset: 0x000B867C
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

	// Token: 0x060013B3 RID: 5043 RVA: 0x000BA4FC File Offset: 0x000B86FC
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

	// Token: 0x060013B4 RID: 5044 RVA: 0x000BA77C File Offset: 0x000B897C
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

	// Token: 0x060013B5 RID: 5045 RVA: 0x000BA878 File Offset: 0x000B8A78
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

	// Token: 0x060013B6 RID: 5046 RVA: 0x000BA991 File Offset: 0x000B8B91
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x04001D48 RID: 7496
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04001D49 RID: 7497
	public InputManagerScript InputManager;

	// Token: 0x04001D4A RID: 7498
	public InventoryScript Inventory;

	// Token: 0x04001D4B RID: 7499
	public PromptBarScript PromptBar;

	// Token: 0x04001D4C RID: 7500
	public SchemesScript Schemes;

	// Token: 0x04001D4D RID: 7501
	public GameObject FavorMenu;

	// Token: 0x04001D4E RID: 7502
	public Transform Highlight;

	// Token: 0x04001D4F RID: 7503
	public UILabel PantyCount;

	// Token: 0x04001D50 RID: 7504
	public UITexture DropIcon;

	// Token: 0x04001D51 RID: 7505
	public UILabel DropDesc;

	// Token: 0x04001D52 RID: 7506
	public UILabel[] CostLabels;

	// Token: 0x04001D53 RID: 7507
	public UILabel[] NameLabels;

	// Token: 0x04001D54 RID: 7508
	public bool[] InfiniteSupply;

	// Token: 0x04001D55 RID: 7509
	public bool[] Purchased;

	// Token: 0x04001D56 RID: 7510
	public Texture[] DropIcons;

	// Token: 0x04001D57 RID: 7511
	public int[] DropCosts;

	// Token: 0x04001D58 RID: 7512
	public string[] DropDescs;

	// Token: 0x04001D59 RID: 7513
	public string[] DropNames;

	// Token: 0x04001D5A RID: 7514
	public int Selected = 1;

	// Token: 0x04001D5B RID: 7515
	public int ID = 1;

	// Token: 0x04001D5C RID: 7516
	public AudioClip InfoUnavailable;

	// Token: 0x04001D5D RID: 7517
	public AudioClip InfoPurchase;

	// Token: 0x04001D5E RID: 7518
	public AudioClip InfoAfford;
}
