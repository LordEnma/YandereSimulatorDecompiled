using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromoCameraScript : MonoBehaviour
{
	// Token: 0x06001B09 RID: 6921 RVA: 0x0012C8A8 File Offset: 0x0012AAA8
	private void Start()
	{
		base.transform.eulerAngles = this.StartRotations[this.ID];
		base.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.SetActive(false);
		this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
		this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
		this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x0012CA0C File Offset: 0x0012AC0C
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

	// Token: 0x06001B0B RID: 6923 RVA: 0x0012CD1C File Offset: 0x0012AF1C
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

	// Token: 0x04002DBE RID: 11710
	public PortraitChanScript PromoCharacter;

	// Token: 0x04002DBF RID: 11711
	public Vector3[] StartPositions;

	// Token: 0x04002DC0 RID: 11712
	public Vector3[] StartRotations;

	// Token: 0x04002DC1 RID: 11713
	public Renderer PromoBlack;

	// Token: 0x04002DC2 RID: 11714
	public Renderer Noose;

	// Token: 0x04002DC3 RID: 11715
	public Renderer Rope;

	// Token: 0x04002DC4 RID: 11716
	public Camera MyCamera;

	// Token: 0x04002DC5 RID: 11717
	public Transform Drills;

	// Token: 0x04002DC6 RID: 11718
	public float Timer;

	// Token: 0x04002DC7 RID: 11719
	public int ID;
}
