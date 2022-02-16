using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public class GloveScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E43C4 File Offset: 0x000E25C4
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000E4428 File Offset: 0x000E2628
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

	// Token: 0x040022E3 RID: 8931
	public PromptScript Prompt;

	// Token: 0x040022E4 RID: 8932
	public PickUpScript PickUp;

	// Token: 0x040022E5 RID: 8933
	public Collider MyCollider;

	// Token: 0x040022E6 RID: 8934
	public Projector Blood;

	// Token: 0x040022E7 RID: 8935
	public bool Raincoat;

	// Token: 0x040022E8 RID: 8936
	public int GloveID;
}
