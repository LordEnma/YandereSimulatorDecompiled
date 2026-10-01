using UnityEngine;

public class SchemesSubMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public SchemesScript RaibaruSchemes;

	public SchemesScript AdviceSchemes;

	public SchemesScript GenericSchemes;

	public PromptBarScript PromptBar;

	public SchemesScript SchemesMenu;

	public UITexture RivalPortrait;

	public GameObject FavorMenu;

	public GameObject Raibaru;

	public Transform Highlight;

	public Transform Parent;

	public UILabel RivalLabel;

	public int Minimum = 1;

	public int Week = 1;

	public int ID = 3;

	public SchemesScript[] RivalSchemes;

	public Texture[] RivalPortraits;

	public string[] RivalNames;

	private void Start()
	{
		Week = DateGlobals.Week;
		RivalPortrait.mainTexture = RivalPortraits[Week];
		RivalLabel.text = RivalNames[Week] + " Schemes";
		if (Week == 2)
		{
			Parent.localPosition = new Vector3(-115f, -25f, 0f);
			Raibaru.SetActive(value: false);
			Minimum = 2;
		}
	}

	private void Update()
	{
		if (InputManager.TappedRight)
		{
			ID++;
			UpdateHighlight();
		}
		else if (InputManager.TappedLeft)
		{
			ID--;
			UpdateHighlight();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			SchemesScript schemesScript = null;
			if (ID == 1)
			{
				schemesScript = RaibaruSchemes;
			}
			else if (ID == 2)
			{
				schemesScript = AdviceSchemes;
			}
			else if (ID == 3)
			{
				Debug.Log("Now entering the Generic menu.");
				schemesScript = GenericSchemes;
			}
			else if (ID == 4)
			{
				schemesScript = RivalSchemes[Week];
			}
			schemesScript.CheckForSpecialCase();
			SchemesMenu.SchemeIcons = schemesScript.SchemeIcons;
			SchemesMenu.SchemeCosts = schemesScript.SchemeCosts;
			SchemesMenu.SchemeDeadlines = schemesScript.SchemeDeadlines;
			SchemesMenu.SchemeSkills = schemesScript.SchemeSkills;
			SchemesMenu.SchemeDescs = schemesScript.SchemeDescs;
			SchemesMenu.SchemeNames = schemesScript.SchemeNames;
			SchemesMenu.SchemeSteps = schemesScript.SchemeSteps;
			SchemesMenu.SchemeTypes = schemesScript.SchemeTypes;
			SchemesMenu.SchemeCategory = schemesScript.SchemeCategory;
			SchemesMenu.Limit = schemesScript.Limit;
			SchemesMenu.SchemeUnlocked = schemesScript.SchemeUnlocked;
			SchemesMenu.HeaderLabel.text = schemesScript.Title;
			SchemesMenu.ListPosition = 0;
			SchemesMenu.ID = 1;
			Debug.Log("Now telling the SchemesMenu GameObject to activate.");
			SchemesMenu.gameObject.SetActive(value: true);
			SchemesMenu.ConfirmWhatSchemesAreUnlocked();
			Debug.Log("Now telling the SchemesMenu script to update various text.");
			SchemesMenu.UpdatePantyCount();
			SchemesMenu.UpdateSchemeList();
			SchemesMenu.UpdateSchemeInfo();
			base.gameObject.SetActive(value: false);
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Confirm";
			PromptBar.Label[1].text = "Back";
			PromptBar.Label[4].text = "Change";
			PromptBar.UpdateButtons();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			FavorMenu.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
	}

	private void UpdateHighlight()
	{
		if (ID > 4)
		{
			ID = Minimum;
		}
		else if (ID < Minimum)
		{
			ID = 4;
		}
		Highlight.transform.localPosition = new Vector3(-575f + 230f * (float)ID, Highlight.transform.localPosition.y, Highlight.transform.localPosition.z);
	}
}
