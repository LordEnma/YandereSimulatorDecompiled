using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public class GloveScript : MonoBehaviour
{
	// Token: 0x0600180A RID: 6154 RVA: 0x000E35AC File Offset: 0x000E17AC
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x0600180B RID: 6155 RVA: 0x000E3610 File Offset: 0x000E1810
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

	// Token: 0x040022C9 RID: 8905
	public PromptScript Prompt;

	// Token: 0x040022CA RID: 8906
	public PickUpScript PickUp;

	// Token: 0x040022CB RID: 8907
	public Collider MyCollider;

	// Token: 0x040022CC RID: 8908
	public Projector Blood;

	// Token: 0x040022CD RID: 8909
	public bool Raincoat;

	// Token: 0x040022CE RID: 8910
	public int GloveID;
}
