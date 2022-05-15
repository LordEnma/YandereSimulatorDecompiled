using System;
using UnityEngine;

// Token: 0x020003B7 RID: 951
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001B08 RID: 6920 RVA: 0x0012999A File Offset: 0x00127B9A
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x001299C8 File Offset: 0x00127BC8
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

	// Token: 0x06001B0A RID: 6922 RVA: 0x00129AC0 File Offset: 0x00127CC0
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

	// Token: 0x04002DB8 RID: 11704
	public GameObject[] StudentObject;

	// Token: 0x04002DB9 RID: 11705
	public Renderer Renderer1;

	// Token: 0x04002DBA RID: 11706
	public Renderer Renderer2;

	// Token: 0x04002DBB RID: 11707
	public Renderer Renderer3;

	// Token: 0x04002DBC RID: 11708
	public Texture[] HairSet1;

	// Token: 0x04002DBD RID: 11709
	public Texture[] HairSet2;

	// Token: 0x04002DBE RID: 11710
	public Texture[] HairSet3;

	// Token: 0x04002DBF RID: 11711
	public int Selected;

	// Token: 0x04002DC0 RID: 11712
	public int CurrentHair;
}
