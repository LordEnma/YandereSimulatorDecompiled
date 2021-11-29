using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001803 RID: 6147 RVA: 0x000E2DEC File Offset: 0x000E0FEC
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001804 RID: 6148 RVA: 0x000E2E50 File Offset: 0x000E1050
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Invisible)
			{
				this.Prompt.Yandere.NotificationManager.CustomText = "Can't wear this while invisible!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else if (this.Prompt.Yandere.WearingRaincoat || this.Prompt.Yandere.Gloved)
			{
				this.Prompt.Yandere.NotificationManager.CustomText = "Can't combine clothing!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
			else
			{
				base.transform.parent = this.Prompt.Yandere.transform;
				base.transform.localPosition = new Vector3(0f, 1f, 0.25f);
				if (this.Raincoat)
				{
					this.Prompt.Yandere.WearingRaincoat = true;
				}
				this.Prompt.Yandere.StudentManager.GloveID = this.GloveID;
				this.Prompt.Yandere.Gloves = this;
				this.Prompt.Yandere.WearGloves();
				base.gameObject.SetActive(false);
			}
		}
		this.Prompt.HideButton[0] = (this.Prompt.Yandere.Schoolwear != 1 || this.Prompt.Yandere.ClubAttire);
	}

	// Token: 0x040022A9 RID: 8873
	public PromptScript Prompt;

	// Token: 0x040022AA RID: 8874
	public PickUpScript PickUp;

	// Token: 0x040022AB RID: 8875
	public Collider MyCollider;

	// Token: 0x040022AC RID: 8876
	public Projector Blood;

	// Token: 0x040022AD RID: 8877
	public bool Raincoat;

	// Token: 0x040022AE RID: 8878
	public int GloveID;
}
