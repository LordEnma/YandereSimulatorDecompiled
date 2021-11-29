using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class DropsScript : MonoBehaviour
{
	// Token: 0x060013AB RID: 5035 RVA: 0x000B9C98 File Offset: 0x000B7E98
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

	// Token: 0x060013AC RID: 5036 RVA: 0x000B9D18 File Offset: 0x000B7F18
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

	// Token: 0x060013AD RID: 5037 RVA: 0x000B9F98 File Offset: 0x000B8198
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

	// Token: 0x060013AE RID: 5038 RVA: 0x000BA094 File Offset: 0x000B8294
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

	// Token: 0x060013AF RID: 5039 RVA: 0x000BA1AD File Offset: 0x000B83AD
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x04001D25 RID: 7461
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04001D26 RID: 7462
	public InputManagerScript InputManager;

	// Token: 0x04001D27 RID: 7463
	public InventoryScript Inventory;

	// Token: 0x04001D28 RID: 7464
	public PromptBarScript PromptBar;

	// Token: 0x04001D29 RID: 7465
	public SchemesScript Schemes;

	// Token: 0x04001D2A RID: 7466
	public GameObject FavorMenu;

	// Token: 0x04001D2B RID: 7467
	public Transform Highlight;

	// Token: 0x04001D2C RID: 7468
	public UILabel PantyCount;

	// Token: 0x04001D2D RID: 7469
	public UITexture DropIcon;

	// Token: 0x04001D2E RID: 7470
	public UILabel DropDesc;

	// Token: 0x04001D2F RID: 7471
	public UILabel[] CostLabels;

	// Token: 0x04001D30 RID: 7472
	public UILabel[] NameLabels;

	// Token: 0x04001D31 RID: 7473
	public bool[] InfiniteSupply;

	// Token: 0x04001D32 RID: 7474
	public bool[] Purchased;

	// Token: 0x04001D33 RID: 7475
	public Texture[] DropIcons;

	// Token: 0x04001D34 RID: 7476
	public int[] DropCosts;

	// Token: 0x04001D35 RID: 7477
	public string[] DropDescs;

	// Token: 0x04001D36 RID: 7478
	public string[] DropNames;

	// Token: 0x04001D37 RID: 7479
	public int Selected = 1;

	// Token: 0x04001D38 RID: 7480
	public int ID = 1;

	// Token: 0x04001D39 RID: 7481
	public AudioClip InfoUnavailable;

	// Token: 0x04001D3A RID: 7482
	public AudioClip InfoPurchase;

	// Token: 0x04001D3B RID: 7483
	public AudioClip InfoAfford;
}
