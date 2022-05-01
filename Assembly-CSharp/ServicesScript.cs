using System;
using UnityEngine;

// Token: 0x02000425 RID: 1061
public class ServicesScript : MonoBehaviour
{
	// Token: 0x06001CA5 RID: 7333 RVA: 0x0014F314 File Offset: 0x0014D514
	private void Start()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			this.ServicePurchased[i] = SchemeGlobals.GetServicePurchased(i);
			this.NameLabels[i].text = this.ServiceNames[i];
		}
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x0014F358 File Offset: 0x0014D558
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

	// Token: 0x06001CA7 RID: 7335 RVA: 0x0014FAE4 File Offset: 0x0014DCE4
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
			if (this.StudentManager != null && this.StudentManager.MissionMode)
			{
				this.ServiceAvailable[5] = false;
			}
			UILabel uilabel = this.NameLabels[this.ID];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, this.ServiceAvailable[this.ID] ? 1f : 0.5f);
			this.ID++;
		}
	}

	// Token: 0x06001CA8 RID: 7336 RVA: 0x0014FD58 File Offset: 0x0014DF58
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

	// Token: 0x06001CA9 RID: 7337 RVA: 0x0014FEA6 File Offset: 0x0014E0A6
	public void UpdatePantyCount()
	{
		this.PantyCount.text = this.Inventory.PantyShots.ToString();
	}

	// Token: 0x06001CAA RID: 7338 RVA: 0x0014FEC4 File Offset: 0x0014E0C4
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

	// Token: 0x06001CAB RID: 7339 RVA: 0x0014FF5C File Offset: 0x0014E15C
	public void SaveServicesPurchased()
	{
		for (int i = 1; i < this.ServiceNames.Length; i++)
		{
			SchemeGlobals.SetServicePurchased(i, this.ServicePurchased[i]);
		}
	}

	// Token: 0x040032FD RID: 13053
	public TextMessageManagerScript TextMessageManager;

	// Token: 0x040032FE RID: 13054
	public StudentManagerScript StudentManager;

	// Token: 0x040032FF RID: 13055
	public InputManagerScript InputManager;

	// Token: 0x04003300 RID: 13056
	public ReputationScript Reputation;

	// Token: 0x04003301 RID: 13057
	public InventoryScript Inventory;

	// Token: 0x04003302 RID: 13058
	public PromptBarScript PromptBar;

	// Token: 0x04003303 RID: 13059
	public SchemesScript Schemes;

	// Token: 0x04003304 RID: 13060
	public YandereScript Yandere;

	// Token: 0x04003305 RID: 13061
	public GameObject FavorMenu;

	// Token: 0x04003306 RID: 13062
	public Transform Highlight;

	// Token: 0x04003307 RID: 13063
	public AudioSource MyAudio;

	// Token: 0x04003308 RID: 13064
	public PoliceScript Police;

	// Token: 0x04003309 RID: 13065
	public UITexture ServiceIcon;

	// Token: 0x0400330A RID: 13066
	public UILabel ServiceLimit;

	// Token: 0x0400330B RID: 13067
	public UILabel ServiceDesc;

	// Token: 0x0400330C RID: 13068
	public UILabel PantyCount;

	// Token: 0x0400330D RID: 13069
	public UILabel[] CostLabels;

	// Token: 0x0400330E RID: 13070
	public UILabel[] NameLabels;

	// Token: 0x0400330F RID: 13071
	public Texture[] ServiceIcons;

	// Token: 0x04003310 RID: 13072
	public string[] ServiceLimits;

	// Token: 0x04003311 RID: 13073
	public string[] ServiceDescs;

	// Token: 0x04003312 RID: 13074
	public string[] ServiceNames;

	// Token: 0x04003313 RID: 13075
	public bool[] ServiceAvailable;

	// Token: 0x04003314 RID: 13076
	public bool[] ServicePurchased;

	// Token: 0x04003315 RID: 13077
	public int[] ServiceCosts;

	// Token: 0x04003316 RID: 13078
	public int Selected = 1;

	// Token: 0x04003317 RID: 13079
	public int ID = 1;

	// Token: 0x04003318 RID: 13080
	public AudioClip InfoUnavailable;

	// Token: 0x04003319 RID: 13081
	public AudioClip InfoPurchase;

	// Token: 0x0400331A RID: 13082
	public AudioClip InfoAfford;
}
