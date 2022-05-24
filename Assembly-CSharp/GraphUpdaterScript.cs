using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001849 RID: 6217 RVA: 0x000E6E32 File Offset: 0x000E5032
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002360 RID: 9056
	public AstarPath Graph;

	// Token: 0x04002361 RID: 9057
	public int Frames;
}
