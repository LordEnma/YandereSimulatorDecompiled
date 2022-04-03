using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x0600136E RID: 4974 RVA: 0x000B1CF8 File Offset: 0x000AFEF8
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

	// Token: 0x04001C6B RID: 7275
	public MeshFilter MyRenderer;

	// Token: 0x04001C6C RID: 7276
	public Mesh[] Meshes;

	// Token: 0x04001C6D RID: 7277
	public int ID;
}
