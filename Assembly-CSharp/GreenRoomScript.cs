using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600181B RID: 6171 RVA: 0x000E48D1 File Offset: 0x000E2AD1
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x000E48EA File Offset: 0x000E2AEA
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600181D RID: 6173 RVA: 0x000E4900 File Offset: 0x000E2B00
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

	// Token: 0x040022FC RID: 8956
	public QualityManagerScript QualityManager;

	// Token: 0x040022FD RID: 8957
	public Color[] Colors;

	// Token: 0x040022FE RID: 8958
	public Renderer[] Renderers;

	// Token: 0x040022FF RID: 8959
	public int ID;
}
