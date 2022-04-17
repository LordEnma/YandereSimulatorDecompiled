using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001838 RID: 6200 RVA: 0x000E5CFC File Offset: 0x000E3EFC
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x000E5D60 File Offset: 0x000E3F60
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

	// Token: 0x0400232A RID: 9002
	public PromptScript Prompt;

	// Token: 0x0400232B RID: 9003
	public PickUpScript PickUp;

	// Token: 0x0400232C RID: 9004
	public Collider MyCollider;

	// Token: 0x0400232D RID: 9005
	public Projector Blood;

	// Token: 0x0400232E RID: 9006
	public bool Raincoat;

	// Token: 0x0400232F RID: 9007
	public int GloveID;
}
