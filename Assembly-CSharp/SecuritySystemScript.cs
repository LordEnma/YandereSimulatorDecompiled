using System;
using UnityEngine;

// Token: 0x0200041B RID: 1051
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C6A RID: 7274 RVA: 0x0014B806 File Offset: 0x00149A06
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x0014B834 File Offset: 0x00149A34
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

	// Token: 0x04003260 RID: 12896
	public PromptScript Prompt;

	// Token: 0x04003261 RID: 12897
	public bool Evidence;

	// Token: 0x04003262 RID: 12898
	public bool Masked;

	// Token: 0x04003263 RID: 12899
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003264 RID: 12900
	public MetalDetectorScript[] Detectors;
}
