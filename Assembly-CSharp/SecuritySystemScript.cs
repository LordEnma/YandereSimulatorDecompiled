using System;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C63 RID: 7267 RVA: 0x0014B506 File Offset: 0x00149706
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0014B534 File Offset: 0x00149734
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

	// Token: 0x0400325A RID: 12890
	public PromptScript Prompt;

	// Token: 0x0400325B RID: 12891
	public bool Evidence;

	// Token: 0x0400325C RID: 12892
	public bool Masked;

	// Token: 0x0400325D RID: 12893
	public SecurityCameraScript[] Cameras;

	// Token: 0x0400325E RID: 12894
	public MetalDetectorScript[] Detectors;
}
