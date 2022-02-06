using System;
using UnityEngine;

// Token: 0x020003BB RID: 955
public class PromoCameraScript : MonoBehaviour
{
	// Token: 0x06001AF9 RID: 6905 RVA: 0x0012BB60 File Offset: 0x00129D60
	private void Start()
	{
		base.transform.eulerAngles = this.StartRotations[this.ID];
		base.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.SetActive(false);
		this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
		this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
		this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x0012BCC4 File Offset: 0x00129EC4
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && this.ID < 3)
		{
			this.ID++;
			this.UpdatePosition();
		}
		if (this.ID == 0)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
		}
		else if (this.ID == 1)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
		}
		else if (this.ID == 2)
		{
			base.transform.Translate(Vector3.forward * (Time.deltaTime * 0.01f));
			this.PromoCharacter.gameObject.SetActive(true);
		}
		else if (this.ID == 1 || this.ID == 3)
		{
			base.transform.Translate(Vector3.back * (Time.deltaTime * 0.1f));
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 20f)
		{
			this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, this.Noose.material.color.a + Time.deltaTime * 0.2f);
			this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, this.Rope.material.color.a + Time.deltaTime * 0.2f);
		}
		else if (this.Timer > 15f)
		{
			this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, this.PromoBlack.material.color.a + Time.deltaTime * 0.2f);
		}
		if (this.Timer > 10f)
		{
			this.Drills.LookAt(this.Drills.position - Vector3.right);
			if (this.ID == 2)
			{
				this.ID = 3;
				this.UpdatePosition();
				return;
			}
		}
		else if (this.Timer > 5f)
		{
			this.PromoCharacter.EyeShrink += Time.deltaTime * 0.1f;
			if (this.ID == 1)
			{
				this.ID = 2;
				this.UpdatePosition();
			}
		}
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x0012BFD4 File Offset: 0x0012A1D4
	private void UpdatePosition()
	{
		base.transform.position = this.StartPositions[this.ID];
		base.transform.eulerAngles = this.StartRotations[this.ID];
		if (this.ID == 2)
		{
			this.MyCamera.farClipPlane = 3f;
			this.Timer = 5f;
		}
		if (this.ID == 3)
		{
			this.MyCamera.farClipPlane = 5f;
			this.Timer = 10f;
		}
	}

	// Token: 0x04002DA8 RID: 11688
	public PortraitChanScript PromoCharacter;

	// Token: 0x04002DA9 RID: 11689
	public Vector3[] StartPositions;

	// Token: 0x04002DAA RID: 11690
	public Vector3[] StartRotations;

	// Token: 0x04002DAB RID: 11691
	public Renderer PromoBlack;

	// Token: 0x04002DAC RID: 11692
	public Renderer Noose;

	// Token: 0x04002DAD RID: 11693
	public Renderer Rope;

	// Token: 0x04002DAE RID: 11694
	public Camera MyCamera;

	// Token: 0x04002DAF RID: 11695
	public Transform Drills;

	// Token: 0x04002DB0 RID: 11696
	public float Timer;

	// Token: 0x04002DB1 RID: 11697
	public int ID;
}
