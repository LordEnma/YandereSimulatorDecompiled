using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001836 RID: 6198 RVA: 0x000E6176 File Offset: 0x000E4376
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002346 RID: 9030
	public AstarPath Graph;

	// Token: 0x04002347 RID: 9031
	public int Frames;
}
