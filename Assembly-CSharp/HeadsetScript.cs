using UnityEngine;

public class HeadsetScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			Prompt.Yandere.Inventory.Headset = true;
			Object.Destroy(base.gameObject);
		}
	}
}
