using UnityEngine;

public class SmokeBombBoxScript : MonoBehaviour
{
	public AlphabetScript Alphabet;

	public UITexture BombTexture;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public bool Cheated;

	public bool Amnesia;

	public bool Stink;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (!Cheated)
			{
				Alphabet.Cheats++;
				Alphabet.UpdateDifficultyLabel();
				Cheated = true;
			}
			if (!Amnesia)
			{
				Alphabet.RemainingBombs = 5;
				Alphabet.BombLabel.text = 5.ToString() ?? "";
			}
			else
			{
				Alphabet.RemainingBombs = 1;
				Alphabet.BombLabel.text = 1.ToString() ?? "";
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (Stink)
			{
				BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
				Prompt.Yandere.Inventory.AmnesiaBomb = false;
				Prompt.Yandere.Inventory.SmokeBomb = false;
				Prompt.Yandere.Inventory.StinkBomb = true;
			}
			else if (Amnesia)
			{
				BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
				Prompt.Yandere.Inventory.AmnesiaBomb = true;
				Prompt.Yandere.Inventory.SmokeBomb = false;
				Prompt.Yandere.Inventory.StinkBomb = false;
			}
			else
			{
				BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				Prompt.Yandere.Inventory.AmnesiaBomb = false;
				Prompt.Yandere.Inventory.StinkBomb = false;
				Prompt.Yandere.Inventory.SmokeBomb = true;
			}
			MyAudio.Play();
		}
	}
}
