using UnityEngine;

public class PhoneJammerScript : MonoBehaviour
{
	public GameObject JammingLines;

	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Alphabet.Cheats++;
			Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			Prompt.Yandere.StudentManager.Jammed = true;
			JammingLines.SetActive(value: true);
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
	}
}
