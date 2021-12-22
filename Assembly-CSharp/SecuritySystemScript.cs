using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C55 RID: 7253 RVA: 0x00148FB2 File Offset: 0x001471B2
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x00148FE0 File Offset: 0x001471E0
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
			this.Prompt.Yandere.NotificationManager.CustomText = "ID card required!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x0400323E RID: 12862
	public PromptScript Prompt;

	// Token: 0x0400323F RID: 12863
	public bool Evidence;

	// Token: 0x04003240 RID: 12864
	public bool Masked;

	// Token: 0x04003241 RID: 12865
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003242 RID: 12866
	public MetalDetectorScript[] Detectors;
}
