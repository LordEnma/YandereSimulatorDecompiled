using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x06001372 RID: 4978 RVA: 0x000B2308 File Offset: 0x000B0508
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

	// Token: 0x04001C74 RID: 7284
	public MeshFilter MyRenderer;

	// Token: 0x04001C75 RID: 7285
	public Mesh[] Meshes;

	// Token: 0x04001C76 RID: 7286
	public int ID;
}
