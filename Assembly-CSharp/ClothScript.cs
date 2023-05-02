using UnityEngine;

public class ClothScript : MonoBehaviour
{
	public SewingMachineScript SewingMachine;

	public PromptScript Prompt;

	public bool PinkSockTask;

	public void Start()
	{
		if (!GameGlobals.Eighties)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.Inventory.ItemsRequested[3] > Prompt.Yandere.Inventory.Cloth || PinkSockTask)
		{
			Prompt.enabled = true;
			if (Prompt.Yandere.Inventory.ItemsRequested[3] > Prompt.Yandere.Inventory.Cloth)
			{
				Prompt.HideButton[0] = false;
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
			if (PinkSockTask)
			{
				Prompt.HideButton[1] = false;
			}
			else
			{
				Prompt.HideButton[1] = true;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.Inventory.Cloth++;
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Prompt.Circle[1].fillAmount = 1f;
				Prompt.Yandere.Inventory.PinkCloth = true;
				SewingMachine.enabled = true;
				SewingMachine.Check = true;
				PinkSockTask = false;
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
	}
}
