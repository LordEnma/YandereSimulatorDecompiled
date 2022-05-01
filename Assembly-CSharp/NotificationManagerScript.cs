using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NotificationManagerScript : MonoBehaviour
{
	// Token: 0x06001A37 RID: 6711 RVA: 0x00114D84 File Offset: 0x00112F84
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

	// Token: 0x06001A38 RID: 6712 RVA: 0x00114E8C File Offset: 0x0011308C
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

	// Token: 0x06001A39 RID: 6713 RVA: 0x00115034 File Offset: 0x00113234
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

	// Token: 0x04002ADB RID: 10971
	public YandereScript Yandere;

	// Token: 0x04002ADC RID: 10972
	public Transform NotificationSpawnPoint;

	// Token: 0x04002ADD RID: 10973
	public Transform NotificationParent;

	// Token: 0x04002ADE RID: 10974
	public GameObject Notification;

	// Token: 0x04002ADF RID: 10975
	public int NotificationsSpawned;

	// Token: 0x04002AE0 RID: 10976
	public int Phase = 1;

	// Token: 0x04002AE1 RID: 10977
	public ClockScript Clock;

	// Token: 0x04002AE2 RID: 10978
	public string PersonaName;

	// Token: 0x04002AE3 RID: 10979
	public string PreviousText;

	// Token: 0x04002AE4 RID: 10980
	public string CustomText;

	// Token: 0x04002AE5 RID: 10981
	public string TopicName;

	// Token: 0x04002AE6 RID: 10982
	public string[] ClubNames;

	// Token: 0x04002AE7 RID: 10983
	private NotificationTypeAndStringDictionary NotificationMessages;
}
