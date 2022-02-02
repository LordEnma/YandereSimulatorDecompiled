using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class ServicesScript : MonoBehaviour
{
	// Token: 0x06001C69 RID: 7273 RVA: 0x0014B4CC File Offset: 0x001496CC
	private void Start()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			this.ServicePurchased[i] = SchemeGlobals.GetServicePurchased(i);
			this.NameLabels[i].text = this.ServiceNames[i];
		}
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x0014B510 File Offset: 0x00149710
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
						base.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
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

	// Token: 0x06001C6B RID: 7275 RVA: 0x0014BCA4 File Offset: 0x00149EA4
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

	// Token: 0x06001C6C RID: 7276 RVA: 0x0014BF08 File Offset: 0x0014A108
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

	// Token: 0x06001C6D RID: 7277 RVA: 0x0014C056 File Offset: 0x0014A256
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x0014C074 File Offset: 0x0014A274
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

	// Token: 0x06001C6F RID: 7279 RVA: 0x0014C10C File Offset: 0x0014A30C
	public void SaveServicesPurchased()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			SchemeGlobals.SetServicePurchased(i, this.ServicePurchased[i]);
		}
	}

	// Token: 0x04003260 RID: 12896
	public TextMessageManagerScript TextMessageManager;

	// Token: 0x04003261 RID: 12897
	public StudentManagerScript StudentManager;

	// Token: 0x04003262 RID: 12898
	public InputManagerScript InputManager;

	// Token: 0x04003263 RID: 12899
	public ReputationScript Reputation;

	// Token: 0x04003264 RID: 12900
	public InventoryScript Inventory;

	// Token: 0x04003265 RID: 12901
	public PromptBarScript PromptBar;

	// Token: 0x04003266 RID: 12902
	public SchemesScript Schemes;

	// Token: 0x04003267 RID: 12903
	public YandereScript Yandere;

	// Token: 0x04003268 RID: 12904
	public GameObject FavorMenu;

	// Token: 0x04003269 RID: 12905
	public Transform Highlight;

	// Token: 0x0400326A RID: 12906
	public AudioSource MyAudio;

	// Token: 0x0400326B RID: 12907
	public PoliceScript Police;

	// Token: 0x0400326C RID: 12908
	public UITexture ServiceIcon;

	// Token: 0x0400326D RID: 12909
	public UILabel ServiceLimit;

	// Token: 0x0400326E RID: 12910
	public UILabel ServiceDesc;

	// Token: 0x0400326F RID: 12911
	public UILabel PantyCount;

	// Token: 0x04003270 RID: 12912
	public UILabel[] CostLabels;

	// Token: 0x04003271 RID: 12913
	public UILabel[] NameLabels;

	// Token: 0x04003272 RID: 12914
	public Texture[] ServiceIcons;

	// Token: 0x04003273 RID: 12915
	public string[] ServiceLimits;

	// Token: 0x04003274 RID: 12916
	public string[] ServiceDescs;

	// Token: 0x04003275 RID: 12917
	public string[] ServiceNames;

	// Token: 0x04003276 RID: 12918
	public bool[] ServiceAvailable;

	// Token: 0x04003277 RID: 12919
	public bool[] ServicePurchased;

	// Token: 0x04003278 RID: 12920
	public int[] ServiceCosts;

	// Token: 0x04003279 RID: 12921
	public int Selected = 1;

	// Token: 0x0400327A RID: 12922
	public int ID = 1;

	// Token: 0x0400327B RID: 12923
	public AudioClip InfoUnavailable;

	// Token: 0x0400327C RID: 12924
	public AudioClip InfoPurchase;

	// Token: 0x0400327D RID: 12925
	public AudioClip InfoAfford;
}
