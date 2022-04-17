using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AFE RID: 6910 RVA: 0x00128812 File Offset: 0x00126A12
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AFF RID: 6911 RVA: 0x00128840 File Offset: 0x00126A40
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

	// Token: 0x06001B00 RID: 6912 RVA: 0x00128938 File Offset: 0x00126B38
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

	// Token: 0x04002D9A RID: 11674
	public GameObject[] StudentObject;

	// Token: 0x04002D9B RID: 11675
	public Renderer Renderer1;

	// Token: 0x04002D9C RID: 11676
	public Renderer Renderer2;

	// Token: 0x04002D9D RID: 11677
	public Renderer Renderer3;

	// Token: 0x04002D9E RID: 11678
	public Texture[] HairSet1;

	// Token: 0x04002D9F RID: 11679
	public Texture[] HairSet2;

	// Token: 0x04002DA0 RID: 11680
	public Texture[] HairSet3;

	// Token: 0x04002DA1 RID: 11681
	public int Selected;

	// Token: 0x04002DA2 RID: 11682
	public int CurrentHair;
}
