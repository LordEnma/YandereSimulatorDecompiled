using UnityEngine;

public class CabinetDoorScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Eighties;

	public bool Locked;

	public bool Open;

	public float Timer;

	private void Start()
	{
		Eighties = GameGlobals.Eighties;
	}

	private void Update()
	{
		if (Locked)
		{
			if (Prompt.Circle[0].fillAmount < 1f)
			{
				Prompt.Label[0].text = "     Locked";
				Prompt.Circle[0].fillAmount = 1f;
			}
			if (Prompt.Yandere.Inventory.LockPick)
			{
				Prompt.HideButton[2] = false;
				if (Prompt.Circle[2].fillAmount == 0f)
				{
					Prompt.Circle[2].fillAmount = 1f;
					if (Eighties)
					{
						Prompt.Yandere.Inventory.LockPick = false;
						Prompt.Label[0].text = "     Open";
						Prompt.HideButton[2] = true;
						Locked = false;
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Cannot be lockpicked!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else if (!Prompt.HideButton[2])
			{
				Prompt.HideButton[2] = true;
			}
		}
		else if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.TheftTimer = 0.1f;
			Prompt.Circle[0].fillAmount = 1f;
			Open = !Open;
			UpdateLabel();
			Timer = 0f;
		}
		if (Open)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		if (Timer < 2f)
		{
			Timer += Time.deltaTime;
			if (Open)
			{
				base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			}
			else
			{
				base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			}
		}
	}

	public void UpdateLabel()
	{
		if (Open)
		{
			Prompt.Label[0].text = "     Close";
		}
		else
		{
			Prompt.Label[0].text = "     Open";
		}
	}
}
