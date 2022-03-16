using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001832 RID: 6194 RVA: 0x000E5CA9 File Offset: 0x000E3EA9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001833 RID: 6195 RVA: 0x000E5CC2 File Offset: 0x000E3EC2
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001834 RID: 6196 RVA: 0x000E5CD8 File Offset: 0x000E3ED8
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

	// Token: 0x0400233A RID: 9018
	public QualityManagerScript QualityManager;

	// Token: 0x0400233B RID: 9019
	public Color[] Colors;

	// Token: 0x0400233C RID: 9020
	public Renderer[] Renderers;

	// Token: 0x0400233D RID: 9021
	public int ID;
}
