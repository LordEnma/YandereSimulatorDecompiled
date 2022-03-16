using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C82 RID: 7298 RVA: 0x0014D65E File Offset: 0x0014B85E
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C83 RID: 7299 RVA: 0x0014D68C File Offset: 0x0014B88C
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

	// Token: 0x040032BA RID: 12986
	public PromptScript Prompt;

	// Token: 0x040032BB RID: 12987
	public bool Evidence;

	// Token: 0x040032BC RID: 12988
	public bool Masked;

	// Token: 0x040032BD RID: 12989
	public SecurityCameraScript[] Cameras;

	// Token: 0x040032BE RID: 12990
	public MetalDetectorScript[] Detectors;
}
