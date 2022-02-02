using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BBC RID: 7100 RVA: 0x00143BBC File Offset: 0x00141DBC
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BBD RID: 7101 RVA: 0x00143C14 File Offset: 0x00141E14
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

	// Token: 0x06001BBE RID: 7102 RVA: 0x00143DBC File Offset: 0x00141FBC
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

	// Token: 0x040030A4 RID: 12452
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x040030A5 RID: 12453
	public Renderer MyRenderer;

	// Token: 0x040030A6 RID: 12454
	public PromptScript Prompt;

	// Token: 0x040030A7 RID: 12455
	public bool LewdPhotos;

	// Token: 0x040030A8 RID: 12456
	public bool Stolen;

	// Token: 0x040030A9 RID: 12457
	public int StudentID;

	// Token: 0x040030AA RID: 12458
	public Vector3 OriginalPosition;

	// Token: 0x040030AB RID: 12459
	public Quaternion OriginalRotation;

	// Token: 0x040030AC RID: 12460
	public Transform OriginalParent;
}
