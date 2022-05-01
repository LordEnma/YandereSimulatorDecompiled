using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BF8 RID: 7160 RVA: 0x0014799C File Offset: 0x00145B9C
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x001479F4 File Offset: 0x00145BF4
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

	// Token: 0x06001BFA RID: 7162 RVA: 0x00147B9C File Offset: 0x00145D9C
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

	// Token: 0x0400313E RID: 12606
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x0400313F RID: 12607
	public Renderer MyRenderer;

	// Token: 0x04003140 RID: 12608
	public PromptScript Prompt;

	// Token: 0x04003141 RID: 12609
	public bool LewdPhotos;

	// Token: 0x04003142 RID: 12610
	public bool Stolen;

	// Token: 0x04003143 RID: 12611
	public int StudentID;

	// Token: 0x04003144 RID: 12612
	public Vector3 OriginalPosition;

	// Token: 0x04003145 RID: 12613
	public Quaternion OriginalRotation;

	// Token: 0x04003146 RID: 12614
	public Transform OriginalParent;
}
