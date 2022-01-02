using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001816 RID: 6166 RVA: 0x000E40A1 File Offset: 0x000E22A1
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001817 RID: 6167 RVA: 0x000E40BA File Offset: 0x000E22BA
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001818 RID: 6168 RVA: 0x000E40D0 File Offset: 0x000E22D0
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

	// Token: 0x040022F0 RID: 8944
	public QualityManagerScript QualityManager;

	// Token: 0x040022F1 RID: 8945
	public Color[] Colors;

	// Token: 0x040022F2 RID: 8946
	public Renderer[] Renderers;

	// Token: 0x040022F3 RID: 8947
	public int ID;
}
