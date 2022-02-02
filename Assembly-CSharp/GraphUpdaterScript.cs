using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001819 RID: 6169 RVA: 0x000E489E File Offset: 0x000E2A9E
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022FA RID: 8954
	public AstarPath Graph;

	// Token: 0x040022FB RID: 8955
	public int Frames;
}
