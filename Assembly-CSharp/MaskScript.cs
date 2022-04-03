using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001999 RID: 6553 RVA: 0x00105B94 File Offset: 0x00103D94
	private void Start()
	{
		if (GameGlobals.MasksBanned)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			this.MyFilter.mesh = this.Meshes[this.ID];
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
		base.enabled = false;
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x00105BF4 File Offset: 0x00103DF4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.StudentManager.CanAnyoneSeeYandere();
			if (!this.StudentManager.YandereVisible && !this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				Rigidbody component = base.GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.MyCollider.enabled = false;
				base.transform.parent = this.Yandere.Head;
				base.transform.localPosition = new Vector3(0f, 0.033333f, 0.1f);
				base.transform.localEulerAngles = Vector3.zero;
				this.Yandere.Mask = this;
				this.ClubManager.UpdateMasks();
				this.StudentManager.UpdateStudents(0);
				return;
			}
			this.Yandere.NotificationManager.CustomText = "Not now. Too suspicious.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x0600199B RID: 6555 RVA: 0x00105D3C File Offset: 0x00103F3C
	public void Drop()
	{
		this.Prompt.MyCollider.isTrigger = false;
		this.Prompt.MyCollider.enabled = true;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.useGravity = true;
		component.isKinematic = false;
		this.Prompt.enabled = true;
		base.transform.parent = null;
		this.Yandere.Mask = null;
		this.ClubManager.UpdateMasks();
		this.StudentManager.UpdateStudents(0);
	}

	// Token: 0x04002915 RID: 10517
	public StudentManagerScript StudentManager;

	// Token: 0x04002916 RID: 10518
	public ClubManagerScript ClubManager;

	// Token: 0x04002917 RID: 10519
	public YandereScript Yandere;

	// Token: 0x04002918 RID: 10520
	public PromptScript Prompt;

	// Token: 0x04002919 RID: 10521
	public PickUpScript PickUp;

	// Token: 0x0400291A RID: 10522
	public Projector Blood;

	// Token: 0x0400291B RID: 10523
	public Renderer MyRenderer;

	// Token: 0x0400291C RID: 10524
	public MeshFilter MyFilter;

	// Token: 0x0400291D RID: 10525
	public Texture[] Textures;

	// Token: 0x0400291E RID: 10526
	public Mesh[] Meshes;

	// Token: 0x0400291F RID: 10527
	public int ID;
}
