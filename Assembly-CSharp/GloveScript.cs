using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001823 RID: 6179 RVA: 0x000E4FD8 File Offset: 0x000E31D8
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001824 RID: 6180 RVA: 0x000E503C File Offset: 0x000E323C
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

	// Token: 0x04002306 RID: 8966
	public PromptScript Prompt;

	// Token: 0x04002307 RID: 8967
	public PickUpScript PickUp;

	// Token: 0x04002308 RID: 8968
	public Collider MyCollider;

	// Token: 0x04002309 RID: 8969
	public Projector Blood;

	// Token: 0x0400230A RID: 8970
	public bool Raincoat;

	// Token: 0x0400230B RID: 8971
	public int GloveID;
}
