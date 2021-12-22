using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001812 RID: 6162 RVA: 0x000E3D9E File Offset: 0x000E1F9E
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x040022EA RID: 8938
	public AstarPath Graph;

	// Token: 0x040022EB RID: 8939
	public int Frames;
}
