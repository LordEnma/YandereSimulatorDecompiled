using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001813 RID: 6163 RVA: 0x000E4250 File Offset: 0x000E2450
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001814 RID: 6164 RVA: 0x000E42B4 File Offset: 0x000E24B4
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

	// Token: 0x040022DD RID: 8925
	public PromptScript Prompt;

	// Token: 0x040022DE RID: 8926
	public PickUpScript PickUp;

	// Token: 0x040022DF RID: 8927
	public Collider MyCollider;

	// Token: 0x040022E0 RID: 8928
	public Projector Blood;

	// Token: 0x040022E1 RID: 8929
	public bool Raincoat;

	// Token: 0x040022E2 RID: 8930
	public int GloveID;
}
