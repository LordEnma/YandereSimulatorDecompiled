using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class BookbagScript : MonoBehaviour
{
	// Token: 0x06000A58 RID: 2648 RVA: 0x0005C058 File Offset: 0x0005A258
	private void Start()
	{
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		if (GameGlobals.Eighties)
		{
			this.MyRenderer.material.mainTexture = this.EightiesBookBagTexture;
			this.MyMesh.mesh = this.EightiesBookBag;
		}
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0005C0AC File Offset: 0x0005A2AC
	private void Update()
	{
		if (this.Prompt.Yandere.PickUp != null || this.ConcealedPickup != null)
		{
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.ConcealedPickup == null)
				{
					if (this.Prompt.Yandere.PickUp.TrashCan == null && !this.Prompt.Yandere.PickUp.JerryCan)
					{
						this.ConcealedPickup = this.Prompt.Yandere.PickUp;
						this.ConcealedPickup.Drop();
						this.ConcealedPickup.gameObject.SetActive(false);
						if (this.ConcealedPickup.Prompt.Text[3] != "")
						{
							this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.Prompt.Text[3];
						}
						else
						{
							this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.name;
						}
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "That wouldn't fit!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.ConcealedPickup.transform.position = base.transform.position;
					this.ConcealedPickup.gameObject.SetActive(true);
					this.ConcealedPickup.Prompt.Circle[3].fillAmount = -1f;
					this.ConcealedPickup = null;
					this.Prompt.Label[0].text = "     Conceal Item";
				}
			}
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Wear();
		}
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0005C2E8 File Offset: 0x0005A4E8
	public void Drop()
	{
		this.Worn = false;
		this.Prompt.Yandere.Bookbag = null;
		base.transform.parent = null;
		this.Prompt.MyCollider.enabled = true;
		this.MyRigidbody.useGravity = true;
		this.MyRigidbody.isKinematic = false;
		this.Prompt.enabled = true;
		base.enabled = true;
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x0005C358 File Offset: 0x0005A558
	public void Wear()
	{
		this.Worn = true;
		this.Prompt.Yandere.Bookbag = this;
		base.transform.parent = this.Prompt.Yandere.BookBagParent;
		base.transform.localPosition = new Vector3(0f, 0f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Prompt.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		base.enabled = true;
	}

	// Token: 0x04000C01 RID: 3073
	public PickUpScript ConcealedPickup;

	// Token: 0x04000C02 RID: 3074
	public Rigidbody MyRigidbody;

	// Token: 0x04000C03 RID: 3075
	public PromptScript Prompt;

	// Token: 0x04000C04 RID: 3076
	public Texture EightiesBookBagTexture;

	// Token: 0x04000C05 RID: 3077
	public Mesh EightiesBookBag;

	// Token: 0x04000C06 RID: 3078
	public Renderer MyRenderer;

	// Token: 0x04000C07 RID: 3079
	public MeshFilter MyMesh;

	// Token: 0x04000C08 RID: 3080
	public bool Worn;
}
