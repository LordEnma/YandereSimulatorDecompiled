using UnityEngine;

public class SchoolNewspaperScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public UILabel NewspaperLabel;

	public GameObject[] NewspaperPages;

	public GameObject ClubPosters;

	public GameObject Newspaper;

	public string[] Article;

	public int GameplayDay;

	public bool Show;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			ClubPosters.SetActive(value: false);
			if (ClubGlobals.GetClubClosed(ClubType.Newspaper))
			{
				NewspaperPages[1].SetActive(value: false);
				NewspaperPages[2].SetActive(value: false);
				NewspaperPages[3].SetActive(value: false);
				Prompt.enabled = false;
				Prompt.Hide();
			}
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (Prompt.Yandere.YandereVision)
			{
				Prompt.Yandere.ResetYandereEffects();
				Prompt.Yandere.YandereVision = false;
			}
			Prompt.Yandere.transform.position = new Vector3(-3.5f, 0f, -18.66666f);
			Prompt.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			Prompt.Yandere.RPGCamera.ZeroEverything();
			Prompt.Yandere.FixCamera();
			Prompt.Circle[0].fillAmount = 1f;
			PromptBar.ClearButtons();
			PromptBar.Label[1].text = "Back";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			Newspaper.SetActive(value: true);
			GameplayDay = (int)((DateGlobals.Week - 1) * 5 + DateGlobals.Weekday);
			NewspaperLabel.text = Article[GameplayDay];
			NewspaperLabel.text = NewspaperLabel.text.Replace('@', '\n');
			if (NewspaperLabel.text == "")
			{
				NewspaperLabel.text = "Whoops! Sorry, this article is coming in a future update.";
			}
			Time.timeScale = 0.0001f;
			Show = true;
		}
		if (Show && Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Show = false;
			Newspaper.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}
}
