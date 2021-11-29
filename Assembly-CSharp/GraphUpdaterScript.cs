using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x0600180B RID: 6155 RVA: 0x000E35DE File Offset: 0x000E17DE
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022CA RID: 8906
	public AstarPath Graph;

	// Token: 0x040022CB RID: 8907
	public int Frames;
}
