using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C73 RID: 7283 RVA: 0x0014C27E File Offset: 0x0014A47E
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C74 RID: 7284 RVA: 0x0014C2AC File Offset: 0x0014A4AC
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

	// Token: 0x04003270 RID: 12912
	public PromptScript Prompt;

	// Token: 0x04003271 RID: 12913
	public bool Evidence;

	// Token: 0x04003272 RID: 12914
	public bool Masked;

	// Token: 0x04003273 RID: 12915
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003274 RID: 12916
	public MetalDetectorScript[] Detectors;
}
