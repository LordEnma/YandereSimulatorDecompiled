using UnityEngine;

public class ClothScript : MonoBehaviour
{
	public SewingMachineScript SewingMachine;

	public PromptScript Prompt;

	public bool PinkSockTask;

	public string[] BikiniLetters;

	public bool BikiniCheck;

	public int BikiniID;

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
			SewingMachine.Check = true;
			Prompt.Yandere.NotificationManager.CustomText = "Grabbed some cloth.";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			Prompt.Yandere.Inventory.PinkCloth = true;
			SewingMachine.enabled = true;
			SewingMachine.Check = true;
			PinkSockTask = false;
		}
		if (BikiniCheck && Input.GetKeyDown(BikiniLetters[BikiniID]))
		{
			BikiniID++;
			if (BikiniID == BikiniLetters.Length)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Bikini Obtained";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.Bikini = true;
				BikiniCheck = false;
			}
		}
	}
}
