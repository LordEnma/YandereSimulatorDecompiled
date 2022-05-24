using System;
using UnityEngine;

// Token: 0x020003B7 RID: 951
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001B09 RID: 6921 RVA: 0x00129C02 File Offset: 0x00127E02
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x00129C30 File Offset: 0x00127E30
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

	// Token: 0x06001B0B RID: 6923 RVA: 0x00129D28 File Offset: 0x00127F28
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

	// Token: 0x04002DC0 RID: 11712
	public GameObject[] StudentObject;

	// Token: 0x04002DC1 RID: 11713
	public Renderer Renderer1;

	// Token: 0x04002DC2 RID: 11714
	public Renderer Renderer2;

	// Token: 0x04002DC3 RID: 11715
	public Renderer Renderer3;

	// Token: 0x04002DC4 RID: 11716
	public Texture[] HairSet1;

	// Token: 0x04002DC5 RID: 11717
	public Texture[] HairSet2;

	// Token: 0x04002DC6 RID: 11718
	public Texture[] HairSet3;

	// Token: 0x04002DC7 RID: 11719
	public int Selected;

	// Token: 0x04002DC8 RID: 11720
	public int CurrentHair;
}
