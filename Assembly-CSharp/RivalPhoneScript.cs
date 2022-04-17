using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BF1 RID: 7153 RVA: 0x00147160 File Offset: 0x00145360
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x001471B8 File Offset: 0x001453B8
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

	// Token: 0x06001BF3 RID: 7155 RVA: 0x00147360 File Offset: 0x00145560
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

	// Token: 0x0400312F RID: 12591
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003130 RID: 12592
	public Renderer MyRenderer;

	// Token: 0x04003131 RID: 12593
	public PromptScript Prompt;

	// Token: 0x04003132 RID: 12594
	public bool LewdPhotos;

	// Token: 0x04003133 RID: 12595
	public bool Stolen;

	// Token: 0x04003134 RID: 12596
	public int StudentID;

	// Token: 0x04003135 RID: 12597
	public Vector3 OriginalPosition;

	// Token: 0x04003136 RID: 12598
	public Quaternion OriginalRotation;

	// Token: 0x04003137 RID: 12599
	public Transform OriginalParent;
}
