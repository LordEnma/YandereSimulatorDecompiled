using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SchemesScript : MonoBehaviour
{
	// Token: 0x06001C86 RID: 7302 RVA: 0x0014EBBC File Offset: 0x0014CDBC
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

	// Token: 0x06001C87 RID: 7303 RVA: 0x0014ED38 File Offset: 0x0014CF38
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

	// Token: 0x06001C88 RID: 7304 RVA: 0x0014F08C File Offset: 0x0014D28C
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

	// Token: 0x06001C89 RID: 7305 RVA: 0x0014F168 File Offset: 0x0014D368
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

	// Token: 0x06001C8A RID: 7306 RVA: 0x0014F523 File Offset: 0x0014D723
	public void UpdatePantyCount()
	{
		if (this.Inventory != null)
		{
			this.PantyCount.text = this.Inventory.PantyShots.ToString();
		}
	}

	// Token: 0x06001C8B RID: 7307 RVA: 0x0014F550 File Offset: 0x0014D750
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

	// Token: 0x06001C8C RID: 7308 RVA: 0x0014F688 File Offset: 0x0014D888
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
			this.Scheme2Destinations[3] = this.StudentManager.Students[2].transform;
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

	// Token: 0x040032C7 RID: 12999
	public StudentManagerScript StudentManager;

	// Token: 0x040032C8 RID: 13000
	public SchemeManagerScript SchemeManager;

	// Token: 0x040032C9 RID: 13001
	public InputManagerScript InputManager;

	// Token: 0x040032CA RID: 13002
	public InventoryScript Inventory;

	// Token: 0x040032CB RID: 13003
	public PromptBarScript PromptBar;

	// Token: 0x040032CC RID: 13004
	public GameObject NextStepInput;

	// Token: 0x040032CD RID: 13005
	public GameObject FavorMenu;

	// Token: 0x040032CE RID: 13006
	public Transform Highlight;

	// Token: 0x040032CF RID: 13007
	public Transform Arrow;

	// Token: 0x040032D0 RID: 13008
	public UILabel SchemeInstructions;

	// Token: 0x040032D1 RID: 13009
	public UITexture SchemeIcon;

	// Token: 0x040032D2 RID: 13010
	public UILabel PantyCount;

	// Token: 0x040032D3 RID: 13011
	public UILabel SchemeDesc;

	// Token: 0x040032D4 RID: 13012
	public UILabel[] SchemeDeadlineLabels;

	// Token: 0x040032D5 RID: 13013
	public UILabel[] SchemeCostLabels;

	// Token: 0x040032D6 RID: 13014
	public UILabel[] SchemeNameLabels;

	// Token: 0x040032D7 RID: 13015
	public UISprite[] Exclamations;

	// Token: 0x040032D8 RID: 13016
	public Texture[] SchemeIcons;

	// Token: 0x040032D9 RID: 13017
	public int[] SchemeCosts;

	// Token: 0x040032DA RID: 13018
	public Transform[] SchemeDestinations;

	// Token: 0x040032DB RID: 13019
	public string[] SchemeDeadlines;

	// Token: 0x040032DC RID: 13020
	public string[] SchemeSkills;

	// Token: 0x040032DD RID: 13021
	public string[] SchemeDescs;

	// Token: 0x040032DE RID: 13022
	public string[] SchemeNames;

	// Token: 0x040032DF RID: 13023
	[Multiline]
	[SerializeField]
	public string[] SchemeSteps;

	// Token: 0x040032E0 RID: 13024
	public int ListPosition = 1;

	// Token: 0x040032E1 RID: 13025
	public int Limit = 20;

	// Token: 0x040032E2 RID: 13026
	public int ID = 1;

	// Token: 0x040032E3 RID: 13027
	public string[] Steps;

	// Token: 0x040032E4 RID: 13028
	public AudioClip InfoPurchase;

	// Token: 0x040032E5 RID: 13029
	public AudioClip InfoAfford;

	// Token: 0x040032E6 RID: 13030
	public Transform[] Scheme1Destinations;

	// Token: 0x040032E7 RID: 13031
	public Transform[] Scheme2Destinations;

	// Token: 0x040032E8 RID: 13032
	public Transform[] Scheme3Destinations;

	// Token: 0x040032E9 RID: 13033
	public Transform[] Scheme4Destinations;

	// Token: 0x040032EA RID: 13034
	public Transform[] Scheme5Destinations;

	// Token: 0x040032EB RID: 13035
	public bool[] DisableScheme;

	// Token: 0x040032EC RID: 13036
	public GameObject HUDIcon;

	// Token: 0x040032ED RID: 13037
	public UILabel HUDInstructions;
}
