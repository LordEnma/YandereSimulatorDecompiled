using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NotificationManagerScript : MonoBehaviour
{
	// Token: 0x06001A0F RID: 6671 RVA: 0x001124C0 File Offset: 0x001106C0
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

	// Token: 0x06001A10 RID: 6672 RVA: 0x001125C8 File Offset: 0x001107C8
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

	// Token: 0x06001A11 RID: 6673 RVA: 0x00112770 File Offset: 0x00110970
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

	// Token: 0x04002A65 RID: 10853
	public YandereScript Yandere;

	// Token: 0x04002A66 RID: 10854
	public Transform NotificationSpawnPoint;

	// Token: 0x04002A67 RID: 10855
	public Transform NotificationParent;

	// Token: 0x04002A68 RID: 10856
	public GameObject Notification;

	// Token: 0x04002A69 RID: 10857
	public int NotificationsSpawned;

	// Token: 0x04002A6A RID: 10858
	public int Phase = 1;

	// Token: 0x04002A6B RID: 10859
	public ClockScript Clock;

	// Token: 0x04002A6C RID: 10860
	public string PersonaName;

	// Token: 0x04002A6D RID: 10861
	public string PreviousText;

	// Token: 0x04002A6E RID: 10862
	public string CustomText;

	// Token: 0x04002A6F RID: 10863
	public string TopicName;

	// Token: 0x04002A70 RID: 10864
	public string[] ClubNames;

	// Token: 0x04002A71 RID: 10865
	private NotificationTypeAndStringDictionary NotificationMessages;
}
