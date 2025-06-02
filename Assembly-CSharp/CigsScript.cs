using UnityEngine;

public class CigsScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(3, 3);
			Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			Prompt.Yandere.Inventory.Cigs = true;
			if (Prompt.Suspicious)
			{
				Prompt.Yandere.TheftTimer = 0.1f;
			}
			Object.Destroy(base.gameObject);
			Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			Prompt.Yandere.StolenObjectID = 1;
			Debug.Log("Yandere-chan just grabbed a box of cigarettes.");
		}
	}
}
