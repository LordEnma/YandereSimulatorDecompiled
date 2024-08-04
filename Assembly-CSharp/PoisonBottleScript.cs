using UnityEngine;

public class PoisonBottleScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Theft;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (Theft)
		{
			Prompt.Yandere.TheftTimer = 0.1f;
		}
		if (ID == 1)
		{
			Prompt.Yandere.Inventory.EmeticPoisons++;
		}
		else if (ID == 2)
		{
			Prompt.Yandere.Inventory.LethalPoisons++;
		}
		else if (ID == 3)
		{
			Prompt.Yandere.Inventory.EmeticPoisons++;
			if (Prompt.Yandere.StudentManager.Eighties && Prompt.Yandere.StudentManager.MissionMode)
			{
				Prompt.Yandere.Inventory.EmeticPoisons += 4;
			}
		}
		else if (ID == 4)
		{
			Prompt.Yandere.Inventory.HeadachePoisons++;
		}
		else if (ID == 5)
		{
			Prompt.Yandere.Inventory.SedativePoisons++;
		}
		else if (ID == 6)
		{
			Prompt.Yandere.Inventory.SedativePoisons++;
		}
		Prompt.Yandere.StudentManager.UpdateAllBentos();
		Prompt.Hide();
		Prompt.enabled = false;
		base.gameObject.SetActive(value: false);
	}
}
