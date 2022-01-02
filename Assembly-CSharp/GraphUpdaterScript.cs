using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001814 RID: 6164 RVA: 0x000E406E File Offset: 0x000E226E
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022EE RID: 8942
	public AstarPath Graph;

	// Token: 0x040022EF RID: 8943
	public int Frames;
}
