using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x06001374 RID: 4980 RVA: 0x000B25E8 File Offset: 0x000B07E8
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			this.ID++;
			if (this.ID > 4)
			{
				this.ID = 0;
			}
			this.MyRenderer.mesh = this.Meshes[this.ID];
		}
	}

	// Token: 0x04001C7B RID: 7291
	public MeshFilter MyRenderer;

	// Token: 0x04001C7C RID: 7292
	public Mesh[] Meshes;

	// Token: 0x04001C7D RID: 7293
	public int ID;
}
