using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001811 RID: 6161 RVA: 0x000E4164 File Offset: 0x000E2364
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001812 RID: 6162 RVA: 0x000E41C8 File Offset: 0x000E23C8
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

	// Token: 0x040022DA RID: 8922
	public PromptScript Prompt;

	// Token: 0x040022DB RID: 8923
	public PickUpScript PickUp;

	// Token: 0x040022DC RID: 8924
	public Collider MyCollider;

	// Token: 0x040022DD RID: 8925
	public Projector Blood;

	// Token: 0x040022DE RID: 8926
	public bool Raincoat;

	// Token: 0x040022DF RID: 8927
	public int GloveID;
}
