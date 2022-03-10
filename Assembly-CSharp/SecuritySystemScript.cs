using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C75 RID: 7285 RVA: 0x0014C7BA File Offset: 0x0014A9BA
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x0014C7E8 File Offset: 0x0014A9E8
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

	// Token: 0x04003286 RID: 12934
	public PromptScript Prompt;

	// Token: 0x04003287 RID: 12935
	public bool Evidence;

	// Token: 0x04003288 RID: 12936
	public bool Masked;

	// Token: 0x04003289 RID: 12937
	public SecurityCameraScript[] Cameras;

	// Token: 0x0400328A RID: 12938
	public MetalDetectorScript[] Detectors;
}
