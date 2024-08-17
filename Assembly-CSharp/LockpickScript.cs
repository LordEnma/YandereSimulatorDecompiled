using UnityEngine;

public class LockpickScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.LockPicks++;
			Object.Destroy(base.gameObject);
		}
	}
}
