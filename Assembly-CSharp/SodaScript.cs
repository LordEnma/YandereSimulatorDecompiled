using UnityEngine;

public class SodaScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.Soda = true;
			Prompt.Yandere.StudentManager.TaskManager.UpdateTaskStatus();
			Object.Destroy(base.gameObject);
		}
	}
}
