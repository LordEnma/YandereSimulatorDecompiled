using UnityEngine;

public class YandereShowerScript : MonoBehaviour
{
	public SkinnedMeshRenderer Curtain;

	public GameObject CensorSteam;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public Transform BatheSpot;

	public float WarningTimer;

	public float OpenValue;

	public float Timer;

	public bool UpdateCurtain;

	public bool Open;

	public AudioSource MyAudio;

	public AudioClip CurtainClose;

	public AudioClip CurtainOpen;

	private void Start()
	{
	}

	private void Update()
	{
		if (Prompt.DistanceSqr < 1f && Yandere.Bloodiness > 0f && Yandere.Schoolwear > 0 && Yandere.Schoolwear != 2)
		{
			if (WarningTimer <= 0f)
			{
				Yandere.NotificationManager.CustomText = "Take off your clothes at your locker!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				WarningTimer = 5f;
			}
			else
			{
				WarningTimer -= Time.deltaTime;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if ((Yandere.Schoolwear > 0 && Yandere.Schoolwear != 2) || Yandere.Chased || Yandere.Chasers > 0 || Yandere.Bloodiness == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
			}
			else
			{
				AudioSource.PlayClipAtPoint(CurtainOpen, base.transform.position);
				CensorSteam.SetActive(true);
				MyAudio.Play();
				Yandere.EmptyHands();
				Yandere.YandereShower = this;
				Yandere.CanMove = false;
				Yandere.Bathing = true;
				UpdateCurtain = true;
				Open = true;
				Timer = 6f;
			}
		}
		if (!UpdateCurtain)
		{
			return;
		}
		Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
		if (Timer < 1f)
		{
			if (Open)
			{
				AudioSource.PlayClipAtPoint(CurtainClose, base.transform.position);
			}
			Open = false;
			if (Timer == 0f)
			{
				CensorSteam.SetActive(false);
				UpdateCurtain = false;
			}
		}
		if (Open)
		{
			OpenValue = Mathf.Lerp(OpenValue, 0f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
		}
		else
		{
			OpenValue = Mathf.Lerp(OpenValue, 100f, Time.deltaTime * 10f);
			Curtain.SetBlendShapeWeight(1, OpenValue);
		}
	}
}
