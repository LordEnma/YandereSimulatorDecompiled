using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E43C9 File Offset: 0x000E25C9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000E43E2 File Offset: 0x000E25E2
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x000E43F8 File Offset: 0x000E25F8
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

	// Token: 0x040022F4 RID: 8948
	public QualityManagerScript QualityManager;

	// Token: 0x040022F5 RID: 8949
	public Color[] Colors;

	// Token: 0x040022F6 RID: 8950
	public Renderer[] Renderers;

	// Token: 0x040022F7 RID: 8951
	public int ID;
}
