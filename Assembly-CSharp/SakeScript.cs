using UnityEngine;

public class SakeScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.Sake = true;
			UpdatePrompt();
		}
	}

	public void UpdatePrompt()
	{
		if (Prompt.Yandere.Inventory.Sake)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
		else
		{
			Prompt.enabled = true;
			Prompt.Hide();
		}
	}
}
