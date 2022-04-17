using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001840 RID: 6208 RVA: 0x000E64EE File Offset: 0x000E46EE
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x0400234B RID: 9035
	public AstarPath Graph;

	// Token: 0x0400234C RID: 9036
	public int Frames;
}
