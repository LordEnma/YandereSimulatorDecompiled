using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001814 RID: 6164 RVA: 0x000E3DD1 File Offset: 0x000E1FD1
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001815 RID: 6165 RVA: 0x000E3DEA File Offset: 0x000E1FEA
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001816 RID: 6166 RVA: 0x000E3E00 File Offset: 0x000E2000
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

	// Token: 0x040022EC RID: 8940
	public QualityManagerScript QualityManager;

	// Token: 0x040022ED RID: 8941
	public Color[] Colors;

	// Token: 0x040022EE RID: 8942
	public Renderer[] Renderers;

	// Token: 0x040022EF RID: 8943
	public int ID;
}
