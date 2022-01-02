using System;
using UnityEngine;

// Token: 0x02000417 RID: 1047
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C57 RID: 7255 RVA: 0x001493BA File Offset: 0x001475BA
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x001493E8 File Offset: 0x001475E8
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

	// Token: 0x04003245 RID: 12869
	public PromptScript Prompt;

	// Token: 0x04003246 RID: 12870
	public bool Evidence;

	// Token: 0x04003247 RID: 12871
	public bool Masked;

	// Token: 0x04003248 RID: 12872
	public SecurityCameraScript[] Cameras;

	// Token: 0x04003249 RID: 12873
	public MetalDetectorScript[] Detectors;
}
