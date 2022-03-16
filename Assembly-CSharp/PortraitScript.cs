using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AEB RID: 6891 RVA: 0x00127B5E File Offset: 0x00125D5E
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AEC RID: 6892 RVA: 0x00127B8C File Offset: 0x00125D8C
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

	// Token: 0x06001AED RID: 6893 RVA: 0x00127C84 File Offset: 0x00125E84
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

	// Token: 0x04002D74 RID: 11636
	public GameObject[] StudentObject;

	// Token: 0x04002D75 RID: 11637
	public Renderer Renderer1;

	// Token: 0x04002D76 RID: 11638
	public Renderer Renderer2;

	// Token: 0x04002D77 RID: 11639
	public Renderer Renderer3;

	// Token: 0x04002D78 RID: 11640
	public Texture[] HairSet1;

	// Token: 0x04002D79 RID: 11641
	public Texture[] HairSet2;

	// Token: 0x04002D7A RID: 11642
	public Texture[] HairSet3;

	// Token: 0x04002D7B RID: 11643
	public int Selected;

	// Token: 0x04002D7C RID: 11644
	public int CurrentHair;
}
