using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AD0 RID: 6864 RVA: 0x00125D8E File Offset: 0x00123F8E
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AD1 RID: 6865 RVA: 0x00125DBC File Offset: 0x00123FBC
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

	// Token: 0x06001AD2 RID: 6866 RVA: 0x00125EB4 File Offset: 0x001240B4
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

	// Token: 0x04002D1B RID: 11547
	public GameObject[] StudentObject;

	// Token: 0x04002D1C RID: 11548
	public Renderer Renderer1;

	// Token: 0x04002D1D RID: 11549
	public Renderer Renderer2;

	// Token: 0x04002D1E RID: 11550
	public Renderer Renderer3;

	// Token: 0x04002D1F RID: 11551
	public Texture[] HairSet1;

	// Token: 0x04002D20 RID: 11552
	public Texture[] HairSet2;

	// Token: 0x04002D21 RID: 11553
	public Texture[] HairSet3;

	// Token: 0x04002D22 RID: 11554
	public int Selected;

	// Token: 0x04002D23 RID: 11555
	public int CurrentHair;
}
