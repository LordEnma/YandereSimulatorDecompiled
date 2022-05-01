using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001844 RID: 6212 RVA: 0x000E69EA File Offset: 0x000E4BEA
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002354 RID: 9044
	public AstarPath Graph;

	// Token: 0x04002355 RID: 9045
	public int Frames;
}
