using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600211A RID: 8474 RVA: 0x001E5700 File Offset: 0x001E3900
	private void Update()
	{
		if (Input.GetKeyDown("left"))
		{
			this.bytes = AstarPath.active.astarData.SerializeGraphs();
		}
		if (Input.GetKeyDown("right"))
		{
			AstarPath.active.astarData.DeserializeGraphs(this.bytes);
			AstarPath.active.Scan(null);
		}
	}

	// Token: 0x040048B2 RID: 18610
	private byte[] bytes;
}
