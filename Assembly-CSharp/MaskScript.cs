using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001993 RID: 6547 RVA: 0x001054E8 File Offset: 0x001036E8
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

	// Token: 0x06001994 RID: 6548 RVA: 0x00105548 File Offset: 0x00103748
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

	// Token: 0x06001995 RID: 6549 RVA: 0x00105690 File Offset: 0x00103890
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

	// Token: 0x04002902 RID: 10498
	public StudentManagerScript StudentManager;

	// Token: 0x04002903 RID: 10499
	public ClubManagerScript ClubManager;

	// Token: 0x04002904 RID: 10500
	public YandereScript Yandere;

	// Token: 0x04002905 RID: 10501
	public PromptScript Prompt;

	// Token: 0x04002906 RID: 10502
	public PickUpScript PickUp;

	// Token: 0x04002907 RID: 10503
	public Projector Blood;

	// Token: 0x04002908 RID: 10504
	public Renderer MyRenderer;

	// Token: 0x04002909 RID: 10505
	public MeshFilter MyFilter;

	// Token: 0x0400290A RID: 10506
	public Texture[] Textures;

	// Token: 0x0400290B RID: 10507
	public Mesh[] Meshes;

	// Token: 0x0400290C RID: 10508
	public int ID;
}
