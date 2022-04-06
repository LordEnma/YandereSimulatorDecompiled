using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SchemesScript : MonoBehaviour
{
	// Token: 0x06001C74 RID: 7284 RVA: 0x0014D034 File Offset: 0x0014B234
	private void Start()
	{
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			if (!SchemeGlobals.GetSchemeStatus(i))
			{
				this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
				this.SchemeNameLabels[i].text = this.SchemeNames[i];
			}
		}
		this.DisableScheme[1] = true;
		this.DisableScheme[2] = true;
		this.DisableScheme[3] = true;
		this.DisableScheme[4] = true;
		this.DisableScheme[5] = true;
		this.DisableScheme[21] = true;
		this.DisableScheme[22] = true;
		this.DisableScheme[23] = true;
		this.DisableScheme[24] = true;
		this.DisableScheme[25] = true;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.DisableScheme[1] = false;
			this.DisableScheme[21] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			this.DisableScheme[2] = false;
			this.DisableScheme[22] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			this.DisableScheme[3] = false;
			this.DisableScheme[23] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			this.DisableScheme[4] = false;
			this.DisableScheme[24] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			this.DisableScheme[5] = false;
			this.DisableScheme[25] = false;
		}
		if (DateGlobals.Weekday != DayOfWeek.Monday)
		{
			this.DisableScheme[6] = true;
		}
		if (DateGlobals.Weekday != DayOfWeek.Thursday)
		{
			this.DisableScheme[20] = true;
		}
		if (this.NextStepInput != null)
		{
			this.NextStepInput.SetActive(false);
		}
		this.UpdateSchemeInfo();
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x0014D1B0 File Offset: 0x0014B3B0
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = this.Limit - 15;
					this.ID = 15;
				}
			}
			else
			{
				this.ID--;
			}
			this.UpdateSchemeInfo();
		}
		if (this.InputManager.TappedDown)
		{
			if (this.ID == 15)
			{
				this.ListPosition++;
				if (this.ID + this.ListPosition > this.Limit)
				{
					this.ListPosition = 0;
					this.ID = 1;
				}
			}
			else
			{
				this.ID++;
			}
			this.UpdateSchemeInfo();
		}
		if (Input.GetButtonDown("A"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (this.SchemeNameLabels[this.ID].color.a == 1f)
				{
					this.SchemeManager.enabled = true;
					this.SchemeManager.CurrentScheme = this.ID + this.ListPosition;
					if (this.ID == 5)
					{
						this.SchemeManager.ClockCheck = true;
					}
					if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
					{
						if (this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition])
						{
							this.Inventory.PantyShots -= this.SchemeCosts[this.ID + this.ListPosition];
							SchemeGlobals.SetSchemeUnlocked(this.ID + this.ListPosition, true);
							SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
							if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) == 0)
							{
								SchemeGlobals.SetSchemeStage(this.ID + this.ListPosition, 1);
							}
							this.UpdateSchemeDestinations();
							this.UpdateInstructions();
							this.UpdateSchemeList();
							this.UpdateSchemeInfo();
							component.clip = this.InfoPurchase;
							component.Play();
						}
					}
					else
					{
						if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
						{
							SchemeGlobals.CurrentScheme = 0;
							this.SchemeManager.CurrentScheme = 0;
							this.SchemeManager.enabled = false;
						}
						else
						{
							SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
						}
						this.UpdateSchemeDestinations();
						this.UpdateInstructions();
						this.UpdateSchemeInfo();
					}
				}
			}
			else if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100 && this.Inventory.PantyShots < this.SchemeCosts[this.ID + this.ListPosition])
			{
				component.clip = this.InfoAfford;
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

	// Token: 0x06001C76 RID: 7286 RVA: 0x0014D504 File Offset: 0x0014B704
	public void UpdateSchemeList()
	{
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			if (SchemeGlobals.GetSchemeStage(i + this.ListPosition) == 100)
			{
				UILabel uilabel = this.SchemeNameLabels[i];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
				this.SchemeCostLabels[i].text = string.Empty;
			}
			else
			{
				if (SchemeGlobals.GetSchemeUnlocked(i))
				{
					this.SchemeCostLabels[i].text = this.SchemeCosts[i].ToString();
				}
				else
				{
					this.SchemeCostLabels[i].text = string.Empty;
				}
				if (SchemeGlobals.GetSchemeStage(i) > SchemeGlobals.GetSchemePreviousStage(i))
				{
					SchemeGlobals.SetSchemePreviousStage(i, SchemeGlobals.GetSchemeStage(i));
				}
			}
		}
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x0014D5E0 File Offset: 0x0014B7E0
	public void UpdateSchemeInfo()
	{
		if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100)
		{
			if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
			{
				this.Arrow.gameObject.SetActive(false);
				if (this.Inventory != null)
				{
					this.PromptBar.Label[0].text = ((this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition]) ? "Purchase" : string.Empty);
				}
				this.PromptBar.UpdateButtons();
			}
			else if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
			{
				this.Arrow.gameObject.SetActive(true);
				this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, -10f - 21f * (float)SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition), this.Arrow.localPosition.z);
				this.PromptBar.Label[0].text = "Stop Tracking";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.PromptBar.Label[0].text = "Start Tracking";
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			this.SchemeNameLabels[i].text = this.SchemeNames[i + this.ListPosition];
			this.SchemeCostLabels[i].text = (this.SchemeCosts[i + this.ListPosition].ToString() ?? "");
			this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i + this.ListPosition];
			if (this.DisableScheme[i + this.ListPosition])
			{
				this.SchemeNameLabels[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				this.SchemeNameLabels[i].color = new Color(0f, 0f, 0f, 1f);
			}
			if (this.SchemeManager != null)
			{
				if (this.SchemeManager.CurrentScheme == i + this.ListPosition)
				{
					this.Exclamations[i].enabled = true;
				}
				else
				{
					this.Exclamations[i].enabled = false;
				}
			}
		}
		this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID + this.ListPosition];
		this.SchemeDesc.text = this.SchemeDescs[this.ID + this.ListPosition];
		if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) == 100)
		{
			this.SchemeInstructions.text = "This scheme is no longer available.";
		}
		else
		{
			this.SchemeInstructions.text = ((!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition)) ? ("Skills Required:\n" + this.SchemeSkills[this.ID + this.ListPosition]) : this.SchemeSteps[this.ID + this.ListPosition]);
		}
		this.UpdatePantyCount();
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x0014D99B File Offset: 0x0014BB9B
	public void UpdatePantyCount()
	{
		if (this.Inventory != null)
		{
			this.PantyCount.text = this.Inventory.PantyShots.ToString();
		}
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x0014D9C8 File Offset: 0x0014BBC8
	public void UpdateInstructions()
	{
		this.Steps = this.SchemeSteps[SchemeGlobals.CurrentScheme].Split(new char[]
		{
			'\n'
		});
		if (SchemeGlobals.CurrentScheme > 0)
		{
			if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 100)
			{
				if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 1)
				{
					SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, this.Steps.Length);
				}
				else if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) > this.Steps.Length)
				{
					SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 1);
				}
				this.HUDIcon.SetActive(true);
				this.HUDInstructions.text = this.Steps[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) - 1].ToString();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.HUDIcon.gameObject.SetActive(false);
				this.HUDInstructions.text = string.Empty;
				this.SchemeManager.CurrentScheme = 0;
			}
		}
		else
		{
			this.HUDIcon.SetActive(false);
			this.HUDInstructions.text = string.Empty;
		}
		if (SchemeGlobals.CurrentScheme < 7)
		{
			this.NextStepInput.SetActive(false);
			return;
		}
		this.NextStepInput.SetActive(true);
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x0014DB00 File Offset: 0x0014BD00
	public void UpdateSchemeDestinations()
	{
		if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
		{
			this.Scheme1Destinations[3] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme1Destinations[7] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[5] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[6] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
		}
		if (this.StudentManager.Students[2] != null)
		{
			this.Scheme2Destinations[1] = this.StudentManager.Students[2].transform;
		}
		if (this.StudentManager.Students[97] != null)
		{
			this.Scheme5Destinations[3] = this.StudentManager.Students[97].transform;
		}
		if (SchemeGlobals.CurrentScheme == 1)
		{
			this.SchemeDestinations = this.Scheme1Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 2)
		{
			this.SchemeDestinations = this.Scheme2Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 3)
		{
			this.SchemeDestinations = this.Scheme3Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 4)
		{
			this.SchemeDestinations = this.Scheme4Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 5)
		{
			this.SchemeDestinations = this.Scheme5Destinations;
		}
	}

	// Token: 0x04003290 RID: 12944
	public StudentManagerScript StudentManager;

	// Token: 0x04003291 RID: 12945
	public SchemeManagerScript SchemeManager;

	// Token: 0x04003292 RID: 12946
	public InputManagerScript InputManager;

	// Token: 0x04003293 RID: 12947
	public InventoryScript Inventory;

	// Token: 0x04003294 RID: 12948
	public PromptBarScript PromptBar;

	// Token: 0x04003295 RID: 12949
	public GameObject NextStepInput;

	// Token: 0x04003296 RID: 12950
	public GameObject FavorMenu;

	// Token: 0x04003297 RID: 12951
	public Transform Highlight;

	// Token: 0x04003298 RID: 12952
	public Transform Arrow;

	// Token: 0x04003299 RID: 12953
	public UILabel SchemeInstructions;

	// Token: 0x0400329A RID: 12954
	public UITexture SchemeIcon;

	// Token: 0x0400329B RID: 12955
	public UILabel PantyCount;

	// Token: 0x0400329C RID: 12956
	public UILabel SchemeDesc;

	// Token: 0x0400329D RID: 12957
	public UILabel[] SchemeDeadlineLabels;

	// Token: 0x0400329E RID: 12958
	public UILabel[] SchemeCostLabels;

	// Token: 0x0400329F RID: 12959
	public UILabel[] SchemeNameLabels;

	// Token: 0x040032A0 RID: 12960
	public UISprite[] Exclamations;

	// Token: 0x040032A1 RID: 12961
	public Texture[] SchemeIcons;

	// Token: 0x040032A2 RID: 12962
	public int[] SchemeCosts;

	// Token: 0x040032A3 RID: 12963
	public Transform[] SchemeDestinations;

	// Token: 0x040032A4 RID: 12964
	public string[] SchemeDeadlines;

	// Token: 0x040032A5 RID: 12965
	public string[] SchemeSkills;

	// Token: 0x040032A6 RID: 12966
	public string[] SchemeDescs;

	// Token: 0x040032A7 RID: 12967
	public string[] SchemeNames;

	// Token: 0x040032A8 RID: 12968
	[Multiline]
	[SerializeField]
	public string[] SchemeSteps;

	// Token: 0x040032A9 RID: 12969
	public int ListPosition = 1;

	// Token: 0x040032AA RID: 12970
	public int Limit = 20;

	// Token: 0x040032AB RID: 12971
	public int ID = 1;

	// Token: 0x040032AC RID: 12972
	public string[] Steps;

	// Token: 0x040032AD RID: 12973
	public AudioClip InfoPurchase;

	// Token: 0x040032AE RID: 12974
	public AudioClip InfoAfford;

	// Token: 0x040032AF RID: 12975
	public Transform[] Scheme1Destinations;

	// Token: 0x040032B0 RID: 12976
	public Transform[] Scheme2Destinations;

	// Token: 0x040032B1 RID: 12977
	public Transform[] Scheme3Destinations;

	// Token: 0x040032B2 RID: 12978
	public Transform[] Scheme4Destinations;

	// Token: 0x040032B3 RID: 12979
	public Transform[] Scheme5Destinations;

	// Token: 0x040032B4 RID: 12980
	public bool[] DisableScheme;

	// Token: 0x040032B5 RID: 12981
	public GameObject HUDIcon;

	// Token: 0x040032B6 RID: 12982
	public UILabel HUDInstructions;
}
