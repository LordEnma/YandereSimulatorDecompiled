using System;
using UnityEngine;

// Token: 0x020003E8 RID: 1000
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BD0 RID: 7120 RVA: 0x0014510C File Offset: 0x0014330C
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BD1 RID: 7121 RVA: 0x00145164 File Offset: 0x00143364
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

	// Token: 0x06001BD2 RID: 7122 RVA: 0x0014530C File Offset: 0x0014350C
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

	// Token: 0x040030D4 RID: 12500
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x040030D5 RID: 12501
	public Renderer MyRenderer;

	// Token: 0x040030D6 RID: 12502
	public PromptScript Prompt;

	// Token: 0x040030D7 RID: 12503
	public bool LewdPhotos;

	// Token: 0x040030D8 RID: 12504
	public bool Stolen;

	// Token: 0x040030D9 RID: 12505
	public int StudentID;

	// Token: 0x040030DA RID: 12506
	public Vector3 OriginalPosition;

	// Token: 0x040030DB RID: 12507
	public Quaternion OriginalRotation;

	// Token: 0x040030DC RID: 12508
	public Transform OriginalParent;
}
