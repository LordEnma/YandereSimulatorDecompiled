using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001ACE RID: 6862 RVA: 0x00125AF2 File Offset: 0x00123CF2
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001ACF RID: 6863 RVA: 0x00125B20 File Offset: 0x00123D20
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

	// Token: 0x06001AD0 RID: 6864 RVA: 0x00125C18 File Offset: 0x00123E18
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

	// Token: 0x04002D17 RID: 11543
	public GameObject[] StudentObject;

	// Token: 0x04002D18 RID: 11544
	public Renderer Renderer1;

	// Token: 0x04002D19 RID: 11545
	public Renderer Renderer2;

	// Token: 0x04002D1A RID: 11546
	public Renderer Renderer3;

	// Token: 0x04002D1B RID: 11547
	public Texture[] HairSet1;

	// Token: 0x04002D1C RID: 11548
	public Texture[] HairSet2;

	// Token: 0x04002D1D RID: 11549
	public Texture[] HairSet3;

	// Token: 0x04002D1E RID: 11550
	public int Selected;

	// Token: 0x04002D1F RID: 11551
	public int CurrentHair;
}
