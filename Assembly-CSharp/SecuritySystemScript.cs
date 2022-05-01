using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C9D RID: 7325 RVA: 0x0014F0B2 File Offset: 0x0014D2B2
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C9E RID: 7326 RVA: 0x0014F0E0 File Offset: 0x0014D2E0
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

	// Token: 0x040032F3 RID: 13043
	public PromptScript Prompt;

	// Token: 0x040032F4 RID: 13044
	public bool Evidence;

	// Token: 0x040032F5 RID: 13045
	public bool Masked;

	// Token: 0x040032F6 RID: 13046
	public SecurityCameraScript[] Cameras;

	// Token: 0x040032F7 RID: 13047
	public MetalDetectorScript[] Detectors;
}
