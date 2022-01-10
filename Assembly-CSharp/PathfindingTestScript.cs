using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002114 RID: 8468 RVA: 0x001E4190 File Offset: 0x001E2390
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

	// Token: 0x040048A0 RID: 18592
	private byte[] bytes;
}
