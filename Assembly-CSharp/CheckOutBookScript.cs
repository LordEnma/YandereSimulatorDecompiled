using UnityEngine;

public class CheckOutBookScript : MonoBehaviour
{
	public PromptScript Prompt;

	public int ID;

	private void Start()
	{
		if (!GameGlobals.Eighties)
		{
			if (ID == 1)
			{
				Prompt.Hide();
				Prompt.enabled = false;
				base.transform.parent.gameObject.SetActive(value: false);
			}
		}
		else if (ID == 0)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (ID == 0)
			{
				Prompt.Yandere.Inventory.Book = true;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "Finished homework assignment!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.Inventory.FinishedHomework = true;
			}
			UpdatePrompt();
		}
	}

	public void UpdatePrompt()
	{
		if ((ID == 0 && Prompt.Yandere.Inventory.Book) || (ID == 1 && Prompt.Yandere.Inventory.FinishedHomework))
		{
			Prompt.enabled = false;
			Prompt.Hide();
		}
		else
		{
			Prompt.enabled = true;
			Prompt.Hide();
		}
	}
}
