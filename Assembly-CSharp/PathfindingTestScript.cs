using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002180 RID: 8576 RVA: 0x001EE9C4 File Offset: 0x001ECBC4
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

	// Token: 0x040049D5 RID: 18901
	private byte[] bytes;
}
