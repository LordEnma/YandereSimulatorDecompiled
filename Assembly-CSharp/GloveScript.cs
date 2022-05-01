using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GloveScript : MonoBehaviour
{
	// Token: 0x0600183C RID: 6204 RVA: 0x000E61CC File Offset: 0x000E43CC
	private void Start()
	{
		Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(12f, 0f, 28f);
		}
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x000E6230 File Offset: 0x000E4430
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

	// Token: 0x04002333 RID: 9011
	public PromptScript Prompt;

	// Token: 0x04002334 RID: 9012
	public PickUpScript PickUp;

	// Token: 0x04002335 RID: 9013
	public Collider MyCollider;

	// Token: 0x04002336 RID: 9014
	public Projector Blood;

	// Token: 0x04002337 RID: 9015
	public bool Raincoat;

	// Token: 0x04002338 RID: 9016
	public int GloveID;
}
