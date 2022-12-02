using UnityEngine;

public class RingTheftScript : MonoBehaviour
{
	public PromptScript Prompt;

	public GameObject BasuRing;

	public GameObject[] Rings;

	public bool Eighties;

	public bool Stolen;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			BasuRing.SetActive(false);
			Eighties = true;
		}
		else
		{
			base.transform.localPosition = new Vector3(11.272f, 0.8306667f, -1.3f);
			GameObject[] rings = Rings;
			foreach (GameObject gameObject in rings)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
		}
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
		if (!Prompt.Yandere.Inventory.Ring)
		{
			if (!Prompt.Yandere.StudentManager.YandereVisible)
			{
				if (Eighties)
				{
					Rings[DateGlobals.Week].SetActive(false);
				}
				else
				{
					SchemeGlobals.SetSchemeStage(2, 5);
					Prompt.Yandere.StudentManager.Schemes.UpdateInstructions();
					BasuRing.SetActive(false);
				}
				Prompt.Yandere.Inventory.Ring = true;
				Stolen = true;
				Prompt.Label[0].text = "     Return Stolen Ring";
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		else
		{
			if (Eighties)
			{
				Rings[DateGlobals.Week].SetActive(true);
			}
			else
			{
				BasuRing.SetActive(true);
			}
			Prompt.Yandere.Inventory.Ring = false;
			Stolen = false;
			Prompt.Label[0].text = "     Steal Ring";
		}
	}
}
