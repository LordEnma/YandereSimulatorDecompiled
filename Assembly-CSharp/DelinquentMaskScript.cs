using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x06001365 RID: 4965 RVA: 0x000B1330 File Offset: 0x000AF530
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

	// Token: 0x04001C45 RID: 7237
	public MeshFilter MyRenderer;

	// Token: 0x04001C46 RID: 7238
	public Mesh[] Meshes;

	// Token: 0x04001C47 RID: 7239
	public int ID;
}
