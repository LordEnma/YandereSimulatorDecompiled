using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001846 RID: 6214 RVA: 0x000E69E9 File Offset: 0x000E4BE9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001847 RID: 6215 RVA: 0x000E6A02 File Offset: 0x000E4C02
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001848 RID: 6216 RVA: 0x000E6A18 File Offset: 0x000E4C18
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

	// Token: 0x04002356 RID: 9046
	public QualityManagerScript QualityManager;

	// Token: 0x04002357 RID: 9047
	public Color[] Colors;

	// Token: 0x04002358 RID: 9048
	public Renderer[] Renderers;

	// Token: 0x04002359 RID: 9049
	public int ID;
}
