using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C61 RID: 7265 RVA: 0x0014B26A File Offset: 0x0014946A
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x0014B298 File Offset: 0x00149498
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

	// Token: 0x04003256 RID: 12886
	public PromptScript Prompt;

	// Token: 0x04003257 RID: 12887
	public bool Evidence;

	// Token: 0x04003258 RID: 12888
	public bool Masked;

	// Token: 0x04003259 RID: 12889
	public SecurityCameraScript[] Cameras;

	// Token: 0x0400325A RID: 12890
	public MetalDetectorScript[] Detectors;
}
