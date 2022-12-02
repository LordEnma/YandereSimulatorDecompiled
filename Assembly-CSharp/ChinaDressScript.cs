using UnityEngine;

public class ChinaDressScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.WearChinaDress();
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}
}
