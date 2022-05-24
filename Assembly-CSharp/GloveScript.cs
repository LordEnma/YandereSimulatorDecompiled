using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001840 RID: 6208 RVA: 0x000E6690 File Offset: 0x000E4890
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001841 RID: 6209 RVA: 0x000E66F4 File Offset: 0x000E48F4
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

	// Token: 0x0400233E RID: 9022
	public PromptScript Prompt;

	// Token: 0x0400233F RID: 9023
	public PickUpScript PickUp;

	// Token: 0x04002340 RID: 9024
	public Collider MyCollider;

	// Token: 0x04002341 RID: 9025
	public Projector Blood;

	// Token: 0x04002342 RID: 9026
	public bool Raincoat;

	// Token: 0x04002343 RID: 9027
	public int GloveID;
}
