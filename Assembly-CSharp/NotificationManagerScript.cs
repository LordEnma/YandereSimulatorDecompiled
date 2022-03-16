using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NotificationManagerScript : MonoBehaviour
{
	// Token: 0x06001A23 RID: 6691 RVA: 0x00113DBC File Offset: 0x00111FBC
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

	// Token: 0x06001A24 RID: 6692 RVA: 0x00113EC4 File Offset: 0x001120C4
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

	// Token: 0x06001A25 RID: 6693 RVA: 0x0011406C File Offset: 0x0011226C
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

	// Token: 0x04002AB4 RID: 10932
	public YandereScript Yandere;

	// Token: 0x04002AB5 RID: 10933
	public Transform NotificationSpawnPoint;

	// Token: 0x04002AB6 RID: 10934
	public Transform NotificationParent;

	// Token: 0x04002AB7 RID: 10935
	public GameObject Notification;

	// Token: 0x04002AB8 RID: 10936
	public int NotificationsSpawned;

	// Token: 0x04002AB9 RID: 10937
	public int Phase = 1;

	// Token: 0x04002ABA RID: 10938
	public ClockScript Clock;

	// Token: 0x04002ABB RID: 10939
	public string PersonaName;

	// Token: 0x04002ABC RID: 10940
	public string PreviousText;

	// Token: 0x04002ABD RID: 10941
	public string CustomText;

	// Token: 0x04002ABE RID: 10942
	public string TopicName;

	// Token: 0x04002ABF RID: 10943
	public string[] ClubNames;

	// Token: 0x04002AC0 RID: 10944
	private NotificationTypeAndStringDictionary NotificationMessages;
}
