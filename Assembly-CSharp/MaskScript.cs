using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001982 RID: 6530 RVA: 0x00103ED8 File Offset: 0x001020D8
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

	// Token: 0x06001983 RID: 6531 RVA: 0x00103F38 File Offset: 0x00102138
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

	// Token: 0x06001984 RID: 6532 RVA: 0x00104080 File Offset: 0x00102280
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

	// Token: 0x040028BB RID: 10427
	public StudentManagerScript StudentManager;

	// Token: 0x040028BC RID: 10428
	public ClubManagerScript ClubManager;

	// Token: 0x040028BD RID: 10429
	public YandereScript Yandere;

	// Token: 0x040028BE RID: 10430
	public PromptScript Prompt;

	// Token: 0x040028BF RID: 10431
	public PickUpScript PickUp;

	// Token: 0x040028C0 RID: 10432
	public Projector Blood;

	// Token: 0x040028C1 RID: 10433
	public Renderer MyRenderer;

	// Token: 0x040028C2 RID: 10434
	public MeshFilter MyFilter;

	// Token: 0x040028C3 RID: 10435
	public Texture[] Textures;

	// Token: 0x040028C4 RID: 10436
	public Mesh[] Meshes;

	// Token: 0x040028C5 RID: 10437
	public int ID;
}
