using UnityEngine;

public class SocialMediaScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public UITexture[] Icons;

	public bool[] BlogKnown;

	public UILabel HeaderLabel;

	public UILabel DescLabel;

	public string[] HeaderText;

	public string[] DescText;

	public int Selected;

	public int Column;

	public int Row;

	public Transform[] SocialMediaParents;

	public GameObject[] SocialMediaPosts;

	public string[] Titles;

	public string[] Dates;

	public string[] Texts;

	private void Start()
	{
		if (PromptBar != null)
		{
			UpdateHighlight();
			PromptBar.ClearButtons();
			PromptBar.Show = false;
			for (int i = 1; i < 11; i++)
			{
				GameObject obj = Object.Instantiate(SocialMediaPosts[1], SocialMediaParents[1].position, Quaternion.identity);
				obj.transform.parent = SocialMediaParents[1];
				obj.transform.localPosition = new Vector3(0f, (i - 1) * -525, 0f);
				obj.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				obj.transform.localScale = new Vector3(1f, 1f, 1f);
				SocialMediaPostScript component = obj.GetComponent<SocialMediaPostScript>();
				component.SocialMedia = this;
				component.ID = i;
			}
		}
	}

	private void Update()
	{
		for (int i = 1; i < Icons.Length; i++)
		{
			if (i != Selected)
			{
				Icons[i].transform.localScale = Vector3.Lerp(Icons[i].transform.localScale, new Vector3(1f, 1f, 1f), Time.unscaledDeltaTime * 10f);
			}
			else
			{
				Icons[i].transform.localScale = Vector3.Lerp(Icons[i].transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.unscaledDeltaTime * 10f);
			}
		}
		if (PauseScreen.InputManager.TappedRight || PauseScreen.InputManager.TappedLeft)
		{
			if (Column == 1)
			{
				Column = 2;
			}
			else
			{
				Column = 1;
			}
			UpdateHighlight();
		}
		else if (PauseScreen.InputManager.TappedUp || PauseScreen.InputManager.TappedDown)
		{
			if (Row == 1)
			{
				Row = 2;
			}
			else
			{
				Row = 1;
			}
			UpdateHighlight();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.PressedB = true;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateHighlight()
	{
		Selected = Column + (Row - 1) * 2;
		PromptBar.ClearButtons();
		if (BlogKnown[Selected])
		{
			PromptBar.Label[0].text = "View";
		}
		else
		{
			PromptBar.Label[0].text = "";
		}
		PromptBar.Label[1].text = "Back";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.Label[5].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		HeaderLabel.text = HeaderText[Selected];
		DescLabel.text = DescText[Selected];
	}
}
