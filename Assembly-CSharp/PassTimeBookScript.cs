using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class PassTimeBookScript : MonoBehaviour
{
	// Token: 0x06001A67 RID: 6759 RVA: 0x00118B68 File Offset: 0x00116D68
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Yandere.StudentManager.Clock.HourTime < 15.5f)
			{
				this.Yandere.NotificationManager.CustomText = "Only available after 3:30 PM";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (this.Yandere.StudentManager.Clock.HourTime > 17.5f)
			{
				this.Yandere.NotificationManager.CustomText = "Not available after 5:30 PM";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (this.Yandere.Armed || this.Yandere.Bloodiness > 0f || this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Dragging || this.Yandere.Carrying || this.Yandere.PickUp != null || this.Yandere.Chased || this.Yandere.Chasers > 0 || (this.Yandere.StudentManager.Reporter != null && !this.Yandere.Police.Show) || this.Yandere.StudentManager.MurderTakingPlace)
			{
				this.DisplayErrorMessage();
			}
			else
			{
				this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.RPGCamera.enabled = false;
				this.Darkness.enabled = true;
				this.Yandere.CanMove = false;
				this.TimeSkipping = true;
				this.FadeOut = true;
			}
		}
		if (this.TimeSkipping)
		{
			if (this.FadeOut)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a > 0.99999f)
				{
					this.Yandere.StudentManager.Clock.PresentTime += 30f;
					this.Yandere.StudentManager.Clock.UpdateClock();
					this.FadeOut = false;
					return;
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					if (PlayerGlobals.PantiesEquipped == 7)
					{
						this.Yandere.StudentManager.Reputation.Portal.Class.BonusPoints += 2;
						this.Yandere.NotificationManager.CustomText = "Gained 2 extra Study Points!";
					}
					else
					{
						this.Yandere.StudentManager.Reputation.Portal.Class.BonusPoints++;
						this.Yandere.NotificationManager.CustomText = "Gained 1 extra Study Point!";
					}
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					this.Yandere.RPGCamera.enabled = true;
					this.Darkness.enabled = false;
					this.Yandere.CanMove = true;
					this.TimeSkipping = false;
				}
			}
		}
	}

	// Token: 0x06001A68 RID: 6760 RVA: 0x00118F6C File Offset: 0x0011716C
	public void DisplayErrorMessage()
	{
		if (this.Yandere.Armed)
		{
			this.Yandere.NotificationManager.CustomText = "Carrying Weapon";
		}
		else if (this.Yandere.Bloodiness > 0f)
		{
			this.Yandere.NotificationManager.CustomText = "Bloody";
		}
		else if (this.Yandere.Sanity < 33.333f)
		{
			this.Yandere.NotificationManager.CustomText = "Visibly Insane";
		}
		else if (this.Yandere.Attacking)
		{
			this.Yandere.NotificationManager.CustomText = "In Combat";
		}
		else if (this.Yandere.Dragging || this.Yandere.Carrying)
		{
			this.Yandere.NotificationManager.CustomText = "Holding Corpse";
		}
		else if (this.Yandere.PickUp != null)
		{
			this.Yandere.NotificationManager.CustomText = "Carrying Item";
		}
		else if (this.Yandere.Chased || this.Yandere.Chasers > 0)
		{
			this.Yandere.NotificationManager.CustomText = "Chased";
		}
		else if (this.Yandere.StudentManager.Reporter && !this.Yandere.Police.Show)
		{
			this.Yandere.NotificationManager.CustomText = "Murder being reported";
		}
		else if (this.Yandere.StudentManager.MurderTakingPlace)
		{
			this.Yandere.NotificationManager.CustomText = "Murder taking place";
		}
		this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		this.Yandere.NotificationManager.CustomText = "Cannot pass time. Reason:";
		this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
	}

	// Token: 0x04002B63 RID: 11107
	public YandereScript Yandere;

	// Token: 0x04002B64 RID: 11108
	public PromptScript Prompt;

	// Token: 0x04002B65 RID: 11109
	public UISprite Darkness;

	// Token: 0x04002B66 RID: 11110
	public bool TimeSkipping;

	// Token: 0x04002B67 RID: 11111
	public bool FadeOut;
}
