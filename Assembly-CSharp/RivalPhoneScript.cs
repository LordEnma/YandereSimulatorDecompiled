using System;
using UnityEngine;

// Token: 0x020003E3 RID: 995
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BB2 RID: 7090 RVA: 0x00141CFC File Offset: 0x0013FEFC
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BB3 RID: 7091 RVA: 0x00141D54 File Offset: 0x0013FF54
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

	// Token: 0x06001BB4 RID: 7092 RVA: 0x00141EFC File Offset: 0x001400FC
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

	// Token: 0x04003093 RID: 12435
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003094 RID: 12436
	public Renderer MyRenderer;

	// Token: 0x04003095 RID: 12437
	public PromptScript Prompt;

	// Token: 0x04003096 RID: 12438
	public bool LewdPhotos;

	// Token: 0x04003097 RID: 12439
	public bool Stolen;

	// Token: 0x04003098 RID: 12440
	public int StudentID;

	// Token: 0x04003099 RID: 12441
	public Vector3 OriginalPosition;

	// Token: 0x0400309A RID: 12442
	public Quaternion OriginalRotation;

	// Token: 0x0400309B RID: 12443
	public Transform OriginalParent;
}
