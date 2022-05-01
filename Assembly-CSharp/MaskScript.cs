using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MaskScript : MonoBehaviour
{
	// Token: 0x060019A7 RID: 6567 RVA: 0x00106428 File Offset: 0x00104628
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

	// Token: 0x060019A8 RID: 6568 RVA: 0x00106488 File Offset: 0x00104688
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

	// Token: 0x060019A9 RID: 6569 RVA: 0x001065D0 File Offset: 0x001047D0
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

	// Token: 0x04002929 RID: 10537
	public StudentManagerScript StudentManager;

	// Token: 0x0400292A RID: 10538
	public ClubManagerScript ClubManager;

	// Token: 0x0400292B RID: 10539
	public YandereScript Yandere;

	// Token: 0x0400292C RID: 10540
	public PromptScript Prompt;

	// Token: 0x0400292D RID: 10541
	public PickUpScript PickUp;

	// Token: 0x0400292E RID: 10542
	public Projector Blood;

	// Token: 0x0400292F RID: 10543
	public Renderer MyRenderer;

	// Token: 0x04002930 RID: 10544
	public MeshFilter MyFilter;

	// Token: 0x04002931 RID: 10545
	public Texture[] Textures;

	// Token: 0x04002932 RID: 10546
	public Mesh[] Meshes;

	// Token: 0x04002933 RID: 10547
	public int ID;
}
