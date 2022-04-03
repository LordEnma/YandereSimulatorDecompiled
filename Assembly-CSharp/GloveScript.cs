using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GloveScript : MonoBehaviour
{
	// Token: 0x0600182E RID: 6190 RVA: 0x000E5984 File Offset: 0x000E3B84
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E59E8 File Offset: 0x000E3BE8
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

	// Token: 0x04002325 RID: 8997
	public PromptScript Prompt;

	// Token: 0x04002326 RID: 8998
	public PickUpScript PickUp;

	// Token: 0x04002327 RID: 8999
	public Collider MyCollider;

	// Token: 0x04002328 RID: 9000
	public Projector Blood;

	// Token: 0x04002329 RID: 9001
	public bool Raincoat;

	// Token: 0x0400232A RID: 9002
	public int GloveID;
}
