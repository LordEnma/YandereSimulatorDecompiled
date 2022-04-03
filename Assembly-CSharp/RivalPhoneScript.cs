using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BE7 RID: 7143 RVA: 0x00146A6C File Offset: 0x00144C6C
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x00146AC4 File Offset: 0x00144CC4
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

	// Token: 0x06001BE9 RID: 7145 RVA: 0x00146C6C File Offset: 0x00144E6C
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

	// Token: 0x04003121 RID: 12577
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003122 RID: 12578
	public Renderer MyRenderer;

	// Token: 0x04003123 RID: 12579
	public PromptScript Prompt;

	// Token: 0x04003124 RID: 12580
	public bool LewdPhotos;

	// Token: 0x04003125 RID: 12581
	public bool Stolen;

	// Token: 0x04003126 RID: 12582
	public int StudentID;

	// Token: 0x04003127 RID: 12583
	public Vector3 OriginalPosition;

	// Token: 0x04003128 RID: 12584
	public Quaternion OriginalRotation;

	// Token: 0x04003129 RID: 12585
	public Transform OriginalParent;
}
