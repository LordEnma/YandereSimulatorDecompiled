using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001CA4 RID: 7332 RVA: 0x0014FFEE File Offset: 0x0014E1EE
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001CA5 RID: 7333 RVA: 0x0015001C File Offset: 0x0014E21C
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

	// Token: 0x04003310 RID: 13072
	public PromptScript Prompt;

	// Token: 0x04003311 RID: 13073
	public bool Evidence;

	// Token: 0x04003312 RID: 13074
	public bool Masked;

	// Token: 0x04003313 RID: 13075
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003314 RID: 13076
	public MetalDetectorScript[] Detectors;
}
