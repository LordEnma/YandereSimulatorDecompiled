using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x06001365 RID: 4965 RVA: 0x000B13B0 File Offset: 0x000AF5B0
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

	// Token: 0x04001C47 RID: 7239
	public MeshFilter MyRenderer;

	// Token: 0x04001C48 RID: 7240
	public Mesh[] Meshes;

	// Token: 0x04001C49 RID: 7241
	public int ID;
}
