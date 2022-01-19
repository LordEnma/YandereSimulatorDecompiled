using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C60 RID: 7264 RVA: 0x0014AE36 File Offset: 0x00149036
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x0014AE64 File Offset: 0x00149064
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

	// Token: 0x04003250 RID: 12880
	public PromptScript Prompt;

	// Token: 0x04003251 RID: 12881
	public bool Evidence;

	// Token: 0x04003252 RID: 12882
	public bool Masked;

	// Token: 0x04003253 RID: 12883
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003254 RID: 12884
	public MetalDetectorScript[] Detectors;
}
