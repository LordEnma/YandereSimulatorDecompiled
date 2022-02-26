using System;
using UnityEngine;

// Token: 0x020003E8 RID: 1000
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BCE RID: 7118 RVA: 0x00144BD0 File Offset: 0x00142DD0
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BCF RID: 7119 RVA: 0x00144C28 File Offset: 0x00142E28
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

	// Token: 0x06001BD0 RID: 7120 RVA: 0x00144DD0 File Offset: 0x00142FD0
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

	// Token: 0x040030BE RID: 12478
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x040030BF RID: 12479
	public Renderer MyRenderer;

	// Token: 0x040030C0 RID: 12480
	public PromptScript Prompt;

	// Token: 0x040030C1 RID: 12481
	public bool LewdPhotos;

	// Token: 0x040030C2 RID: 12482
	public bool Stolen;

	// Token: 0x040030C3 RID: 12483
	public int StudentID;

	// Token: 0x040030C4 RID: 12484
	public Vector3 OriginalPosition;

	// Token: 0x040030C5 RID: 12485
	public Quaternion OriginalRotation;

	// Token: 0x040030C6 RID: 12486
	public Transform OriginalParent;
}
