using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MaskScript : MonoBehaviour
{
	// Token: 0x0600198B RID: 6539 RVA: 0x00104B70 File Offset: 0x00102D70
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

	// Token: 0x0600198C RID: 6540 RVA: 0x00104BD0 File Offset: 0x00102DD0
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

	// Token: 0x0600198D RID: 6541 RVA: 0x00104D18 File Offset: 0x00102F18
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

	// Token: 0x040028E0 RID: 10464
	public StudentManagerScript StudentManager;

	// Token: 0x040028E1 RID: 10465
	public ClubManagerScript ClubManager;

	// Token: 0x040028E2 RID: 10466
	public YandereScript Yandere;

	// Token: 0x040028E3 RID: 10467
	public PromptScript Prompt;

	// Token: 0x040028E4 RID: 10468
	public PickUpScript PickUp;

	// Token: 0x040028E5 RID: 10469
	public Projector Blood;

	// Token: 0x040028E6 RID: 10470
	public Renderer MyRenderer;

	// Token: 0x040028E7 RID: 10471
	public MeshFilter MyFilter;

	// Token: 0x040028E8 RID: 10472
	public Texture[] Textures;

	// Token: 0x040028E9 RID: 10473
	public Mesh[] Meshes;

	// Token: 0x040028EA RID: 10474
	public int ID;
}
