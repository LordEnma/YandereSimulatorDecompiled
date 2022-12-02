using UnityEngine;

public class RoseBushScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.Rose = true;
			base.enabled = false;
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
