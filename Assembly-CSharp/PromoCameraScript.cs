using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromoCameraScript : MonoBehaviour
{
	// Token: 0x06001B31 RID: 6961 RVA: 0x0012F820 File Offset: 0x0012DA20
	private void Start()
	{
		base.transform.eulerAngles = this.StartRotations[this.ID];
		base.transform.position = this.StartPositions[this.ID];
		this.PromoCharacter.gameObject.SetActive(false);
		this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
		this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
		this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
	}

	// Token: 0x06001B32 RID: 6962 RVA: 0x0012F984 File Offset: 0x0012DB84
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

	// Token: 0x06001B33 RID: 6963 RVA: 0x0012FC94 File Offset: 0x0012DE94
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

	// Token: 0x04002E46 RID: 11846
	public PortraitChanScript PromoCharacter;

	// Token: 0x04002E47 RID: 11847
	public Vector3[] StartPositions;

	// Token: 0x04002E48 RID: 11848
	public Vector3[] StartRotations;

	// Token: 0x04002E49 RID: 11849
	public Renderer PromoBlack;

	// Token: 0x04002E4A RID: 11850
	public Renderer Noose;

	// Token: 0x04002E4B RID: 11851
	public Renderer Rope;

	// Token: 0x04002E4C RID: 11852
	public Camera MyCamera;

	// Token: 0x04002E4D RID: 11853
	public Transform Drills;

	// Token: 0x04002E4E RID: 11854
	public float Timer;

	// Token: 0x04002E4F RID: 11855
	public int ID;
}
