using System;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class NotificationManagerScript : MonoBehaviour
{
	// Token: 0x06001A05 RID: 6661 RVA: 0x00111A1C File Offset: 0x0010FC1C
	private void Awake()
	{
		this.NotificationMessages = new NotificationTypeAndStringDictionary
		{
			{
				NotificationType.Bloody,
				"Visibly Bloody"
			},
			{
				NotificationType.Body,
				"Near Body"
			},
			{
				NotificationType.Insane,
				"Visibly Insane"
			},
			{
				NotificationType.Armed,
				"Visibly Armed"
			},
			{
				NotificationType.Lewd,
				"Visibly Lewd"
			},
			{
				NotificationType.Intrude,
				"Intruding"
			},
			{
				NotificationType.Late,
				"Late For Class"
			},
			{
				NotificationType.Info,
				"Learned New Info"
			},
			{
				NotificationType.Topic,
				"Learned New Topic: "
			},
			{
				NotificationType.Opinion,
				"Learned how a student feels about: "
			},
			{
				NotificationType.Complete,
				"Mission Complete"
			},
			{
				NotificationType.Exfiltrate,
				"Leave School"
			},
			{
				NotificationType.Evidence,
				"Evidence Recorded"
			},
			{
				NotificationType.ClassSoon,
				"Class Begins Soon"
			},
			{
				NotificationType.ClassNow,
				"Class Begins Now"
			},
			{
				NotificationType.Eavesdropping,
				"Eavesdropping"
			},
			{
				NotificationType.Clothing,
				"Cannot Attack; No Spare Clothing"
			},
			{
				NotificationType.Persona,
				"Persona"
			},
			{
				NotificationType.Custom,
				this.CustomText
			}
		};
	}

	// Token: 0x06001A06 RID: 6662 RVA: 0x00111B24 File Offset: 0x0010FD24
	private void Update()
	{
		if (this.NotificationParent.localPosition.y > 0.001f + -0.049f * (float)this.NotificationsSpawned)
		{
			this.NotificationParent.localPosition = new Vector3(this.NotificationParent.localPosition.x, Mathf.Lerp(this.NotificationParent.localPosition.y, -0.049f * (float)this.NotificationsSpawned, Time.deltaTime * 10f), this.NotificationParent.localPosition.z);
		}
		if (this.Phase == 1)
		{
			if (this.Clock.HourTime > 8.4f)
			{
				if (!this.Yandere.InClass)
				{
					this.Yandere.StudentManager.TutorialWindow.ShowClassMessage = true;
					this.DisplayNotification(NotificationType.ClassSoon);
				}
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Clock.HourTime > 8.5f)
			{
				if (!this.Yandere.InClass)
				{
					this.DisplayNotification(NotificationType.ClassNow);
				}
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Clock.HourTime > 13.4f)
			{
				if (!this.Yandere.InClass)
				{
					this.DisplayNotification(NotificationType.ClassSoon);
				}
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 4 && this.Clock.HourTime > 13.5f)
		{
			if (!this.Yandere.InClass)
			{
				this.DisplayNotification(NotificationType.ClassNow);
			}
			this.Phase++;
		}
	}

	// Token: 0x06001A07 RID: 6663 RVA: 0x00111CCC File Offset: 0x0010FECC
	public void DisplayNotification(NotificationType Type)
	{
		if (!this.Yandere.Egg)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Notification);
			NotificationScript component = gameObject.GetComponent<NotificationScript>();
			gameObject.transform.parent = this.NotificationParent;
			gameObject.transform.localPosition = new Vector3(0f, 0.60275f + 0.049f * (float)this.NotificationsSpawned, 0f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			component.NotificationManager = this;
			string text;
			this.NotificationMessages.TryGetValue(Type, out text);
			if (Type != NotificationType.Persona && Type != NotificationType.Custom)
			{
				string str = "";
				if (Type == NotificationType.Topic || Type == NotificationType.Opinion)
				{
					str = this.TopicName;
				}
				component.Label.text = text + str;
			}
			else if (Type == NotificationType.Custom)
			{
				component.Label.text = this.CustomText;
			}
			else
			{
				component.Label.text = this.PersonaName + " " + text;
			}
			this.NotificationsSpawned++;
			component.ID = this.NotificationsSpawned;
			this.PreviousText = this.CustomText;
		}
	}

	// Token: 0x04002A52 RID: 10834
	public YandereScript Yandere;

	// Token: 0x04002A53 RID: 10835
	public Transform NotificationSpawnPoint;

	// Token: 0x04002A54 RID: 10836
	public Transform NotificationParent;

	// Token: 0x04002A55 RID: 10837
	public GameObject Notification;

	// Token: 0x04002A56 RID: 10838
	public int NotificationsSpawned;

	// Token: 0x04002A57 RID: 10839
	public int Phase = 1;

	// Token: 0x04002A58 RID: 10840
	public ClockScript Clock;

	// Token: 0x04002A59 RID: 10841
	public string PersonaName;

	// Token: 0x04002A5A RID: 10842
	public string PreviousText;

	// Token: 0x04002A5B RID: 10843
	public string CustomText;

	// Token: 0x04002A5C RID: 10844
	public string TopicName;

	// Token: 0x04002A5D RID: 10845
	public string[] ClubNames;

	// Token: 0x04002A5E RID: 10846
	private NotificationTypeAndStringDictionary NotificationMessages;
}
