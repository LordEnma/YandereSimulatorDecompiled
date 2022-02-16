using System;
using UnityEngine;

// Token: 0x020003B1 RID: 945
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AD7 RID: 6871 RVA: 0x00126096 File Offset: 0x00124296
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x001260C4 File Offset: 0x001242C4
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			this.StudentObject[0].SetActive(true);
			this.StudentObject[1].SetActive(false);
			this.StudentObject[2].SetActive(false);
			this.Selected = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			this.StudentObject[0].SetActive(false);
			this.StudentObject[1].SetActive(true);
			this.StudentObject[2].SetActive(false);
			this.Selected = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			this.StudentObject[0].SetActive(false);
			this.StudentObject[1].SetActive(false);
			this.StudentObject[2].SetActive(true);
			this.Selected = 3;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.CurrentHair++;
			if (this.CurrentHair > this.HairSet1.Length - 1)
			{
				this.CurrentHair = 0;
			}
			this.UpdateHair();
		}
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x001261BC File Offset: 0x001243BC
	private void UpdateHair()
	{
		Texture mainTexture = this.HairSet2[this.CurrentHair];
		this.Renderer1.materials[0].mainTexture = mainTexture;
		this.Renderer1.materials[3].mainTexture = mainTexture;
		this.Renderer2.materials[2].mainTexture = mainTexture;
		this.Renderer2.materials[3].mainTexture = mainTexture;
		this.Renderer3.materials[0].mainTexture = mainTexture;
		this.Renderer3.materials[1].mainTexture = mainTexture;
	}

	// Token: 0x04002D21 RID: 11553
	public GameObject[] StudentObject;

	// Token: 0x04002D22 RID: 11554
	public Renderer Renderer1;

	// Token: 0x04002D23 RID: 11555
	public Renderer Renderer2;

	// Token: 0x04002D24 RID: 11556
	public Renderer Renderer3;

	// Token: 0x04002D25 RID: 11557
	public Texture[] HairSet1;

	// Token: 0x04002D26 RID: 11558
	public Texture[] HairSet2;

	// Token: 0x04002D27 RID: 11559
	public Texture[] HairSet3;

	// Token: 0x04002D28 RID: 11560
	public int Selected;

	// Token: 0x04002D29 RID: 11561
	public int CurrentHair;
}
