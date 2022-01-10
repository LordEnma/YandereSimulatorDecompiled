using System;
using UnityEngine;

// Token: 0x020003E5 RID: 997
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BB9 RID: 7097 RVA: 0x00142070 File Offset: 0x00140270
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BBA RID: 7098 RVA: 0x001420C8 File Offset: 0x001402C8
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

	// Token: 0x06001BBB RID: 7099 RVA: 0x00142270 File Offset: 0x00140470
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

	// Token: 0x04003099 RID: 12441
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x0400309A RID: 12442
	public Renderer MyRenderer;

	// Token: 0x0400309B RID: 12443
	public PromptScript Prompt;

	// Token: 0x0400309C RID: 12444
	public bool LewdPhotos;

	// Token: 0x0400309D RID: 12445
	public bool Stolen;

	// Token: 0x0400309E RID: 12446
	public int StudentID;

	// Token: 0x0400309F RID: 12447
	public Vector3 OriginalPosition;

	// Token: 0x040030A0 RID: 12448
	public Quaternion OriginalRotation;

	// Token: 0x040030A1 RID: 12449
	public Transform OriginalParent;
}
