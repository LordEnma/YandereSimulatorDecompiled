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

	public GameObject BountyMenu;

	public GameObject Panel;

	public Transform Highlight;

	public UITexture Portrait;

	public int ID = 1;

	private void Update()
	{
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
			if (Input.GetButtonDown("A"))
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				if (ID == 1)
				{
					SchemesMenu.UpdatePantyCount();
					SchemesMenu.UpdateSchemeList();
					SchemesMenu.UpdateSchemeInfo();
					SchemesMenu.gameObject.SetActive(value: true);
					base.gameObject.SetActive(value: false);
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
			else if (Input.GetButtonDown("X"))
			{
				TutorialWindow.TitleLabel.text = "Info Points";
				TutorialWindow.TutorialLabel.text = TutorialWindow.PointsString;
				TutorialWindow.TutorialLabel.text = TutorialWindow.TutorialLabel.text.Replace('@', '\n');
				TutorialWindow.TutorialImage.mainTexture = TutorialWindow.InfoTexture;
				TutorialWindow.ForcingTutorial = true;
				TutorialWindow.enabled = true;
				TutorialWindow.SummonWindow();
			}
			else if (Input.GetButtonDown("B"))
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
		else if (Input.GetButtonDown("B"))
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
