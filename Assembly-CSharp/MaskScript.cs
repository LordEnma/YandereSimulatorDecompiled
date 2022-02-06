using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MaskScript : MonoBehaviour
{
	// Token: 0x0600197B RID: 6523 RVA: 0x00103D34 File Offset: 0x00101F34
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

	// Token: 0x0600197C RID: 6524 RVA: 0x00103D94 File Offset: 0x00101F94
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

	// Token: 0x0600197D RID: 6525 RVA: 0x00103EDC File Offset: 0x001020DC
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

	// Token: 0x040028B5 RID: 10421
	public StudentManagerScript StudentManager;

	// Token: 0x040028B6 RID: 10422
	public ClubManagerScript ClubManager;

	// Token: 0x040028B7 RID: 10423
	public YandereScript Yandere;

	// Token: 0x040028B8 RID: 10424
	public PromptScript Prompt;

	// Token: 0x040028B9 RID: 10425
	public PickUpScript PickUp;

	// Token: 0x040028BA RID: 10426
	public Projector Blood;

	// Token: 0x040028BB RID: 10427
	public Renderer MyRenderer;

	// Token: 0x040028BC RID: 10428
	public MeshFilter MyFilter;

	// Token: 0x040028BD RID: 10429
	public Texture[] Textures;

	// Token: 0x040028BE RID: 10430
	public Mesh[] Meshes;

	// Token: 0x040028BF RID: 10431
	public int ID;
}
