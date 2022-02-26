using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AE0 RID: 6880 RVA: 0x00126AD6 File Offset: 0x00124CD6
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AE1 RID: 6881 RVA: 0x00126B04 File Offset: 0x00124D04
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

	// Token: 0x06001AE2 RID: 6882 RVA: 0x00126BFC File Offset: 0x00124DFC
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

	// Token: 0x04002D31 RID: 11569
	public GameObject[] StudentObject;

	// Token: 0x04002D32 RID: 11570
	public Renderer Renderer1;

	// Token: 0x04002D33 RID: 11571
	public Renderer Renderer2;

	// Token: 0x04002D34 RID: 11572
	public Renderer Renderer3;

	// Token: 0x04002D35 RID: 11573
	public Texture[] HairSet1;

	// Token: 0x04002D36 RID: 11574
	public Texture[] HairSet2;

	// Token: 0x04002D37 RID: 11575
	public Texture[] HairSet3;

	// Token: 0x04002D38 RID: 11576
	public int Selected;

	// Token: 0x04002D39 RID: 11577
	public int CurrentHair;
}
