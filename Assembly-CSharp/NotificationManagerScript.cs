using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NotificationManagerScript : MonoBehaviour
{
	// Token: 0x06001A29 RID: 6697 RVA: 0x00114414 File Offset: 0x00112614
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

	// Token: 0x06001A2A RID: 6698 RVA: 0x0011451C File Offset: 0x0011271C
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

	// Token: 0x06001A2B RID: 6699 RVA: 0x001146C4 File Offset: 0x001128C4
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

	// Token: 0x04002AC7 RID: 10951
	public YandereScript Yandere;

	// Token: 0x04002AC8 RID: 10952
	public Transform NotificationSpawnPoint;

	// Token: 0x04002AC9 RID: 10953
	public Transform NotificationParent;

	// Token: 0x04002ACA RID: 10954
	public GameObject Notification;

	// Token: 0x04002ACB RID: 10955
	public int NotificationsSpawned;

	// Token: 0x04002ACC RID: 10956
	public int Phase = 1;

	// Token: 0x04002ACD RID: 10957
	public ClockScript Clock;

	// Token: 0x04002ACE RID: 10958
	public string PersonaName;

	// Token: 0x04002ACF RID: 10959
	public string PreviousText;

	// Token: 0x04002AD0 RID: 10960
	public string CustomText;

	// Token: 0x04002AD1 RID: 10961
	public string TopicName;

	// Token: 0x04002AD2 RID: 10962
	public string[] ClubNames;

	// Token: 0x04002AD3 RID: 10963
	private NotificationTypeAndStringDictionary NotificationMessages;
}
