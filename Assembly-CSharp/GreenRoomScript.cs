using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E44B5 File Offset: 0x000E26B5
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000E44CE File Offset: 0x000E26CE
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x000E44E4 File Offset: 0x000E26E4
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

	// Token: 0x040022F7 RID: 8951
	public QualityManagerScript QualityManager;

	// Token: 0x040022F8 RID: 8952
	public Color[] Colors;

	// Token: 0x040022F9 RID: 8953
	public Renderer[] Renderers;

	// Token: 0x040022FA RID: 8954
	public int ID;
}
