using UnityEngine;

public class PartTimeJobWindowScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public HomeWindowScript HomeWindow;

	public HomeExitScript HomeExit;

	public string[] Descriptions;

	public Transform Highlight;

	public UILabel PayoutLabel;

	public UILabel DescLabel;

	public int Limit = 12;

	public int ID = 1;

	public bool Initialized;

	public float Multiplier;

	private void Initialize()
	{
		DescLabel.text = Descriptions[ID];
		CalculatePayout();
	}

	private void Update()
	{
		if (!Initialized)
		{
			Initialize();
			Initialized = true;
		}
		if (!(HomeWindow.Sprite.color.a > 0.9f))
		{
			return;
		}
		if (InputManager.TappedDown)
		{
			ID++;
			if (ID > Limit)
			{
				ID = 1;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 100f - (float)ID * 75f, Highlight.localPosition.z);
			DescLabel.text = Descriptions[ID];
			CalculatePayout();
		}
		if (InputManager.TappedUp)
		{
			ID--;
			if (ID < 1)
			{
				ID = Limit;
			}
			Highlight.localPosition = new Vector3(Highlight.localPosition.x, 100f - (float)ID * 75f, Highlight.localPosition.z);
			DescLabel.text = Descriptions[ID];
			CalculatePayout();
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			Debug.Log("Go back, damn it.");
			HomeExit.HomeWindow.Show = true;
			HomeWindow.Show = false;
		}
		if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			PlayerGlobals.Money += 100f + 20f * Multiplier;
			if (DateGlobals.PassDays == 0)
			{
				DateGlobals.PassDays++;
			}
			HomeExit.HomeDarkness.Sprite.color = new Color(0f, 0f, 0f, 0f);
			HomeExit.HomeDarkness.FadeOut = true;
			HomeWindow.Show = false;
			base.enabled = false;
		}
	}

	private void CalculatePayout()
	{
		string text = "";
		if (ID == 1)
		{
			text = "Biology";
			Multiplier = ClassGlobals.BiologyGrade;
		}
		else if (ID == 2)
		{
			text = "Chemistry";
			Multiplier = ClassGlobals.ChemistryGrade;
		}
		else if (ID == 3)
		{
			text = "Language";
			Multiplier = ClassGlobals.LanguageGrade;
		}
		else if (ID == 4)
		{
			text = "Physical";
			Multiplier = ClassGlobals.PhysicalGrade;
		}
		else if (ID == 5)
		{
			text = "Psychology";
			Multiplier = ClassGlobals.PsychologyGrade;
		}
		else if (ID == 6)
		{
			text = "Seduction";
			Multiplier = PlayerGlobals.Seduction;
		}
		else if (ID == 7)
		{
			text = "Numbness";
			Multiplier = PlayerGlobals.Numbness;
		}
		PayoutLabel.text = text + " Rank: " + Multiplier + "\n\nPayout: $" + (100f + 20f * Multiplier) + ".00";
	}
}
