using UnityEngine;

public class TaskPickupScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int TaskObjectID;

	public int ButtonID = 3;

	private void Update()
	{
		if (Prompt.Circle[ButtonID].fillAmount == 0f)
		{
			Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			if (TaskObjectID == 25)
			{
				Prompt.Yandere.Inventory.Bra = true;
			}
		}
	}
}
