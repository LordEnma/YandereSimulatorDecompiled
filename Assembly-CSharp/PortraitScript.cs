using System;
using UnityEngine;

// Token: 0x020003AD RID: 941
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001ABC RID: 6844 RVA: 0x001245C2 File Offset: 0x001227C2
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001ABD RID: 6845 RVA: 0x001245F0 File Offset: 0x001227F0
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

	// Token: 0x06001ABE RID: 6846 RVA: 0x001246E8 File Offset: 0x001228E8
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

	// Token: 0x04002CD9 RID: 11481
	public GameObject[] StudentObject;

	// Token: 0x04002CDA RID: 11482
	public Renderer Renderer1;

	// Token: 0x04002CDB RID: 11483
	public Renderer Renderer2;

	// Token: 0x04002CDC RID: 11484
	public Renderer Renderer3;

	// Token: 0x04002CDD RID: 11485
	public Texture[] HairSet1;

	// Token: 0x04002CDE RID: 11486
	public Texture[] HairSet2;

	// Token: 0x04002CDF RID: 11487
	public Texture[] HairSet3;

	// Token: 0x04002CE0 RID: 11488
	public int Selected;

	// Token: 0x04002CE1 RID: 11489
	public int CurrentHair;
}
