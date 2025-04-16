using UnityEngine;

public class DailyQuestsScript : MonoBehaviour
{
	public GameObject QuestCompleteEffect;

	public GameObject LevelUpEffect;

	public GameObject EXPEffect;

	public YandereScript Yandere;

	public UILabel PlayerLevel;

	public UILabel ToNextLevel;

	public UILabel NextLevel;

	public UISprite[] ProgressBar;

	public UILabel[] ProgressLabel;

	public float Timer;

	public Vector3 lastPosition;

	public float totalDistance;

	private void Start()
	{
		lastPosition = Yandere.transform.position;
		totalDistance = 0f;
		UpdateText();
	}

	private void Update()
	{
		if (Input.GetMouseButton(0) || Input.GetAxis(InputNames.Xbox_RT) > 0.5f)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(23.5f, 0f, 0f), Time.deltaTime * 10f);
			UpdateText();
		}
		else if (base.transform.localPosition.x > -775.5f)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(-776f, 0f, 0f), Time.deltaTime * 10f);
		}
		TrackTravelDistance();
		if (totalDistance > 100f)
		{
			totalDistance -= 100f;
			QuestComplete();
			CheckForLevelUp();
		}
		TrackMurders();
		if (QuestTracker.MurderCount >= 5)
		{
			QuestTracker.ResetMurderCount();
			QuestComplete();
			CheckForLevelUp();
		}
		TrackBloodPools();
		if (QuestTracker.MoppedBloodCount >= 20)
		{
			QuestTracker.ResetBloodCount();
			QuestComplete();
			CheckForLevelUp();
		}
		if (Timer == 0f)
		{
			Debug.Log("Yandere.Shutter.PhotoIcons.activeInHierarchy is " + Yandere.Shutter.PhotoIcons.activeInHierarchy);
			Debug.Log("Yandere.Shutter.PhotoDescLabel.text.Contains(''Panties'') is " + Yandere.Shutter.PhotoDescLabel.text.Contains("Panties"));
			if (Yandere.Laughing && Yandere.LaughIntensity == 1f)
			{
				Yandere.NotificationManager.CustomText = "You giggled! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Shoved)
			{
				Yandere.NotificationManager.CustomText = "You got shoved! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Bathing)
			{
				Yandere.NotificationManager.CustomText = "You took a shower! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.RoofPush)
			{
				Yandere.NotificationManager.CustomText = "You pushed someone! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Poisoning)
			{
				Yandere.NotificationManager.CustomText = "You poisoined food! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Attacking && Yandere.EquippedWeapon.Chainsaw)
			{
				Yandere.NotificationManager.CustomText = "You used a chainsaw! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Dumping)
			{
				Yandere.NotificationManager.CustomText = "You dumped a corpse! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (QuestTracker.PantyShots > 0)
			{
				Yandere.NotificationManager.CustomText = "You took a panty shot! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				QuestTracker.ResetPantyCount();
				GrantEXP();
			}
			else if (Yandere.NearSenpai)
			{
				Yandere.NotificationManager.CustomText = "You walked near Senpai! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
			else if (Yandere.Dismembering)
			{
				Yandere.NotificationManager.CustomText = "You dismembered a corpse! +10 EXP!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				GrantEXP();
			}
		}
		else
		{
			Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
		}
	}

	private void UpdateText()
	{
		int num = PlayerPrefs.GetInt("PlayerLevel");
		int num2 = PlayerPrefs.GetInt("PlayerExp");
		int num3 = (num + 1) * 100;
		PlayerLevel.text = num.ToString() ?? "";
		ToNextLevel.text = num3 - num2 + " XP";
		NextLevel.text = (num + 1).ToString() ?? "";
		if (Mathf.Abs(ProgressBar[0].fillAmount - (float)num2 * 1f / ((float)num3 * 1f)) > 0.01f)
		{
			ProgressBar[0].fillAmount = Mathf.MoveTowards(ProgressBar[0].fillAmount, (float)num2 * 1f / ((float)num3 * 1f), Time.deltaTime);
			ProgressBar[0].fillAmount = (float)num2 * 1f / ((float)num3 * 1f);
		}
	}

	private void CheckForLevelUp()
	{
		int num = PlayerPrefs.GetInt("PlayerLevel");
		int num2 = PlayerPrefs.GetInt("PlayerExp");
		int num3 = (num + 1) * 100;
		if (num3 - num2 <= 0)
		{
			Object.Instantiate(LevelUpEffect, Yandere.transform.position + new Vector3(0f, 1.75f, 0f), Quaternion.identity).transform.parent = Yandere.transform;
			PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
			PlayerPrefs.SetInt("PlayerExp", PlayerPrefs.GetInt("PlayerExp") - num3);
			CheckForLevelUp();
		}
	}

	private void GrantEXP()
	{
		GameObject obj = Object.Instantiate(EXPEffect, Yandere.transform.position, Quaternion.identity);
		PlayerPrefs.SetInt("PlayerExp", PlayerPrefs.GetInt("PlayerExp") + 10);
		obj.transform.parent = Yandere.transform;
		obj.transform.localPosition = new Vector3(0.5f, 1.5f, 0f);
		CheckForLevelUp();
		Timer = 5f;
	}

	private void QuestComplete()
	{
		GameObject obj = Object.Instantiate(QuestCompleteEffect, Yandere.transform.position, Quaternion.identity);
		PlayerPrefs.SetInt("PlayerExp", PlayerPrefs.GetInt("PlayerExp") + 100);
		obj.transform.parent = Yandere.transform;
		obj.transform.localPosition = new Vector3(-0.5f, 1.5f, 0f);
	}

	private void TrackTravelDistance()
	{
		float num = Vector3.Distance(lastPosition, Yandere.transform.position);
		totalDistance += num;
		lastPosition = Yandere.transform.position;
		ProgressBar[1].fillAmount = totalDistance / 100f;
		ProgressLabel[1].text = (int)totalDistance + " / 100";
	}

	private void TrackMurders()
	{
		int murderCount = QuestTracker.MurderCount;
		ProgressBar[2].fillAmount = (float)murderCount * 1f / 5f;
		ProgressLabel[2].text = murderCount + " / 5";
	}

	private void TrackBloodPools()
	{
		int moppedBloodCount = QuestTracker.MoppedBloodCount;
		ProgressBar[3].fillAmount = (float)moppedBloodCount * 1f / 20f;
		ProgressLabel[3].text = moppedBloodCount + " / 20";
	}
}
