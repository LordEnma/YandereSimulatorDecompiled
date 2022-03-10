using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AE1 RID: 6881 RVA: 0x00126EAE File Offset: 0x001250AE
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AE2 RID: 6882 RVA: 0x00126EDC File Offset: 0x001250DC
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

	// Token: 0x06001AE3 RID: 6883 RVA: 0x00126FD4 File Offset: 0x001251D4
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

	// Token: 0x04002D47 RID: 11591
	public GameObject[] StudentObject;

	// Token: 0x04002D48 RID: 11592
	public Renderer Renderer1;

	// Token: 0x04002D49 RID: 11593
	public Renderer Renderer2;

	// Token: 0x04002D4A RID: 11594
	public Renderer Renderer3;

	// Token: 0x04002D4B RID: 11595
	public Texture[] HairSet1;

	// Token: 0x04002D4C RID: 11596
	public Texture[] HairSet2;

	// Token: 0x04002D4D RID: 11597
	public Texture[] HairSet3;

	// Token: 0x04002D4E RID: 11598
	public int Selected;

	// Token: 0x04002D4F RID: 11599
	public int CurrentHair;
}
