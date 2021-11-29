using System;
using UnityEngine;

// Token: 0x02000416 RID: 1046
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C4D RID: 7245 RVA: 0x001486D6 File Offset: 0x001468D6
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x00148704 File Offset: 0x00146904
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Inventory.IDCard)
			{
				for (int i = 0; i < this.Cameras.Length; i++)
				{
					this.Cameras[i].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
					this.Cameras[i].gameObject.SetActive(false);
				}
				for (int i = 0; i < this.Detectors.Length; i++)
				{
					this.Detectors[i].MyCollider.enabled = false;
					this.Detectors[i].enabled = false;
				}
				base.GetComponent<AudioSource>().Play();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Evidence = false;
				base.enabled = false;
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "ID card required!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04003213 RID: 12819
	public PromptScript Prompt;

	// Token: 0x04003214 RID: 12820
	public bool Evidence;

	// Token: 0x04003215 RID: 12821
	public bool Masked;

	// Token: 0x04003216 RID: 12822
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003217 RID: 12823
	public MetalDetectorScript[] Detectors;
}
