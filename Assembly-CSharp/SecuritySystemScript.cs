using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SecuritySystemScript : MonoBehaviour
{
	// Token: 0x06001C96 RID: 7318 RVA: 0x0014E876 File Offset: 0x0014CA76
	private void Start()
	{
		if (PlayerGlobals.Kills == 0 && !SchoolGlobals.HighSecurity)
		{
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06001C97 RID: 7319 RVA: 0x0014E8A4 File Offset: 0x0014CAA4
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

	// Token: 0x040032E4 RID: 13028
	public PromptScript Prompt;

	// Token: 0x040032E5 RID: 13029
	public bool Evidence;

	// Token: 0x040032E6 RID: 13030
	public bool Masked;

	// Token: 0x040032E7 RID: 13031
	public SecurityCameraScript[] Cameras;

	// Token: 0x040032E8 RID: 13032
	public MetalDetectorScript[] Detectors;
}
