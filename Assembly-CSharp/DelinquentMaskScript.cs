using System;
using UnityEngine;

// Token: 0x02000277 RID: 631
public class DelinquentMaskScript : MonoBehaviour
{
	// Token: 0x0600135E RID: 4958 RVA: 0x000B0B88 File Offset: 0x000AED88
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

	// Token: 0x04001C22 RID: 7202
	public MeshFilter MyRenderer;

	// Token: 0x04001C23 RID: 7203
	public Mesh[] Meshes;

	// Token: 0x04001C24 RID: 7204
	public int ID;
}
