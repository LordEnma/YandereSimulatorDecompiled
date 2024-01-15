using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public ClassScript Class;

	public UISprite[] Subject1Bars;

	public UISprite[] Subject2Bars;

	public UISprite[] Subject3Bars;

	public UISprite[] Subject4Bars;

	public UISprite[] Subject5Bars;

	public UISprite[] Subject6Bars;

	public UISprite[] Subject7Bars;

	public UISprite[] Subject8Bars;

	public UILabel[] Ranks;

	public UILabel ClubLabel;

	public UILabel RepLabel;

	public int Grade;

	public int BarID;

	public UITexture Portrait;

	public Texture RyobaPortrait;

	private ClubTypeAndStringDictionary ClubLabels;

	private void Awake()
	{
		ClubLabels = new ClubTypeAndStringDictionary
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
			},
			{
				ClubType.Newspaper,
				"Newspaper"
			}
		};
	}

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			Portrait.mainTexture = RyobaPortrait;
		}
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortrait.txt") && File.ReadAllText(Application.streamingAssetsPath + "/CustomPortrait.txt") == "1")
		{
			WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/CustomPortrait.png");
			Portrait.mainTexture = wWW.texture;
		}
		if (GameGlobals.CustomMode)
		{
			WWW wWW2 = new WWW("file:///" + Application.streamingAssetsPath + "/YanderePortrait.png");
			Portrait.mainTexture = wWW2.texture;
		}
		string text = "";
		text = ((PlayerGlobals.Reputation > 33.33333f) ? "High" : ((!(PlayerGlobals.Reputation < -33.33333f)) ? "Neutral" : "Low"));
		RepLabel.text = "Reputation: " + PlayerGlobals.Reputation + " (" + text + ")";
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.UpdateButtons();
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateStats()
	{
		Debug.Log("The Stats script just checked the Class script for info and updated the bars accordingly.");
		Grade = Class.BiologyGrade;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite = Subject1Bars[BarID];
			if (Grade > 0)
			{
				uISprite.color = new Color(1f, 1f, 1f, 1f);
				Grade--;
			}
			else
			{
				uISprite.color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
		if (Class.BiologyGrade < 5)
		{
			Subject1Bars[Class.BiologyGrade + 1].color = ((Class.BiologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.ChemistryGrade;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite2 = Subject2Bars[BarID];
			if (Grade > 0)
			{
				uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0.5f);
			}
		}
		if (Class.ChemistryGrade < 5)
		{
			Subject2Bars[Class.ChemistryGrade + 1].color = ((Class.ChemistryBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.LanguageGrade;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite3 = Subject3Bars[BarID];
			if (Grade > 0)
			{
				uISprite3.color = new Color(uISprite3.color.r, uISprite3.color.g, uISprite3.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite3.color = new Color(uISprite3.color.r, uISprite3.color.g, uISprite3.color.b, 0.5f);
			}
		}
		if (Class.LanguageGrade < 5)
		{
			Subject3Bars[Class.LanguageGrade + 1].color = ((Class.LanguageBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.PhysicalGrade;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite4 = Subject4Bars[BarID];
			if (Grade > 0)
			{
				uISprite4.color = new Color(uISprite4.color.r, uISprite4.color.g, uISprite4.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite4.color = new Color(uISprite4.color.r, uISprite4.color.g, uISprite4.color.b, 0.5f);
			}
		}
		if (Class.PhysicalGrade < 5)
		{
			Subject4Bars[Class.PhysicalGrade + 1].color = ((Class.PhysicalBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.PsychologyGrade;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite5 = Subject5Bars[BarID];
			if (Grade > 0)
			{
				uISprite5.color = new Color(uISprite5.color.r, uISprite5.color.g, uISprite5.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite5.color = new Color(uISprite5.color.r, uISprite5.color.g, uISprite5.color.b, 0.5f);
			}
		}
		if (Class.PsychologyGrade < 5)
		{
			Subject5Bars[Class.PsychologyGrade + 1].color = ((Class.PsychologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.Seduction;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite6 = Subject6Bars[BarID];
			if (Grade > 0)
			{
				uISprite6.color = new Color(uISprite6.color.r, uISprite6.color.g, uISprite6.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite6.color = new Color(uISprite6.color.r, uISprite6.color.g, uISprite6.color.b, 0.5f);
			}
		}
		if (Class.Seduction < 5)
		{
			Subject6Bars[Class.Seduction + 1].color = ((Class.SeductionBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.Numbness;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite7 = Subject7Bars[BarID];
			if (Grade > 0)
			{
				uISprite7.color = new Color(uISprite7.color.r, uISprite7.color.g, uISprite7.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite7.color = new Color(uISprite7.color.r, uISprite7.color.g, uISprite7.color.b, 0.5f);
			}
		}
		if (Class.Numbness < 5)
		{
			Subject7Bars[Class.Numbness + 1].color = ((Class.NumbnessBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Grade = Class.Enlightenment;
		for (BarID = 1; BarID < 6; BarID++)
		{
			UISprite uISprite8 = Subject8Bars[BarID];
			if (Grade > 0)
			{
				uISprite8.color = new Color(uISprite8.color.r, uISprite8.color.g, uISprite8.color.b, 1f);
				Grade--;
			}
			else
			{
				uISprite8.color = new Color(uISprite8.color.r, uISprite8.color.g, uISprite8.color.b, 0.5f);
			}
		}
		if (Class.Enlightenment < 5)
		{
			Subject8Bars[Class.Enlightenment + 1].color = ((Class.EnlightenmentBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		Ranks[1].text = "Rank: " + Class.BiologyGrade;
		Ranks[2].text = "Rank: " + Class.ChemistryGrade;
		Ranks[3].text = "Rank: " + Class.LanguageGrade;
		Ranks[4].text = "Rank: " + Class.PhysicalGrade;
		Ranks[5].text = "Rank: " + Class.PsychologyGrade;
		Ranks[6].text = "Rank: " + Class.Seduction;
		Ranks[7].text = "Rank: " + Class.Numbness;
		Ranks[8].text = "Rank: " + Class.Enlightenment;
		ClubType club = PauseScreen.Yandere.Club;
		if (SceneManager.GetActiveScene().name == "HomeScene")
		{
			club = ClubGlobals.Club;
		}
		if (PauseScreen.Yandere.StudentManager != null && PauseScreen.Yandere.StudentManager.Reputation != null)
		{
			string text = "";
			text = ((PauseScreen.Yandere.StudentManager.Reputation.Reputation > 33.33333f) ? "High" : ((!(PauseScreen.Yandere.StudentManager.Reputation.Reputation < -33.33333f)) ? "Neutral" : "Low"));
			RepLabel.text = "Reputation: " + PauseScreen.Yandere.StudentManager.Reputation.Reputation + " (" + text + ")";
		}
		ClubLabels.TryGetValue(club, out var value);
		ClubLabel.text = "Club: " + value;
	}
}
