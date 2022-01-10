using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class GloveScript : MonoBehaviour
{
	// Token: 0x06001810 RID: 6160 RVA: 0x000E3BA4 File Offset: 0x000E1DA4
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x06001811 RID: 6161 RVA: 0x000E3C08 File Offset: 0x000E1E08
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

	// Token: 0x040022D1 RID: 8913
	public PromptScript Prompt;

	// Token: 0x040022D2 RID: 8914
	public PickUpScript PickUp;

	// Token: 0x040022D3 RID: 8915
	public Collider MyCollider;

	// Token: 0x040022D4 RID: 8916
	public Projector Blood;

	// Token: 0x040022D5 RID: 8917
	public bool Raincoat;

	// Token: 0x040022D6 RID: 8918
	public int GloveID;
}
