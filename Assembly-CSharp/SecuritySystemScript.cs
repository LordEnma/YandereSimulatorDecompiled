using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C92 RID: 7314 RVA: 0x0014E466 File Offset: 0x0014C666
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x0014E494 File Offset: 0x0014C694
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

	// Token: 0x040032D9 RID: 13017
	public PromptScript Prompt;

	// Token: 0x040032DA RID: 13018
	public bool Evidence;

	// Token: 0x040032DB RID: 13019
	public bool Masked;

	// Token: 0x040032DC RID: 13020
	public SecurityCameraScript[] Cameras;

	// Token: 0x040032DD RID: 13021
	public MetalDetectorScript[] Detectors;
}
