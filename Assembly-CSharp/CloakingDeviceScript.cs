using UnityEngine;

public class CloakingDeviceScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Alphabet.Cheats++;
			Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			Prompt.Yandere.CanCloak = true;
			Prompt.enabled = false;
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
	}
}
