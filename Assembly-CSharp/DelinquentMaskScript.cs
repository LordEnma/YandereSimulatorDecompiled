using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x0600136A RID: 4970 RVA: 0x000B186C File Offset: 0x000AFA6C
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

	// Token: 0x04001C5A RID: 7258
	public MeshFilter MyRenderer;

	// Token: 0x04001C5B RID: 7259
	public Mesh[] Meshes;

	// Token: 0x04001C5C RID: 7260
	public int ID;
}
