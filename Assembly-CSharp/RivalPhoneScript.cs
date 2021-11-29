using System;
using UnityEngine;

// Token: 0x020003E2 RID: 994
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BA8 RID: 7080 RVA: 0x00141040 File Offset: 0x0013F240
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BA9 RID: 7081 RVA: 0x00141098 File Offset: 0x0013F298
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

	// Token: 0x06001BAA RID: 7082 RVA: 0x00141240 File Offset: 0x0013F440
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

	// Token: 0x04003062 RID: 12386
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003063 RID: 12387
	public Renderer MyRenderer;

	// Token: 0x04003064 RID: 12388
	public PromptScript Prompt;

	// Token: 0x04003065 RID: 12389
	public bool LewdPhotos;

	// Token: 0x04003066 RID: 12390
	public bool Stolen;

	// Token: 0x04003067 RID: 12391
	public int StudentID;

	// Token: 0x04003068 RID: 12392
	public Vector3 OriginalPosition;

	// Token: 0x04003069 RID: 12393
	public Quaternion OriginalRotation;

	// Token: 0x0400306A RID: 12394
	public Transform OriginalParent;
}
