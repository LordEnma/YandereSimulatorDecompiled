using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MaskScript : MonoBehaviour
{
	// Token: 0x060019A3 RID: 6563 RVA: 0x00105F28 File Offset: 0x00104128
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

	// Token: 0x060019A4 RID: 6564 RVA: 0x00105F88 File Offset: 0x00104188
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

	// Token: 0x060019A5 RID: 6565 RVA: 0x001060D0 File Offset: 0x001042D0
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

	// Token: 0x04002920 RID: 10528
	public StudentManagerScript StudentManager;

	// Token: 0x04002921 RID: 10529
	public ClubManagerScript ClubManager;

	// Token: 0x04002922 RID: 10530
	public YandereScript Yandere;

	// Token: 0x04002923 RID: 10531
	public PromptScript Prompt;

	// Token: 0x04002924 RID: 10532
	public PickUpScript PickUp;

	// Token: 0x04002925 RID: 10533
	public Projector Blood;

	// Token: 0x04002926 RID: 10534
	public Renderer MyRenderer;

	// Token: 0x04002927 RID: 10535
	public MeshFilter MyFilter;

	// Token: 0x04002928 RID: 10536
	public Texture[] Textures;

	// Token: 0x04002929 RID: 10537
	public Mesh[] Meshes;

	// Token: 0x0400292A RID: 10538
	public int ID;
}
