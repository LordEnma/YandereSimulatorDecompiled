using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RivalPhoneScript : MonoBehaviour
{
	// Token: 0x06001BDD RID: 7133 RVA: 0x00145FB0 File Offset: 0x001441B0
	private void Start()
	{
		this.OriginalParent = base.transform.parent;
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalRotation = base.transform.localRotation;
		base.gameObject.SetActive(false);
		this.Prompt.Hide();
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x00146008 File Offset: 0x00144208
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

	// Token: 0x06001BDF RID: 7135 RVA: 0x001461B0 File Offset: 0x001443B0
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

	// Token: 0x04003108 RID: 12552
	public DoorGapScript StolenPhoneDropoff;

	// Token: 0x04003109 RID: 12553
	public Renderer MyRenderer;

	// Token: 0x0400310A RID: 12554
	public PromptScript Prompt;

	// Token: 0x0400310B RID: 12555
	public bool LewdPhotos;

	// Token: 0x0400310C RID: 12556
	public bool Stolen;

	// Token: 0x0400310D RID: 12557
	public int StudentID;

	// Token: 0x0400310E RID: 12558
	public Vector3 OriginalPosition;

	// Token: 0x0400310F RID: 12559
	public Quaternion OriginalRotation;

	// Token: 0x04003110 RID: 12560
	public Transform OriginalParent;
}
