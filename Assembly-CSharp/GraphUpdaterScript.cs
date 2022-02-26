using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x0600182B RID: 6187 RVA: 0x000E549A File Offset: 0x000E369A
	private void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan(null);
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x04002313 RID: 8979
	public AstarPath Graph;

	// Token: 0x04002314 RID: 8980
	public int Frames;
}
