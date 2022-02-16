using System;
using UnityEngine;

// Token: 0x020003BC RID: 956
public class PromoCameraScript : MonoBehaviour
{
	// Token: 0x06001B00 RID: 6912 RVA: 0x0012BE68 File Offset: 0x0012A068
	private void Start()
	{
		base.transform.eulerAngles = this.StartRotations[this.ID];
		base.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.SetActive(false);
		this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
		this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
		this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
	}

	// Token: 0x06001B01 RID: 6913 RVA: 0x0012BFCC File Offset: 0x0012A1CC
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

	// Token: 0x06001B02 RID: 6914 RVA: 0x0012C2DC File Offset: 0x0012A4DC
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

	// Token: 0x04002DAE RID: 11694
	public PortraitChanScript PromoCharacter;

	// Token: 0x04002DAF RID: 11695
	public Vector3[] StartPositions;

	// Token: 0x04002DB0 RID: 11696
	public Vector3[] StartRotations;

	// Token: 0x04002DB1 RID: 11697
	public Renderer PromoBlack;

	// Token: 0x04002DB2 RID: 11698
	public Renderer Noose;

	// Token: 0x04002DB3 RID: 11699
	public Renderer Rope;

	// Token: 0x04002DB4 RID: 11700
	public Camera MyCamera;

	// Token: 0x04002DB5 RID: 11701
	public Transform Drills;

	// Token: 0x04002DB6 RID: 11702
	public float Timer;

	// Token: 0x04002DB7 RID: 11703
	public int ID;
}
