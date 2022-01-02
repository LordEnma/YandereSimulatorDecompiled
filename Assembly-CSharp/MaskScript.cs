using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001974 RID: 6516 RVA: 0x0010326C File Offset: 0x0010146C
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

	// Token: 0x06001975 RID: 6517 RVA: 0x001032CC File Offset: 0x001014CC
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

	// Token: 0x06001976 RID: 6518 RVA: 0x00103414 File Offset: 0x00101614
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

	// Token: 0x040028A4 RID: 10404
	public StudentManagerScript StudentManager;

	// Token: 0x040028A5 RID: 10405
	public ClubManagerScript ClubManager;

	// Token: 0x040028A6 RID: 10406
	public YandereScript Yandere;

	// Token: 0x040028A7 RID: 10407
	public PromptScript Prompt;

	// Token: 0x040028A8 RID: 10408
	public PickUpScript PickUp;

	// Token: 0x040028A9 RID: 10409
	public Projector Blood;

	// Token: 0x040028AA RID: 10410
	public Renderer MyRenderer;

	// Token: 0x040028AB RID: 10411
	public MeshFilter MyFilter;

	// Token: 0x040028AC RID: 10412
	public Texture[] Textures;

	// Token: 0x040028AD RID: 10413
	public Mesh[] Meshes;

	// Token: 0x040028AE RID: 10414
	public int ID;
}
