using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x06001366 RID: 4966 RVA: 0x000B14F8 File Offset: 0x000AF6F8
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

	// Token: 0x04001C4B RID: 7243
	public MeshFilter MyRenderer;

	// Token: 0x04001C4C RID: 7244
	public Mesh[] Meshes;

	// Token: 0x04001C4D RID: 7245
	public int ID;
}
