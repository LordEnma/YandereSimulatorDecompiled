using System;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C8C RID: 7308 RVA: 0x0014E182 File Offset: 0x0014C382
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C8D RID: 7309 RVA: 0x0014E1B0 File Offset: 0x0014C3B0
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

	// Token: 0x040032D6 RID: 13014
	public PromptScript Prompt;

	// Token: 0x040032D7 RID: 13015
	public bool Evidence;

	// Token: 0x040032D8 RID: 13016
	public bool Masked;

	// Token: 0x040032D9 RID: 13017
	public SecurityCameraScript[] Cameras;

	// Token: 0x040032DA RID: 13018
	public MetalDetectorScript[] Detectors;
}
