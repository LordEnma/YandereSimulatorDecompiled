using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x0600136A RID: 4970 RVA: 0x000B14F8 File Offset: 0x000AF6F8
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

	// Token: 0x04001C50 RID: 7248
	public MeshFilter MyRenderer;

	// Token: 0x04001C51 RID: 7249
	public Mesh[] Meshes;

	// Token: 0x04001C52 RID: 7250
	public int ID;
}
