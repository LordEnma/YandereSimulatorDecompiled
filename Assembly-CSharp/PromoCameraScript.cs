using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromoCameraScript : MonoBehaviour
{
	// Token: 0x06001B2B RID: 6955 RVA: 0x0012EC5C File Offset: 0x0012CE5C
	private void Start()
	{
		base.transform.eulerAngles = this.StartRotations[this.ID];
		base.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.SetActive(false);
		this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
		this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
		this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x0012EDC0 File Offset: 0x0012CFC0
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

	// Token: 0x06001B2D RID: 6957 RVA: 0x0012F0D0 File Offset: 0x0012D2D0
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

	// Token: 0x04002E31 RID: 11825
	public PortraitChanScript PromoCharacter;

	// Token: 0x04002E32 RID: 11826
	public Vector3[] StartPositions;

	// Token: 0x04002E33 RID: 11827
	public Vector3[] StartRotations;

	// Token: 0x04002E34 RID: 11828
	public Renderer PromoBlack;

	// Token: 0x04002E35 RID: 11829
	public Renderer Noose;

	// Token: 0x04002E36 RID: 11830
	public Renderer Rope;

	// Token: 0x04002E37 RID: 11831
	public Camera MyCamera;

	// Token: 0x04002E38 RID: 11832
	public Transform Drills;

	// Token: 0x04002E39 RID: 11833
	public float Timer;

	// Token: 0x04002E3A RID: 11834
	public int ID;
}
