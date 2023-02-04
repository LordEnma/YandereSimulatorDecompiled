using UnityEngine;

public class SanityPillsScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Alphabet.Cheats++;
			Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			Prompt.Yandere.SanityPills = true;
			Prompt.enabled = false;
			Prompt.Hide();
			base.gameObject.SetActive(value: false);
		}
	}
}
