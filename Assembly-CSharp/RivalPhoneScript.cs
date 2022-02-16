using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BC5 RID: 7109 RVA: 0x00144158 File Offset: 0x00142358
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x001441B0 File Offset: 0x001423B0
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

	// Token: 0x06001BC7 RID: 7111 RVA: 0x00144358 File Offset: 0x00142558
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

	// Token: 0x040030AE RID: 12462
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x040030AF RID: 12463
	public Renderer MyRenderer;

	// Token: 0x040030B0 RID: 12464
	public PromptScript Prompt;

	// Token: 0x040030B1 RID: 12465
	public bool LewdPhotos;

	// Token: 0x040030B2 RID: 12466
	public bool Stolen;

	// Token: 0x040030B3 RID: 12467
	public int StudentID;

	// Token: 0x040030B4 RID: 12468
	public Vector3 OriginalPosition;

	// Token: 0x040030B5 RID: 12469
	public Quaternion OriginalRotation;

	// Token: 0x040030B6 RID: 12470
	public Transform OriginalParent;
}
