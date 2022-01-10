using System;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C5E RID: 7262 RVA: 0x0014972E File Offset: 0x0014792E
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0014975C File Offset: 0x0014795C
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

	// Token: 0x0400324B RID: 12875
	public PromptScript Prompt;

	// Token: 0x0400324C RID: 12876
	public bool Evidence;

	// Token: 0x0400324D RID: 12877
	public bool Masked;

	// Token: 0x0400324E RID: 12878
	public SecurityCameraScript[] Cameras;

	// Token: 0x0400324F RID: 12879
	public MetalDetectorScript[] Detectors;
}
