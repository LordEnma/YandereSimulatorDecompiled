using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001842 RID: 6210 RVA: 0x000E6521 File Offset: 0x000E4721
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x000E653A File Offset: 0x000E473A
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x000E6550 File Offset: 0x000E4750
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

	// Token: 0x0400234D RID: 9037
	public QualityManagerScript QualityManager;

	// Token: 0x0400234E RID: 9038
	public Color[] Colors;

	// Token: 0x0400234F RID: 9039
	public Renderer[] Renderers;

	// Token: 0x04002350 RID: 9040
	public int ID;
}
