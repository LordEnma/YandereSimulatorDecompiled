using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001818 RID: 6168 RVA: 0x000E4396 File Offset: 0x000E2596
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022F2 RID: 8946
	public AstarPath Graph;

	// Token: 0x040022F3 RID: 8947
	public int Frames;
}
