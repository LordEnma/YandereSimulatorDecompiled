using UnityEngine;

public class DoorGapScript : MonoBehaviour
{
	public RummageSpotScript RummageSpot;

	public SchemesScript Schemes;

	public PromptScript Prompt;

	public Transform[] Papers;

	public bool[] PhoneHacked;

	public bool StolenPhoneDropoff;

	public float Timer;

	public int Phase = 1;

	private void Start()
	{
		Papers[1].gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (!StolenPhoneDropoff)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				if (Phase == 1)
				{
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.Inventory.AnswerSheet = false;
					Papers[1].gameObject.SetActive(value: true);
					SchemeGlobals.SetSchemeStage(5, 6);
					Schemes.UpdateInstructions();
					GetComponent<AudioSource>().Play();
				}
				else
				{
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.Inventory.AnswerSheet = true;
					Prompt.Yandere.Inventory.DuplicateSheet = true;
					Papers[2].gameObject.SetActive(value: false);
					RummageSpot.Prompt.Label[0].text = "     Return Answer Sheet";
					RummageSpot.Prompt.enabled = true;
					SchemeGlobals.SetSchemeStage(5, 7);
					Schemes.UpdateInstructions();
				}
				Phase++;
			}
			if (Phase == 2)
			{
				Timer += Time.deltaTime;
				if (Timer > 4f)
				{
					Prompt.Label[0].text = "     Pick Up Sheets";
					Prompt.enabled = true;
					Phase = 2;
				}
				else if (Timer > 3f)
				{
					Transform transform = Papers[2];
					transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, -0.166f, Time.deltaTime * 10f));
				}
				else if (Timer > 1f)
				{
					Transform transform2 = Papers[1];
					transform2.localPosition = new Vector3(transform2.localPosition.x, transform2.localPosition.y, Mathf.Lerp(transform2.localPosition.z, 0.166f, Time.deltaTime * 10f));
				}
			}
			return;
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (Phase == 1)
			{
				if (StudentGlobals.GetStudentPhoneStolen(Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID))
				{
					Prompt.Yandere.NotificationManager.CustomText = "Info-chan doesn't need this phone";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.Inventory.RivalPhone = false;
					Prompt.Yandere.RivalPhone = false;
					PhoneHacked[Prompt.Yandere.StudentManager.CommunalLocker.RivalPhone.StudentID] = true;
					Prompt.Yandere.Inventory.PantyShots += 20;
					Prompt.Yandere.NotificationManager.CustomText = "+20 Info Points! You have " + Prompt.Yandere.Inventory.PantyShots + " in total";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					Papers[1].gameObject.SetActive(value: true);
					GetComponent<AudioSource>().Play();
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				Prompt.Yandere.Inventory.RivalPhone = true;
				Papers[1].gameObject.SetActive(value: false);
				Prompt.Hide();
				Prompt.enabled = false;
				Phase++;
			}
		}
		if (Phase == 2)
		{
			Timer += Time.deltaTime;
			if (Timer > 4f)
			{
				Prompt.Label[0].text = "     Pick Up Phone";
				Prompt.enabled = true;
			}
			else if (Timer > 3f)
			{
				Papers[1].localPosition = new Vector3(Papers[1].localPosition.x, Papers[1].localPosition.y, Mathf.Lerp(Papers[1].localPosition.z, -0.166f, Time.deltaTime * 10f));
			}
			else if (Timer > 1f)
			{
				Papers[1].localPosition = new Vector3(Papers[1].localPosition.x, Papers[1].localPosition.y, Mathf.Lerp(Papers[1].localPosition.z, 0.166f, Time.deltaTime * 10f));
			}
		}
	}

	public void SetPhonesHacked()
	{
		for (int i = 1; i < 101; i++)
		{
			if (PhoneHacked[i])
			{
				StudentGlobals.SetStudentPhoneStolen(i, value: true);
			}
		}
	}
}
