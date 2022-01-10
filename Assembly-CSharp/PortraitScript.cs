using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001ACD RID: 6861 RVA: 0x0012552A File Offset: 0x0012372A
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001ACE RID: 6862 RVA: 0x00125558 File Offset: 0x00123758
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

	// Token: 0x06001ACF RID: 6863 RVA: 0x00125650 File Offset: 0x00123850
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

	// Token: 0x04002D0D RID: 11533
	public GameObject[] StudentObject;

	// Token: 0x04002D0E RID: 11534
	public Renderer Renderer1;

	// Token: 0x04002D0F RID: 11535
	public Renderer Renderer2;

	// Token: 0x04002D10 RID: 11536
	public Renderer Renderer3;

	// Token: 0x04002D11 RID: 11537
	public Texture[] HairSet1;

	// Token: 0x04002D12 RID: 11538
	public Texture[] HairSet2;

	// Token: 0x04002D13 RID: 11539
	public Texture[] HairSet3;

	// Token: 0x04002D14 RID: 11540
	public int Selected;

	// Token: 0x04002D15 RID: 11541
	public int CurrentHair;
}
