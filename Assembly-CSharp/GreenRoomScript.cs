using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600182D RID: 6189 RVA: 0x000E54CD File Offset: 0x000E36CD
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x000E54E6 File Offset: 0x000E36E6
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E54FC File Offset: 0x000E36FC
	private void UpdateColor()
	{
		this.ID++;
		if (this.ID > 7)
		{
			this.ID = 0;
		}
		this.Renderers[0].material.color = this.Colors[this.ID];
		this.Renderers[1].material.color = this.Colors[this.ID];
	}

	// Token: 0x04002315 RID: 8981
	public QualityManagerScript QualityManager;

	// Token: 0x04002316 RID: 8982
	public Color[] Colors;

	// Token: 0x04002317 RID: 8983
	public Renderer[] Renderers;

	// Token: 0x04002318 RID: 8984
	public int ID;
}
