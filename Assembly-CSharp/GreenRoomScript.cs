using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600183E RID: 6206 RVA: 0x000E62B9 File Offset: 0x000E44B9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600183F RID: 6207 RVA: 0x000E62D2 File Offset: 0x000E44D2
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001840 RID: 6208 RVA: 0x000E62E8 File Offset: 0x000E44E8
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

	// Token: 0x0400234A RID: 9034
	public QualityManagerScript QualityManager;

	// Token: 0x0400234B RID: 9035
	public Color[] Colors;

	// Token: 0x0400234C RID: 9036
	public Renderer[] Renderers;

	// Token: 0x0400234D RID: 9037
	public int ID;
}
