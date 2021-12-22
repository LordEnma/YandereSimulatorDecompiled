using System;
using UnityEngine;

// Token: 0x020003E3 RID: 995
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BB0 RID: 7088 RVA: 0x00141900 File Offset: 0x0013FB00
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BB1 RID: 7089 RVA: 0x00141958 File Offset: 0x0013FB58
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.StudentManager.YandereVisible)
			{
				if (this.StudentID == this.Prompt.Yandere.StudentManager.RivalID && SchemeGlobals.GetSchemeStage(1) == 4)
				{
					SchemeGlobals.SetSchemeStage(1, 5);
					this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
				this.Prompt.Yandere.RivalPhoneTexture = this.MyRenderer.material.mainTexture;
				this.Prompt.Yandere.Inventory.RivalPhone = true;
				this.Prompt.Yandere.Inventory.RivalPhoneID = this.StudentID;
				this.Prompt.enabled = false;
				base.enabled = false;
				this.StolenPhoneDropoff.Prompt.enabled = true;
				this.StolenPhoneDropoff.Phase = 1;
				this.StolenPhoneDropoff.Timer = 0f;
				this.StolenPhoneDropoff.Prompt.Label[0].text = "     Provide Stolen Phone";
				base.gameObject.SetActive(false);
				this.Stolen = true;
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x06001BB2 RID: 7090 RVA: 0x00141B00 File Offset: 0x0013FD00
	public void ReturnToOrigin()
	{
		base.transform.parent = this.OriginalParent;
		base.transform.localPosition = this.OriginalPosition;
		base.transform.localRotation = this.OriginalRotation;
		base.gameObject.SetActive(false);
		this.Prompt.enabled = true;
		this.LewdPhotos = false;
		this.Stolen = false;
		base.enabled = true;
	}

	// Token: 0x0400308C RID: 12428
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x0400308D RID: 12429
	public Renderer MyRenderer;

	// Token: 0x0400308E RID: 12430
	public PromptScript Prompt;

	// Token: 0x0400308F RID: 12431
	public bool LewdPhotos;

	// Token: 0x04003090 RID: 12432
	public bool Stolen;

	// Token: 0x04003091 RID: 12433
	public int StudentID;

	// Token: 0x04003092 RID: 12434
	public Vector3 OriginalPosition;

	// Token: 0x04003093 RID: 12435
	public Quaternion OriginalRotation;

	// Token: 0x04003094 RID: 12436
	public Transform OriginalParent;
}
