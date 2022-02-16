using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x06001822 RID: 6178 RVA: 0x000E4BB6 File Offset: 0x000E2DB6
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002304 RID: 8964
	public AstarPath Graph;

	// Token: 0x04002305 RID: 8965
	public int Frames;
}
