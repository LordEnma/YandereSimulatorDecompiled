using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BBE RID: 7102 RVA: 0x00143E58 File Offset: 0x00142058
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BBF RID: 7103 RVA: 0x00143EB0 File Offset: 0x001420B0
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

	// Token: 0x06001BC0 RID: 7104 RVA: 0x00144058 File Offset: 0x00142258
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

	// Token: 0x040030A8 RID: 12456
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x040030A9 RID: 12457
	public Renderer MyRenderer;

	// Token: 0x040030AA RID: 12458
	public PromptScript Prompt;

	// Token: 0x040030AB RID: 12459
	public bool LewdPhotos;

	// Token: 0x040030AC RID: 12460
	public bool Stolen;

	// Token: 0x040030AD RID: 12461
	public int StudentID;

	// Token: 0x040030AE RID: 12462
	public Vector3 OriginalPosition;

	// Token: 0x040030AF RID: 12463
	public Quaternion OriginalRotation;

	// Token: 0x040030B0 RID: 12464
	public Transform OriginalParent;
}
