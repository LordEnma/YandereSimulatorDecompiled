using UnityEngine;

public class SenpaiLoveWindowScript : MonoBehaviour
{
	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Texture EightiesSenpaiLove;

	public Texture ModernSenpaiLove;

	public GameObject RomanticNote;

	public GameObject GiftBox;

	public Transform SenpaiHead;

	public UITexture SenpaiIcon;

	public Texture ModernSenpai;

	public UILabel ThoughtLabel;

	public UILabel NumberLabel;

	public UILabel FoundLabel;

	public GameObject[] Heart;

	public int GiftsToSubtract;

	public int SenpaiLove;

	public float Timer;

	public bool ShowWhenReady;

	public bool Updated;

	public void UpdateSenpaiLove()
	{
		Heart[0].SetActive(value: false);
		Heart[1].SetActive(value: false);
		GiftsToSubtract = CollectibleGlobals.SenpaiGifts;
		SenpaiLove = GameGlobals.SenpaiLove;
		if (RomanticNote.activeInHierarchy)
		{
			SenpaiLove += 1 + (Yandere.Class.LanguageGrade + Yandere.Class.LanguageBonus) + PlayerGlobals.Seduction;
		}
		if (GiftBox.activeInHierarchy)
		{
			SenpaiLove += CollectibleGlobals.SenpaiGifts;
		}
		if (SenpaiLove > 100)
		{
			SenpaiLove = 100;
		}
		if (RomanticNote.activeInHierarchy && !GiftBox.activeInHierarchy)
		{
			FoundLabel.text = "Senpai finds a romantic note on his desk.";
		}
		else if (RomanticNote.activeInHierarchy && GiftBox.activeInHierarchy)
		{
			if (CollectibleGlobals.SenpaiGifts == 1)
			{
				FoundLabel.text = "Senpai finds a romantic note and a gift on his desk.";
			}
			else
			{
				FoundLabel.text = "Senpai finds a romantic note and a box of gifts on his desk.";
			}
		}
		else if (!RomanticNote.activeInHierarchy && GiftBox.activeInHierarchy)
		{
			if (CollectibleGlobals.SenpaiGifts == 1)
			{
				FoundLabel.text = "Senpai finds a gift on his desk.";
			}
			else
			{
				FoundLabel.text = "Senpai finds a box of gifts on his desk.";
			}
		}
		SenpaiHead.localPosition = new Vector3(-500f + (float)SenpaiLove * 1f / 100f * 1000f, 0f, 0f);
		NumberLabel.text = SenpaiLove + "/100";
		if (!GameGlobals.Eighties)
		{
			SenpaiIcon.mainTexture = ModernSenpai;
		}
		if (SenpaiLove < 25)
		{
			ThoughtLabel.text = "He is mildly curious about the identity of his secret admirer.";
		}
		else if (SenpaiLove < 50)
		{
			ThoughtLabel.text = "The thought of his secret admirer puts a smile on his face.";
		}
		else if (SenpaiLove < 75)
		{
			ThoughtLabel.text = "He is starting to think about his secret admirer more often.";
		}
		else if (SenpaiLove < 100)
		{
			ThoughtLabel.text = "He occasionally daydreams about meeting his secret admirer.";
		}
		else
		{
			ThoughtLabel.text = "He can't stop fantasizing about meeting his secret admirer!";
			if (GameGlobals.Eighties)
			{
				SenpaiIcon.mainTexture = EightiesSenpaiLove;
			}
			else
			{
				SenpaiIcon.mainTexture = ModernSenpaiLove;
			}
		}
		ShowWhenReady = true;
		Updated = true;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			GameGlobals.SenpaiLove += 20;
			if (GameGlobals.SenpaiLove > 100)
			{
				GameGlobals.SenpaiLove = 0;
			}
			UpdateSenpaiLove();
		}
		Timer += Time.unscaledDeltaTime;
		if (Timer > 1f)
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Continue";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				base.gameObject.SetActive(value: false);
				ShowWhenReady = false;
				Timer = 0f;
				Time.timeScale = 1f;
			}
		}
	}
}
