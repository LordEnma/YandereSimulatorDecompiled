using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001CA3 RID: 7331 RVA: 0x0014FD32 File Offset: 0x0014DF32
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001CA4 RID: 7332 RVA: 0x0014FD60 File Offset: 0x0014DF60
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
			this.Prompt.Yandere.NotificationManager.CustomText = "Faculty ID card required!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04003308 RID: 13064
	public PromptScript Prompt;

	// Token: 0x04003309 RID: 13065
	public bool Evidence;

	// Token: 0x0400330A RID: 13066
	public bool Masked;

	// Token: 0x0400330B RID: 13067
	public SecurityCameraScript[] Cameras;

	// Token: 0x0400330C RID: 13068
	public MetalDetectorScript[] Detectors;
}
