using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x0600136D RID: 4973 RVA: 0x000B1C48 File Offset: 0x000AFE48
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

	// Token: 0x04001C68 RID: 7272
	public MeshFilter MyRenderer;

	// Token: 0x04001C69 RID: 7273
	public Mesh[] Meshes;

	// Token: 0x04001C6A RID: 7274
	public int ID;
}
