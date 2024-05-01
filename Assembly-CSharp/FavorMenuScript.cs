using UnityEngine;

public class FavorMenuScript : MonoBehaviour
{
	public TutorialWindowScript TutorialWindow;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public ServicesScript ServicesMenu;

	public SchemesScript SchemesMenu;

	public DropsScript DropsMenu;

	public PromptBarScript PromptBar;

	public GameObject IdiotArrows;

	public GameObject BountyMenu;

	public GameObject Panel;

	public UILabel SchemesLabel;

	public Transform Highlight;

	public UITexture Portrait;

	public bool Flicker;

	public float Timer;

	public int ID = 1;

	private void Start()
	{
		if (DateGlobals.Week > 1)
		{
			SchemesLabel.alpha = 0.5f;
		}
	}

	private void Update()
	{
		if (Flicker)
		{
			Timer += Time.unscaledDeltaTime;
			if (Timer > 0.1f)
			{
				IdiotArrows.SetActive(!IdiotArrows.activeInHierarchy);
				Timer = 0f;
			}
		}
		if (!BountyMenu.activeInHierarchy)
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
			if (TutorialWindow.Hide || TutorialWindow.Show)
			{
				return;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				if (ID == 1)
				{
					if (SchemesLabel.alpha > 0.5f)
					{
						SchemesMenu.UpdatePantyCount();
						SchemesMenu.UpdateSchemeList();
						SchemesMenu.UpdateSchemeInfo();
						SchemesMenu.gameObject.SetActive(value: true);
						base.gameObject.SetActive(value: false);
					}
				}
				else if (ID == 2)
				{
					ServicesMenu.UpdatePantyCount();
					ServicesMenu.UpdateList();
					ServicesMenu.UpdateDesc();
					ServicesMenu.gameObject.SetActive(value: true);
					base.gameObject.SetActive(value: false);
				}
				else if (ID == 3)
				{
					DropsMenu.UpdatePantyCount();
					DropsMenu.UpdateList();
					DropsMenu.UpdateDesc();
					DropsMenu.gameObject.SetActive(value: true);
					base.gameObject.SetActive(value: false);
				}
				else if (ID == 4)
				{
					PromptBar.ClearButtons();
					PromptBar.Label[1].text = "Back";
					PromptBar.UpdateButtons();
					Panel.SetActive(value: false);
					BountyMenu.SetActive(value: true);
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				TutorialWindow.TitleLabel.text = "Info Points";
				TutorialWindow.TutorialLabel.text = TutorialWindow.PointsString;
				TutorialWindow.TutorialLabel.text = TutorialWindow.TutorialLabel.text.Replace('@', '\n');
				TutorialWindow.TutorialImage.mainTexture = TutorialWindow.InfoTexture;
				TutorialWindow.ForcingTutorial = true;
				TutorialWindow.enabled = true;
				TutorialWindow.SummonWindow();
				PromptBar.Show = false;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Confirm";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[4].text = "Change";
				PromptBar.UpdateButtons();
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.Sideways = false;
				PauseScreen.PressedB = true;
				base.gameObject.SetActive(value: false);
				IdiotArrows.SetActive(value: false);
				Flicker = false;
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.UpdateButtons();
			Panel.SetActive(value: true);
			BountyMenu.SetActive(value: false);
		}
	}

	private void UpdateHighlight()
	{
		if (ID > 4)
		{
			ID = 1;
		}
		else if (ID < 1)
		{
			ID = 4;
		}
		Highlight.transform.localPosition = new Vector3(-500f + 200f * (float)ID, Highlight.transform.localPosition.y, Highlight.transform.localPosition.z);
	}
}
