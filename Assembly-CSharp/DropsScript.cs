using System;
using UnityEngine;

// Token: 0x02000292 RID: 658
public class DropsScript : MonoBehaviour
{
	// Token: 0x060013C3 RID: 5059 RVA: 0x000BB208 File Offset: 0x000B9408
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

	// Token: 0x060013C4 RID: 5060 RVA: 0x000BB288 File Offset: 0x000B9488
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

	// Token: 0x060013C5 RID: 5061 RVA: 0x000BB508 File Offset: 0x000B9708
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

	// Token: 0x060013C6 RID: 5062 RVA: 0x000BB604 File Offset: 0x000B9804
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

	// Token: 0x060013C7 RID: 5063 RVA: 0x000BB71D File Offset: 0x000B991D
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x04001D6D RID: 7533
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04001D6E RID: 7534
	public InputManagerScript InputManager;

	// Token: 0x04001D6F RID: 7535
	public InventoryScript Inventory;

	// Token: 0x04001D70 RID: 7536
	public PromptBarScript PromptBar;

	// Token: 0x04001D71 RID: 7537
	public SchemesScript Schemes;

	// Token: 0x04001D72 RID: 7538
	public GameObject FavorMenu;

	// Token: 0x04001D73 RID: 7539
	public Transform Highlight;

	// Token: 0x04001D74 RID: 7540
	public UILabel PantyCount;

	// Token: 0x04001D75 RID: 7541
	public UITexture DropIcon;

	// Token: 0x04001D76 RID: 7542
	public UILabel DropDesc;

	// Token: 0x04001D77 RID: 7543
	public UILabel[] CostLabels;

	// Token: 0x04001D78 RID: 7544
	public UILabel[] NameLabels;

	// Token: 0x04001D79 RID: 7545
	public bool[] InfiniteSupply;

	// Token: 0x04001D7A RID: 7546
	public bool[] Purchased;

	// Token: 0x04001D7B RID: 7547
	public Texture[] DropIcons;

	// Token: 0x04001D7C RID: 7548
	public int[] DropCosts;

	// Token: 0x04001D7D RID: 7549
	public string[] DropDescs;

	// Token: 0x04001D7E RID: 7550
	public string[] DropNames;

	// Token: 0x04001D7F RID: 7551
	public int Selected = 1;

	// Token: 0x04001D80 RID: 7552
	public int ID = 1;

	// Token: 0x04001D81 RID: 7553
	public AudioClip InfoUnavailable;

	// Token: 0x04001D82 RID: 7554
	public AudioClip InfoPurchase;

	// Token: 0x04001D83 RID: 7555
	public AudioClip InfoAfford;
}
