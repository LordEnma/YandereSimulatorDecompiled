using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x0600184B RID: 6219 RVA: 0x000E6E65 File Offset: 0x000E5065
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x0600184C RID: 6220 RVA: 0x000E6E7E File Offset: 0x000E507E
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000E6E94 File Offset: 0x000E5094
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

	// Token: 0x04002362 RID: 9058
	public QualityManagerScript QualityManager;

	// Token: 0x04002363 RID: 9059
	public Color[] Colors;

	// Token: 0x04002364 RID: 9060
	public Renderer[] Renderers;

	// Token: 0x04002365 RID: 9061
	public int ID;
}
