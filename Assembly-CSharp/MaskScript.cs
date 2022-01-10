using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MaskScript : MonoBehaviour
{
	// Token: 0x06001978 RID: 6520 RVA: 0x001035CC File Offset: 0x001017CC
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

	// Token: 0x06001979 RID: 6521 RVA: 0x0010362C File Offset: 0x0010182C
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

	// Token: 0x0600197A RID: 6522 RVA: 0x00103774 File Offset: 0x00101974
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

	// Token: 0x040028A8 RID: 10408
	public StudentManagerScript StudentManager;

	// Token: 0x040028A9 RID: 10409
	public ClubManagerScript ClubManager;

	// Token: 0x040028AA RID: 10410
	public YandereScript Yandere;

	// Token: 0x040028AB RID: 10411
	public PromptScript Prompt;

	// Token: 0x040028AC RID: 10412
	public PickUpScript PickUp;

	// Token: 0x040028AD RID: 10413
	public Projector Blood;

	// Token: 0x040028AE RID: 10414
	public Renderer MyRenderer;

	// Token: 0x040028AF RID: 10415
	public MeshFilter MyFilter;

	// Token: 0x040028B0 RID: 10416
	public Texture[] Textures;

	// Token: 0x040028B1 RID: 10417
	public Mesh[] Meshes;

	// Token: 0x040028B2 RID: 10418
	public int ID;
}
