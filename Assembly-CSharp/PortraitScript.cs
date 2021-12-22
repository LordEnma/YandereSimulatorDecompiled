using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AC4 RID: 6852 RVA: 0x00124E16 File Offset: 0x00123016
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AC5 RID: 6853 RVA: 0x00124E44 File Offset: 0x00123044
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

	// Token: 0x06001AC6 RID: 6854 RVA: 0x00124F3C File Offset: 0x0012313C
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

	// Token: 0x04002D03 RID: 11523
	public GameObject[] StudentObject;

	// Token: 0x04002D04 RID: 11524
	public Renderer Renderer1;

	// Token: 0x04002D05 RID: 11525
	public Renderer Renderer2;

	// Token: 0x04002D06 RID: 11526
	public Renderer Renderer3;

	// Token: 0x04002D07 RID: 11527
	public Texture[] HairSet1;

	// Token: 0x04002D08 RID: 11528
	public Texture[] HairSet2;

	// Token: 0x04002D09 RID: 11529
	public Texture[] HairSet3;

	// Token: 0x04002D0A RID: 11530
	public int Selected;

	// Token: 0x04002D0B RID: 11531
	public int CurrentHair;
}
