using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class MaskScript : MonoBehaviour
{
	// Token: 0x0600196B RID: 6507 RVA: 0x00102750 File Offset: 0x00100950
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

	// Token: 0x0600196C RID: 6508 RVA: 0x001027B0 File Offset: 0x001009B0
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

	// Token: 0x0600196D RID: 6509 RVA: 0x001028F8 File Offset: 0x00100AF8
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

	// Token: 0x0400287B RID: 10363
	public StudentManagerScript StudentManager;

	// Token: 0x0400287C RID: 10364
	public ClubManagerScript ClubManager;

	// Token: 0x0400287D RID: 10365
	public YandereScript Yandere;

	// Token: 0x0400287E RID: 10366
	public PromptScript Prompt;

	// Token: 0x0400287F RID: 10367
	public PickUpScript PickUp;

	// Token: 0x04002880 RID: 10368
	public Projector Blood;

	// Token: 0x04002881 RID: 10369
	public Renderer MyRenderer;

	// Token: 0x04002882 RID: 10370
	public MeshFilter MyFilter;

	// Token: 0x04002883 RID: 10371
	public Texture[] Textures;

	// Token: 0x04002884 RID: 10372
	public Mesh[] Meshes;

	// Token: 0x04002885 RID: 10373
	public int ID;
}
