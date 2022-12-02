using UnityEngine;

public class TranquilizerScript : MonoBehaviour
{
	public PromptScript Prompt;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.Inventory.SedativePoisons++;
			Prompt.Yandere.StudentManager.UpdateAllBentos();
			Prompt.Yandere.TheftTimer = 0.1f;
			Object.Destroy(base.gameObject);
		}
	}
}
