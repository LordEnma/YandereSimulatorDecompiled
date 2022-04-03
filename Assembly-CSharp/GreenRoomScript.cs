using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001838 RID: 6200 RVA: 0x000E61A9 File Offset: 0x000E43A9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x000E61C2 File Offset: 0x000E43C2
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600183A RID: 6202 RVA: 0x000E61D8 File Offset: 0x000E43D8
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

	// Token: 0x04002348 RID: 9032
	public QualityManagerScript QualityManager;

	// Token: 0x04002349 RID: 9033
	public Color[] Colors;

	// Token: 0x0400234A RID: 9034
	public Renderer[] Renderers;

	// Token: 0x0400234B RID: 9035
	public int ID;
}
