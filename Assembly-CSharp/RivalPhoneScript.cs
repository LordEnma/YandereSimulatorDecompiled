using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BFF RID: 7167 RVA: 0x001488D8 File Offset: 0x00146AD8
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001C00 RID: 7168 RVA: 0x00148930 File Offset: 0x00146B30
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

	// Token: 0x06001C01 RID: 7169 RVA: 0x00148AD8 File Offset: 0x00146CD8
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

	// Token: 0x0400315B RID: 12635
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x0400315C RID: 12636
	public Renderer MyRenderer;

	// Token: 0x0400315D RID: 12637
	public PromptScript Prompt;

	// Token: 0x0400315E RID: 12638
	public bool LewdPhotos;

	// Token: 0x0400315F RID: 12639
	public bool Stolen;

	// Token: 0x04003160 RID: 12640
	public int StudentID;

	// Token: 0x04003161 RID: 12641
	public Vector3 OriginalPosition;

	// Token: 0x04003162 RID: 12642
	public Quaternion OriginalRotation;

	// Token: 0x04003163 RID: 12643
	public Transform OriginalParent;
}
