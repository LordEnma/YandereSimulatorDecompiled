using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class PortraitScript : MonoBehaviour
{
	// Token: 0x06001AFA RID: 6906 RVA: 0x00128402 File Offset: 0x00126602
	private void Start()
	{
		this.StudentObject[1].SetActive(false);
		this.StudentObject[2].SetActive(false);
		this.Selected = 1;
		this.UpdateHair();
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x00128430 File Offset: 0x00126630
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

	// Token: 0x06001AFC RID: 6908 RVA: 0x00128528 File Offset: 0x00126728
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

	// Token: 0x04002D8F RID: 11663
	public GameObject[] StudentObject;

	// Token: 0x04002D90 RID: 11664
	public Renderer Renderer1;

	// Token: 0x04002D91 RID: 11665
	public Renderer Renderer2;

	// Token: 0x04002D92 RID: 11666
	public Renderer Renderer3;

	// Token: 0x04002D93 RID: 11667
	public Texture[] HairSet1;

	// Token: 0x04002D94 RID: 11668
	public Texture[] HairSet2;

	// Token: 0x04002D95 RID: 11669
	public Texture[] HairSet3;

	// Token: 0x04002D96 RID: 11670
	public int Selected;

	// Token: 0x04002D97 RID: 11671
	public int CurrentHair;
}
