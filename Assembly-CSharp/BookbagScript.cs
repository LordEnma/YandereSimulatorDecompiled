using System;
using UnityEngine;

// Token: 0x020000F2 RID: 242
public class BookbagScript : MonoBehaviour
{
	// Token: 0x06000A55 RID: 2645 RVA: 0x0005BD38 File Offset: 0x00059F38
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

	// Token: 0x06000A56 RID: 2646 RVA: 0x0005BD8C File Offset: 0x00059F8C
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
					this.ConcealedPickup = this.Prompt.Yandere.PickUp;
					this.ConcealedPickup.Drop();
					this.ConcealedPickup.gameObject.SetActive(false);
					this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.name;
				}
				else
				{
					this.ConcealedPickup.transform.position = base.transform.position;
					this.ConcealedPickup.gameObject.SetActive(true);
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
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x0005BFB4 File Offset: 0x0005A1B4
	public void Drop()
	{
		this.Prompt.Yandere.Bookbag = null;
		base.transform.parent = null;
		this.Prompt.MyCollider.enabled = true;
		this.MyRigidbody.useGravity = true;
		this.MyRigidbody.isKinematic = false;
		this.Prompt.enabled = true;
		base.enabled = true;
	}

	// Token: 0x04000BF4 RID: 3060
	public PickUpScript ConcealedPickup;

	// Token: 0x04000BF5 RID: 3061
	public Rigidbody MyRigidbody;

	// Token: 0x04000BF6 RID: 3062
	public PromptScript Prompt;

	// Token: 0x04000BF7 RID: 3063
	public Texture EightiesBookBagTexture;

	// Token: 0x04000BF8 RID: 3064
	public Mesh EightiesBookBag;

	// Token: 0x04000BF9 RID: 3065
	public Renderer MyRenderer;

	// Token: 0x04000BFA RID: 3066
	public MeshFilter MyMesh;
}
