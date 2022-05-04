using System;
using UnityEngine;

// Token: 0x0200050D RID: 1293
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002176 RID: 8566 RVA: 0x001ED374 File Offset: 0x001EB574
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

	// Token: 0x040049AE RID: 18862
	private byte[] bytes;
}
