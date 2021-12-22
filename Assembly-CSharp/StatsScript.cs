using System;
using System.IO;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class StatsScript : MonoBehaviour
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x00157C50 File Offset: 0x00155E50
	private void Awake()
	{
		this.ClubLabels = new ClubTypeAndStringDictionary
		{
			{
				ClubType.None,
				"None"
			},
			{
				ClubType.Cooking,
				"Cooking"
			},
			{
				ClubType.Drama,
				"Drama"
			},
			{
				ClubType.Occult,
				"Occult"
			},
			{
				ClubType.Art,
				"Art"
			},
			{
				ClubType.LightMusic,
				"Light Music"
			},
			{
				ClubType.MartialArts,
				"Martial Arts"
			},
			{
				ClubType.Photography,
				"Photography"
			},
			{
				ClubType.Science,
				"Science"
			},
			{
				ClubType.Sports,
				"Sports"
			},
			{
				ClubType.Gardening,
				"Gardening"
			},
			{
				ClubType.Gaming,
				"Gaming"
			}
		};
	}

	// Token: 0x06001CF8 RID: 7416 RVA: 0x00157CFC File Offset: 0x00155EFC
	private void Start()
	{
		if (this.PauseScreen.Eighties)
		{
			this.Portrait.mainTexture = this.RyobaPortrait;
		}
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortrait.txt") && File.ReadAllText(Application.streamingAssetsPath + "/CustomPortrait.txt") == "1")
		{
			WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/CustomPortrait.png");
			this.Portrait.mainTexture = www.texture;
		}
	}

	// Token: 0x06001CF9 RID: 7417 RVA: 0x00157D88 File Offset: 0x00155F88
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CFA RID: 7418 RVA: 0x00157E34 File Offset: 0x00156034
	public void UpdateStats()
	{
		Debug.Log("The Stats script just checked the Class script for info and updated the bars accordingly.");
		this.Grade = this.Class.BiologyGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite = this.Subject1Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite.color = new Color(1f, 1f, 1f, 1f);
				this.Grade--;
			}
			else
			{
				uisprite.color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.BiologyGrade < 5)
		{
			this.Subject1Bars[this.Class.BiologyGrade + 1].color = ((this.Class.BiologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.ChemistryGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite2 = this.Subject2Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.ChemistryGrade < 5)
		{
			this.Subject2Bars[this.Class.ChemistryGrade + 1].color = ((this.Class.ChemistryBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.LanguageGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite3 = this.Subject3Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.LanguageGrade < 5)
		{
			this.Subject3Bars[this.Class.LanguageGrade + 1].color = ((this.Class.LanguageBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.PhysicalGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite4 = this.Subject4Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.PhysicalGrade < 5)
		{
			this.Subject4Bars[this.Class.PhysicalGrade + 1].color = ((this.Class.PhysicalBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.PsychologyGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite5 = this.Subject5Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.PsychologyGrade < 5)
		{
			this.Subject5Bars[this.Class.PsychologyGrade + 1].color = ((this.Class.PsychologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Seduction;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite6 = this.Subject6Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Seduction < 5)
		{
			this.Subject6Bars[this.Class.Seduction + 1].color = ((this.Class.SeductionBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Numbness;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite7 = this.Subject7Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Numbness < 5)
		{
			this.Subject7Bars[this.Class.Numbness + 1].color = ((this.Class.NumbnessBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Enlightenment;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite8 = this.Subject8Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Enlightenment < 5)
		{
			this.Subject8Bars[this.Class.Enlightenment + 1].color = ((this.Class.EnlightenmentBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Ranks[1].text = "Rank: " + this.Class.BiologyGrade.ToString();
		this.Ranks[2].text = "Rank: " + this.Class.ChemistryGrade.ToString();
		this.Ranks[3].text = "Rank: " + this.Class.LanguageGrade.ToString();
		this.Ranks[4].text = "Rank: " + this.Class.PhysicalGrade.ToString();
		this.Ranks[5].text = "Rank: " + this.Class.PsychologyGrade.ToString();
		this.Ranks[6].text = "Rank: " + this.Class.Seduction.ToString();
		this.Ranks[7].text = "Rank: " + this.Class.Numbness.ToString();
		this.Ranks[8].text = "Rank: " + this.Class.Enlightenment.ToString();
		ClubType club = this.PauseScreen.Yandere.Club;
		string str;
		this.ClubLabels.TryGetValue(club, out str);
		this.ClubLabel.text = "Club: " + str;
	}

	// Token: 0x0400349F RID: 13471
	public PauseScreenScript PauseScreen;

	// Token: 0x040034A0 RID: 13472
	public PromptBarScript PromptBar;

	// Token: 0x040034A1 RID: 13473
	public ClassScript Class;

	// Token: 0x040034A2 RID: 13474
	public UISprite[] Subject1Bars;

	// Token: 0x040034A3 RID: 13475
	public UISprite[] Subject2Bars;

	// Token: 0x040034A4 RID: 13476
	public UISprite[] Subject3Bars;

	// Token: 0x040034A5 RID: 13477
	public UISprite[] Subject4Bars;

	// Token: 0x040034A6 RID: 13478
	public UISprite[] Subject5Bars;

	// Token: 0x040034A7 RID: 13479
	public UISprite[] Subject6Bars;

	// Token: 0x040034A8 RID: 13480
	public UISprite[] Subject7Bars;

	// Token: 0x040034A9 RID: 13481
	public UISprite[] Subject8Bars;

	// Token: 0x040034AA RID: 13482
	public UILabel[] Ranks;

	// Token: 0x040034AB RID: 13483
	public UILabel ClubLabel;

	// Token: 0x040034AC RID: 13484
	public int Grade;

	// Token: 0x040034AD RID: 13485
	public int BarID;

	// Token: 0x040034AE RID: 13486
	public UITexture Portrait;

	// Token: 0x040034AF RID: 13487
	public Texture RyobaPortrait;

	// Token: 0x040034B0 RID: 13488
	private ClubTypeAndStringDictionary ClubLabels;
}
