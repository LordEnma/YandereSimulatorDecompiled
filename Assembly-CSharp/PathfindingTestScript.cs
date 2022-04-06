using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002165 RID: 8549 RVA: 0x001EB390 File Offset: 0x001E9590
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

	// Token: 0x04004986 RID: 18822
	private byte[] bytes;
}
