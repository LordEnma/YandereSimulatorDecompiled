using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class BookbagScript : MonoBehaviour
{
	// Token: 0x06000A58 RID: 2648 RVA: 0x0005BEDC File Offset: 0x0005A0DC
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

	// Token: 0x06000A59 RID: 2649 RVA: 0x0005BF30 File Offset: 0x0005A130
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

	// Token: 0x06000A5A RID: 2650 RVA: 0x0005C158 File Offset: 0x0005A358
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

	// Token: 0x04000BF8 RID: 3064
	public PickUpScript ConcealedPickup;

	// Token: 0x04000BF9 RID: 3065
	public Rigidbody MyRigidbody;

	// Token: 0x04000BFA RID: 3066
	public PromptScript Prompt;

	// Token: 0x04000BFB RID: 3067
	public Texture EightiesBookBagTexture;

	// Token: 0x04000BFC RID: 3068
	public Mesh EightiesBookBag;

	// Token: 0x04000BFD RID: 3069
	public Renderer MyRenderer;

	// Token: 0x04000BFE RID: 3070
	public MeshFilter MyMesh;
}
