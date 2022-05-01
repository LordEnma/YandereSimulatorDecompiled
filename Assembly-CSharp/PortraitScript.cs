using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001B02 RID: 6914 RVA: 0x00128E26 File Offset: 0x00127026
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001B03 RID: 6915 RVA: 0x00128E54 File Offset: 0x00127054
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

	// Token: 0x06001B04 RID: 6916 RVA: 0x00128F4C File Offset: 0x0012714C
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

	// Token: 0x04002DA3 RID: 11683
	public GameObject[] StudentObject;

	// Token: 0x04002DA4 RID: 11684
	public Renderer Renderer1;

	// Token: 0x04002DA5 RID: 11685
	public Renderer Renderer2;

	// Token: 0x04002DA6 RID: 11686
	public Renderer Renderer3;

	// Token: 0x04002DA7 RID: 11687
	public Texture[] HairSet1;

	// Token: 0x04002DA8 RID: 11688
	public Texture[] HairSet2;

	// Token: 0x04002DA9 RID: 11689
	public Texture[] HairSet3;

	// Token: 0x04002DAA RID: 11690
	public int Selected;

	// Token: 0x04002DAB RID: 11691
	public int CurrentHair;
}
