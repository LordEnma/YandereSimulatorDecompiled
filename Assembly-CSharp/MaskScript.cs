using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001972 RID: 6514 RVA: 0x00102FAC File Offset: 0x001011AC
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

	// Token: 0x06001973 RID: 6515 RVA: 0x0010300C File Offset: 0x0010120C
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

	// Token: 0x06001974 RID: 6516 RVA: 0x00103154 File Offset: 0x00101354
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

	// Token: 0x040028A0 RID: 10400
	public StudentManagerScript StudentManager;

	// Token: 0x040028A1 RID: 10401
	public ClubManagerScript ClubManager;

	// Token: 0x040028A2 RID: 10402
	public YandereScript Yandere;

	// Token: 0x040028A3 RID: 10403
	public PromptScript Prompt;

	// Token: 0x040028A4 RID: 10404
	public PickUpScript PickUp;

	// Token: 0x040028A5 RID: 10405
	public Projector Blood;

	// Token: 0x040028A6 RID: 10406
	public Renderer MyRenderer;

	// Token: 0x040028A7 RID: 10407
	public MeshFilter MyFilter;

	// Token: 0x040028A8 RID: 10408
	public Texture[] Textures;

	// Token: 0x040028A9 RID: 10409
	public Mesh[] Meshes;

	// Token: 0x040028AA RID: 10410
	public int ID;
}
