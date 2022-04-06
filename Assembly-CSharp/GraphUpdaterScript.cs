using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x0600183C RID: 6204 RVA: 0x000E6286 File Offset: 0x000E4486
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002348 RID: 9032
	public AstarPath Graph;

	// Token: 0x04002349 RID: 9033
	public int Frames;
}
