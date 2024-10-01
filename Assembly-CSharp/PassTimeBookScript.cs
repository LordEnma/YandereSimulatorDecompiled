using UnityEngine;

public class PassTimeBookScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public UISprite Darkness;

	public bool IgnoringBlood;

	public bool TimeSkipping;

	public bool MissionMode;

	public bool FadeOut;

	public float CooldownTimer;

	public int Phase;

	private void Start()
	{
		MissionMode = MissionModeGlobals.MissionMode;
		if (MissionMode)
		{
			IgnoringBlood = true;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (CooldownTimer > 0f)
			{
				Yandere.NotificationManager.CustomText = "Try again in a few seconds...";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.Police.Show)
			{
				Yandere.NotificationManager.CustomText = "Not when police are coming!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (!MissionMode && Yandere.StudentManager.Clock.HourTime < 15.5f)
			{
				Yandere.NotificationManager.CustomText = "Only available after 3:30 PM";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.StudentManager.Clock.Weekday == 5 && Yandere.StudentManager.Clock.HourTime > 16.53f && !Yandere.StudentManager.RivalEliminated)
			{
				Yandere.NotificationManager.CustomText = "Can't! You're anxious about Senpai!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.StudentManager.Clock.HourTime > 17.5f)
			{
				Yandere.NotificationManager.CustomText = "Not available after 5:30 PM";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (Yandere.Armed || (!IgnoringBlood && Yandere.Bloodiness > 0f) || Yandere.Sanity < 33.333f || Yandere.Attacking || Yandere.Dragging || Yandere.Carrying || Yandere.PickUp != null || Yandere.Chased || Yandere.Chasers > 0 || (Yandere.StudentManager.Reporter != null && !Yandere.Police.Show) || Yandere.StudentManager.MurderTakingPlace)
			{
				DisplayErrorMessage();
			}
			else
			{
				Yandere.CharacterAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.RPGCamera.enabled = false;
				Darkness.enabled = true;
				Yandere.CanMove = false;
				TimeSkipping = true;
				FadeOut = true;
			}
		}
		if (TimeSkipping)
		{
			if (FadeOut)
			{
				Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime));
				if (!(Darkness.color.a > 0.99999f))
				{
					return;
				}
				if (Phase == 0)
				{
					Yandere.StudentManager.PutStudentsToSleep();
					Yandere.StudentManager.Clock.PresentTime += 30f;
					Yandere.StudentManager.Clock.UpdateClock();
					CooldownTimer = 4f;
					Phase++;
				}
				else if (Phase == 1)
				{
					for (int i = 1; i < 100; i++)
					{
						if (Yandere.StudentManager.Students[i] != null && Yandere.StudentManager.Students[i].Alive && !Yandere.StudentManager.Students[i].Tranquil && !Yandere.StudentManager.Students[i].Sedated)
						{
							Yandere.StudentManager.Students[i].transform.position = Yandere.StudentManager.Students[i].CurrentDestination.position;
						}
					}
					Physics.SyncTransforms();
					Phase++;
				}
				else if (Phase == 2)
				{
					FadeOut = false;
				}
				return;
			}
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.color.a < 0.1f)
			{
				Darkness.alpha = 0f;
				if (PlayerGlobals.PantiesEquipped == 7)
				{
					Yandere.StudentManager.Reputation.Portal.Class.BonusPoints += 2;
					Yandere.NotificationManager.CustomText = "Gained 2 extra Study Points!";
				}
				else
				{
					Yandere.StudentManager.Reputation.Portal.Class.BonusPoints++;
					Yandere.NotificationManager.CustomText = "Gained 1 extra Study Point!";
				}
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Yandere.RPGCamera.enabled = true;
				Darkness.enabled = false;
				Yandere.CanMove = true;
				TimeSkipping = false;
				Phase = 0;
			}
		}
		else
		{
			CooldownTimer = Mathf.MoveTowards(CooldownTimer, 0f, Time.deltaTime);
			if (MissionMode)
			{
				CooldownTimer = 0f;
			}
		}
	}

	public void DisplayErrorMessage()
	{
		if (Yandere.Armed)
		{
			Yandere.NotificationManager.CustomText = "Carrying Weapon";
		}
		else if (Yandere.Bloodiness > 0f)
		{
			Yandere.NotificationManager.CustomText = "Bloody";
		}
		else if (Yandere.Sanity < 33.333f)
		{
			Yandere.NotificationManager.CustomText = "Visibly Insane";
		}
		else if (Yandere.Attacking)
		{
			Yandere.NotificationManager.CustomText = "In Combat";
		}
		else if (Yandere.Dragging || Yandere.Carrying)
		{
			Yandere.NotificationManager.CustomText = "Holding Corpse";
		}
		else if (Yandere.PickUp != null)
		{
			Yandere.NotificationManager.CustomText = "Carrying Item";
		}
		else if (Yandere.Chased || Yandere.Chasers > 0)
		{
			Yandere.NotificationManager.CustomText = "Chased";
		}
		else if ((bool)Yandere.StudentManager.Reporter && !Yandere.Police.Show)
		{
			Yandere.NotificationManager.CustomText = "Murder being reported";
		}
		else if (Yandere.StudentManager.MurderTakingPlace)
		{
			Yandere.NotificationManager.CustomText = "Murder taking place";
		}
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Yandere.NotificationManager.CustomText = "Cannot pass time. Reason:";
		Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}
}
