using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x0600182B RID: 6187 RVA: 0x000E57CA File Offset: 0x000E39CA
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002327 RID: 8999
	public AstarPath Graph;

	// Token: 0x04002328 RID: 9000
	public int Frames;
}
