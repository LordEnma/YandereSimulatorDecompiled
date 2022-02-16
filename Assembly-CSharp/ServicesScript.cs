using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ServicesScript : MonoBehaviour
{
	// Token: 0x06001C72 RID: 7282 RVA: 0x0014BA68 File Offset: 0x00149C68
	private void Start()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			this.ServicePurchased[i] = SchemeGlobals.GetServicePurchased(i);
			this.NameLabels[i].text = this.ServiceNames[i];
		}
	}

	// Token: 0x06001C73 RID: 7283 RVA: 0x0014BAAC File Offset: 0x00149CAC
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Selected--;
			if (this.Selected < 1)
			{
				this.Selected = this.ServiceNames.Length - 1;
			}
			this.UpdateDesc();
		}
		if (this.InputManager.TappedDown)
		{
			this.Selected++;
			if (this.Selected > this.ServiceNames.Length - 1)
			{
				this.Selected = 1;
			}
			this.UpdateDesc();
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.ServicePurchased[this.Selected] || (double)this.NameLabels[this.Selected].color.a != 1.0)
			{
				this.MyAudio.clip = this.InfoUnavailable;
				this.MyAudio.Play();
				return;
			}
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (this.Inventory.PantyShots >= this.ServiceCosts[this.Selected])
				{
					if (this.Selected == 1)
					{
						this.Yandere.PauseScreen.StudentInfoMenu.GettingInfo = true;
						this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						this.Yandere.PauseScreen.StudentInfoMenu.GrabPortraitsNextFrame = true;
						this.Yandere.PromptBar.ClearButtons();
						this.Yandere.PromptBar.Label[1].text = "Cancel";
						this.Yandere.PromptBar.UpdateButtons();
						this.Yandere.PromptBar.Show = true;
						base.gameObject.SetActive(false);
						return;
					}
					if (this.Selected == 2)
					{
						this.Reputation.PendingRep += 5f;
						this.Purchase();
						return;
					}
					if (this.Selected == 3)
					{
						this.StudentManager.StudentReps[this.StudentManager.RivalID] -= 5f;
						this.Purchase();
						return;
					}
					if (this.Selected == 4)
					{
						this.ServicePurchased[this.Selected] = true;
						this.StudentManager.EmbarassingSecret = true;
						this.Purchase();
						return;
					}
					if (this.Selected == 5)
					{
						this.Yandere.PauseScreen.StudentInfoMenu.SendingHome = true;
						this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
						base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
						this.Yandere.PromptBar.ClearButtons();
						this.Yandere.PromptBar.Label[1].text = "Cancel";
						this.Yandere.PromptBar.UpdateButtons();
						this.Yandere.PromptBar.Show = true;
						base.gameObject.SetActive(false);
						return;
					}
					if (this.Selected == 6)
					{
						this.Police.Timer += 300f;
						this.Police.Delayed = true;
						this.Purchase();
						return;
					}
					if (this.Selected == 7)
					{
						this.ServicePurchased[this.Selected] = true;
						this.StudentManager.Police.EndOfDay.Counselor.CounselorTape = 1;
						this.Purchase();
						return;
					}
					if (this.Selected == 8)
					{
						this.Yandere.PauseScreen.StudentInfoMenu.GettingOpinions = true;
						this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
						this.Yandere.PromptBar.ClearButtons();
						this.Yandere.PromptBar.Label[0].text = "Get Opinions";
						this.Yandere.PromptBar.Label[1].text = "Cancel";
						this.Yandere.PromptBar.UpdateButtons();
						this.Yandere.PromptBar.Show = true;
						base.gameObject.SetActive(false);
						return;
					}
					if (this.Selected == 9)
					{
						this.Yandere.PauseScreen.StudentInfoMenu.FiringCouncilMember = true;
						this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
						this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
						this.Yandere.PauseScreen.Sideways = true;
						this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
						this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
						base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
						this.Yandere.PromptBar.ClearButtons();
						this.Yandere.PromptBar.Label[1].text = "Cancel";
						this.Yandere.PromptBar.UpdateButtons();
						this.Yandere.PromptBar.Show = true;
						base.gameObject.SetActive(false);
						return;
					}
					if (this.Selected == 10)
					{
						this.ServicePurchased[this.Selected] = true;
						this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
						this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
						this.Purchase();
						return;
					}
				}
			}
			else
			{
				if (this.Inventory.PantyShots < this.ServiceCosts[this.Selected])
				{
					this.MyAudio.clip = this.InfoAfford;
					this.MyAudio.Play();
					return;
				}
				this.MyAudio.clip = this.InfoUnavailable;
				this.MyAudio.Play();
				return;
			}
		}
		else if (Input.GetButtonDown("B"))
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

	// Token: 0x06001C74 RID: 7284 RVA: 0x0014C238 File Offset: 0x0014A438
	public void UpdateList()
	{
		this.ID = 1;
		while (this.ID < this.ServiceNames.Length)
		{
			this.CostLabels[this.ID].text = this.ServiceCosts[this.ID].ToString();
			this.ServiceAvailable[this.ID] = false;
			if (this.ID == 1 || this.ID == 2 || this.ID == 3)
			{
				this.ServiceAvailable[this.ID] = true;
			}
			else if (this.ID == 4)
			{
				if (!this.StudentManager.EmbarassingSecret)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 5)
			{
				if (!this.ServicePurchased[this.ID])
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 6)
			{
				if (this.Police.Show && !this.Police.Delayed)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 7)
			{
				if (this.StudentManager.Police.EndOfDay.Counselor.CounselorTape == 0)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 8)
			{
				if (!this.ServicePurchased[8])
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 9)
			{
				if (MissionModeGlobals.MissionMode)
				{
					this.ServiceAvailable[this.ID] = true;
				}
			}
			else if (this.ID == 10 && (!this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 || !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2))
			{
				this.ServiceAvailable[this.ID] = true;
			}
			if (this.StudentManager.MissionMode)
			{
				this.ServiceAvailable[5] = false;
			}
			UILabel uilabel = this.NameLabels[this.ID];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, this.ServiceAvailable[this.ID] ? 1f : 0.5f);
			this.ID++;
		}
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x0014C49C File Offset: 0x0014A69C
	public void UpdateDesc()
	{
		if (this.ServiceAvailable[this.Selected] && !this.ServicePurchased[this.Selected])
		{
			this.PromptBar.Label[0].text = ((this.Inventory.PantyShots >= this.ServiceCosts[this.Selected]) ? "Purchase" : string.Empty);
			this.PromptBar.UpdateButtons();
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.Selected, this.Highlight.localPosition.z);
		this.ServiceIcon.mainTexture = this.ServiceIcons[this.Selected];
		this.ServiceLimit.text = this.ServiceLimits[this.Selected];
		this.ServiceDesc.text = this.ServiceDescs[this.Selected];
		if (this.Selected == 5)
		{
			this.ServiceDesc.text = this.ServiceDescs[this.Selected] + "\n\nIf student portraits don't appear, back out of the menu, load the Student Info menu, then return to this screen.";
		}
		this.UpdatePantyCount();
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x0014C5EA File Offset: 0x0014A7EA
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014C608 File Offset: 0x0014A808
	public void Purchase()
	{
		this.TextMessageManager.SpawnMessage(this.Selected);
		this.Inventory.PantyShots -= this.ServiceCosts[this.Selected];
		AudioSource.PlayClipAtPoint(this.InfoPurchase, base.transform.position);
		this.UpdateList();
		this.UpdateDesc();
		this.PromptBar.Label[0].text = string.Empty;
		this.PromptBar.Label[1].text = "Back";
		this.PromptBar.UpdateButtons();
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x0014C6A0 File Offset: 0x0014A8A0
	public void SaveServicesPurchased()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			SchemeGlobals.SetServicePurchased(i, this.ServicePurchased[i]);
		}
	}

	// Token: 0x0400326A RID: 12906
	public TextMessageManagerScript TextMessageManager;

	// Token: 0x0400326B RID: 12907
	public StudentManagerScript StudentManager;

	// Token: 0x0400326C RID: 12908
	public InputManagerScript InputManager;

	// Token: 0x0400326D RID: 12909
	public ReputationScript Reputation;

	// Token: 0x0400326E RID: 12910
	public InventoryScript Inventory;

	// Token: 0x0400326F RID: 12911
	public PromptBarScript PromptBar;

	// Token: 0x04003270 RID: 12912
	public SchemesScript Schemes;

	// Token: 0x04003271 RID: 12913
	public YandereScript Yandere;

	// Token: 0x04003272 RID: 12914
	public GameObject FavorMenu;

	// Token: 0x04003273 RID: 12915
	public Transform Highlight;

	// Token: 0x04003274 RID: 12916
	public AudioSource MyAudio;

	// Token: 0x04003275 RID: 12917
	public PoliceScript Police;

	// Token: 0x04003276 RID: 12918
	public UITexture ServiceIcon;

	// Token: 0x04003277 RID: 12919
	public UILabel ServiceLimit;

	// Token: 0x04003278 RID: 12920
	public UILabel ServiceDesc;

	// Token: 0x04003279 RID: 12921
	public UILabel PantyCount;

	// Token: 0x0400327A RID: 12922
	public UILabel[] CostLabels;

	// Token: 0x0400327B RID: 12923
	public UILabel[] NameLabels;

	// Token: 0x0400327C RID: 12924
	public Texture[] ServiceIcons;

	// Token: 0x0400327D RID: 12925
	public string[] ServiceLimits;

	// Token: 0x0400327E RID: 12926
	public string[] ServiceDescs;

	// Token: 0x0400327F RID: 12927
	public string[] ServiceNames;

	// Token: 0x04003280 RID: 12928
	public bool[] ServiceAvailable;

	// Token: 0x04003281 RID: 12929
	public bool[] ServicePurchased;

	// Token: 0x04003282 RID: 12930
	public int[] ServiceCosts;

	// Token: 0x04003283 RID: 12931
	public int Selected = 1;

	// Token: 0x04003284 RID: 12932
	public int ID = 1;

	// Token: 0x04003285 RID: 12933
	public AudioClip InfoUnavailable;

	// Token: 0x04003286 RID: 12934
	public AudioClip InfoPurchase;

	// Token: 0x04003287 RID: 12935
	public AudioClip InfoAfford;
}
