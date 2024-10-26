using UnityEngine;

public class PhoneMinigameScript : MonoBehaviour
{
	public PickpocketMinigameScript PickpocketMinigame;

	public OsanaThursdayAfterClassEventScript Event;

	public Renderer SmartPhoneScreen;

	public Transform Smartphone;

	public PromptScript Prompt;

	public Texture AlarmOff;

	public bool Tampering;

	public float Timer;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.CameraEffects.UpdateDOF(0.23f);
			Prompt.Yandere.Pickpocketing = true;
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(45f, 180f, 0f);
			Prompt.Yandere.MainCamera.transform.position = new Vector3(0.4f, 12.66666f, -29.2f);
			Prompt.Yandere.RPGCamera.enabled = false;
			SmartPhoneScreen = Event.Rival.SmartPhoneScreen;
			Smartphone = Event.Rival.SmartPhone.transform;
			PickpocketMinigame.StartingAlerts = Prompt.Yandere.Alerts;
			PickpocketMinigame.PickpocketSpot = null;
			PickpocketMinigame.Sabotage = true;
			PickpocketMinigame.Show = true;
			OriginalRotation = Smartphone.eulerAngles;
			OriginalPosition = Smartphone.position;
			Tampering = true;
		}
		if (!Tampering)
		{
			return;
		}
		Prompt.Yandere.MoveTowardsTarget(new Vector3(0f, 12f, -28.66666f));
		if (!PickpocketMinigame.Failure && Event.enabled)
		{
			if (PickpocketMinigame.Progress == 1)
			{
				Smartphone.position = Vector3.Lerp(Smartphone.position, new Vector3(0.4f, Smartphone.position.y, Smartphone.position.z), Time.deltaTime * 10f);
			}
			else if (PickpocketMinigame.Progress == 2)
			{
				Smartphone.eulerAngles = Vector3.Lerp(Smartphone.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 10f);
			}
			else if (PickpocketMinigame.Progress == 3)
			{
				SmartPhoneScreen.material.mainTexture = AlarmOff;
			}
			else if (PickpocketMinigame.Progress == 4)
			{
				Smartphone.eulerAngles = Vector3.Lerp(Smartphone.eulerAngles, new Vector3(OriginalRotation.x, OriginalRotation.y, OriginalRotation.z), Time.deltaTime * 10f);
			}
			else if (!PickpocketMinigame.Show)
			{
				Smartphone.position = Vector3.Lerp(Smartphone.position, new Vector3(OriginalPosition.x, OriginalPosition.y, OriginalPosition.z), Time.deltaTime * 10f);
				Timer += Time.deltaTime;
				if ((double)Timer > 1.0)
				{
					Event.Sabotaged = true;
					End();
				}
			}
		}
		else
		{
			if (!Event.enabled)
			{
				PickpocketMinigame.End();
			}
			Prompt.Yandere.transform.position = new Vector3(0f, 12f, -28.5f);
			Prompt.Yandere.TheftTimer = 1f;
			Event.EndEvent();
			Event.Rival.transform.position = new Vector3(0f, 12f, -29.2f);
			Event.Rival.YandereVisible = true;
			Event.Rival.Distracted = false;
			Event.Rival.Alarm = 200f;
			End();
		}
	}

	private void End()
	{
		Prompt.Yandere.CameraEffects.UpdateDOF(2f);
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.gameObject.SetActive(value: true);
		Prompt.Yandere.Pickpocketing = false;
		Prompt.Yandere.CanMove = true;
		Prompt.Yandere.Caught = false;
		Prompt.Hide();
		Prompt.enabled = false;
		Tampering = false;
		base.gameObject.SetActive(value: false);
	}
}
