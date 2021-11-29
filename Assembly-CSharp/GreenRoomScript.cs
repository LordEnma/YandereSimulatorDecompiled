using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600180D RID: 6157 RVA: 0x000E3611 File Offset: 0x000E1811
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600180E RID: 6158 RVA: 0x000E362A File Offset: 0x000E182A
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600180F RID: 6159 RVA: 0x000E3640 File Offset: 0x000E1840
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

	// Token: 0x040022CC RID: 8908
	public QualityManagerScript QualityManager;

	// Token: 0x040022CD RID: 8909
	public Color[] Colors;

	// Token: 0x040022CE RID: 8910
	public Renderer[] Renderers;

	// Token: 0x040022CF RID: 8911
	public int ID;
}
