using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x0600181B RID: 6171 RVA: 0x000E4A42 File Offset: 0x000E2C42
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022FE RID: 8958
	public AstarPath Graph;

	// Token: 0x040022FF RID: 8959
	public int Frames;
}
