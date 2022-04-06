using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BED RID: 7149 RVA: 0x00146D50 File Offset: 0x00144F50
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x00146DA8 File Offset: 0x00144FA8
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

	// Token: 0x06001BEF RID: 7151 RVA: 0x00146F50 File Offset: 0x00145150
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

	// Token: 0x04003124 RID: 12580
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003125 RID: 12581
	public Renderer MyRenderer;

	// Token: 0x04003126 RID: 12582
	public PromptScript Prompt;

	// Token: 0x04003127 RID: 12583
	public bool LewdPhotos;

	// Token: 0x04003128 RID: 12584
	public bool Stolen;

	// Token: 0x04003129 RID: 12585
	public int StudentID;

	// Token: 0x0400312A RID: 12586
	public Vector3 OriginalPosition;

	// Token: 0x0400312B RID: 12587
	public Quaternion OriginalRotation;

	// Token: 0x0400312C RID: 12588
	public Transform OriginalParent;
}
