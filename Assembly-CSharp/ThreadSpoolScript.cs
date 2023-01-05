using UnityEngine;

public class ThreadSpoolScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.String = true;
			base.gameObject.SetActive(false);
		}
	}
}
