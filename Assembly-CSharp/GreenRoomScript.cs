using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600181D RID: 6173 RVA: 0x000E4A75 File Offset: 0x000E2C75
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x000E4A8E File Offset: 0x000E2C8E
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x000E4AA4 File Offset: 0x000E2CA4
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

	// Token: 0x04002300 RID: 8960
	public QualityManagerScript QualityManager;

	// Token: 0x04002301 RID: 8961
	public Color[] Colors;

	// Token: 0x04002302 RID: 8962
	public Renderer[] Renderers;

	// Token: 0x04002303 RID: 8963
	public int ID;
}
