using UnityEngine;

public class IdeasMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public Transform Highlight;

	public UILabel Description;

	public string[] IdeaNames;

	public string[] Ideas;

	public UILabel[] Labels;

	public GameObject List;

	public int ListSize = 21;

	public int Selected = 1;

	public int Offset;

	public int Limit = 27;

	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			if (!CollectibleGlobals.GetAdvicePurchased(i))
			{
				IdeaNames[17 + i] = "?????";
				Ideas[17 + i] = "To unlock this information, you'll need to find someone who has experience getting away with murder...";
			}
		}
		UpdateHighlightPosition();
		Description.enabled = false;
		List.SetActive(value: true);
	}

	private void Update()
	{
		if (List.activeInHierarchy)
		{
			if (InputManager.TappedDown)
			{
				Selected++;
				UpdateHighlightPosition();
			}
			else if (InputManager.TappedUp)
			{
				Selected--;
				UpdateHighlightPosition();
			}
			else if (Input.GetButtonDown("A"))
			{
				PauseScreen.PromptBar.ClearButtons();
				PauseScreen.PromptBar.Label[1].text = "Back";
				PauseScreen.PromptBar.UpdateButtons();
				PauseScreen.PromptBar.Show = true;
				Description.text = Ideas[Selected + Offset];
				Description.text = Description.text.Replace('@', '\n');
				Description.enabled = true;
				List.SetActive(value: false);
			}
			else if (Input.GetButtonDown("B"))
			{
				PauseScreen.PromptBar.ClearButtons();
				PauseScreen.PromptBar.Label[0].text = "Accept";
				PauseScreen.PromptBar.Label[1].text = "Exit";
				PauseScreen.PromptBar.Label[4].text = "Choose";
				PauseScreen.PromptBar.Label[5].text = "Choose";
				PauseScreen.PromptBar.UpdateButtons();
				PauseScreen.MainMenu.SetActive(value: true);
				base.gameObject.SetActive(value: false);
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			PauseScreen.PromptBar.ClearButtons();
			PauseScreen.PromptBar.Label[0].text = "Confirm";
			PauseScreen.PromptBar.Label[1].text = "Back";
			PauseScreen.PromptBar.Label[4].text = "Choose";
			PauseScreen.PromptBar.UpdateButtons();
			PauseScreen.PromptBar.Show = true;
			Description.enabled = false;
			List.SetActive(value: true);
		}
	}

	private void UpdateHighlightPosition()
	{
		if (Selected < 1)
		{
			Selected = 1;
			Offset--;
		}
		else if (Selected > ListSize)
		{
			Selected = ListSize;
			Offset++;
		}
		if (Offset < 0)
		{
			Selected = ListSize;
			Offset = Limit - ListSize;
		}
		else if (Offset > Limit - ListSize)
		{
			Selected = 1;
			Offset = 0;
		}
		for (int i = 1; i < Labels.Length; i++)
		{
			Labels[i].text = IdeaNames[i + Offset];
		}
		Highlight.transform.localPosition = new Vector3(-125f, 550 - Selected * 50, 0f);
	}
}
