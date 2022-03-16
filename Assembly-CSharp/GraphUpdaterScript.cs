using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001830 RID: 6192 RVA: 0x000E5C76 File Offset: 0x000E3E76
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002338 RID: 9016
	public AstarPath Graph;

	// Token: 0x04002339 RID: 9017
	public int Frames;
}
