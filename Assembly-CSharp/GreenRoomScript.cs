using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600182D RID: 6189 RVA: 0x000E57FD File Offset: 0x000E39FD
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x000E5816 File Offset: 0x000E3A16
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x000E582C File Offset: 0x000E3A2C
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

	// Token: 0x04002329 RID: 9001
	public QualityManagerScript QualityManager;

	// Token: 0x0400232A RID: 9002
	public Color[] Colors;

	// Token: 0x0400232B RID: 9003
	public Renderer[] Renderers;

	// Token: 0x0400232C RID: 9004
	public int ID;
}
