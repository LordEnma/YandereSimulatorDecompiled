using UnityEngine;

public class TitleSponsorScript : MonoBehaviour
{
	public NewTitleScreenScript NewTitleScreen;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public string[] SponsorURLs;

	public string[] Sponsors;

	public UILabel SponsorName;

	public Transform Highlight;

	public bool Show;

	public int Columns;

	public int Rows;

	private int Column;

	private int Row;

	public UISprite BlackSprite;

	public UISprite[] RedSprites;

	public UILabel[] Labels;

	private void Start()
	{
		UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			TurnLoveSick();
		}
	}

	public int GetSponsorIndex()
	{
		return Column + Row * Columns;
	}

	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(SponsorURLs[index]);
	}

	private void Update()
	{
		if (InputManager.TappedUp)
		{
			Row = ((Row > 0) ? (Row - 1) : (Rows - 1));
		}
		if (InputManager.TappedDown)
		{
			Row = ((Row < Rows - 1) ? (Row + 1) : 0);
		}
		if (InputManager.TappedRight)
		{
			Column = ((Column < Columns - 1) ? (Column + 1) : 0);
		}
		if (InputManager.TappedLeft)
		{
			Column = ((Column > 0) ? (Column - 1) : (Columns - 1));
		}
		if (InputManager.TappedUp || InputManager.TappedDown || InputManager.TappedRight || InputManager.TappedLeft)
		{
			UpdateHighlight();
		}
		if (!(NewTitleScreen.Speed > 3f))
		{
			return;
		}
		if (!PromptBar.Show)
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Make Selection";
			PromptBar.Label[1].text = "Go Back";
			PromptBar.Label[4].text = "Change Selection";
			PromptBar.Label[5].text = "Change Selection";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			int sponsorIndex = GetSponsorIndex();
			if (SponsorHasWebsite(sponsorIndex))
			{
				Application.OpenURL(SponsorURLs[sponsorIndex]);
			}
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			NewTitleScreen.Speed = 0f;
			NewTitleScreen.Phase = 2;
			PromptBar.Show = false;
			base.enabled = false;
		}
	}

	private void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-384f + (float)Column * 256f, 128f - (float)Row * 256f, Highlight.localPosition.z);
		SponsorName.text = Sponsors[GetSponsorIndex()];
	}

	private void TurnLoveSick()
	{
		BlackSprite.color = Color.black;
		UISprite[] redSprites = RedSprites;
		foreach (UISprite uISprite in redSprites)
		{
			uISprite.color = new Color(1f, 0f, 0f, uISprite.color.a);
		}
		UILabel[] labels = Labels;
		foreach (UILabel uILabel in labels)
		{
			uILabel.color = new Color(1f, 0f, 0f, uILabel.color.a);
		}
	}
}
