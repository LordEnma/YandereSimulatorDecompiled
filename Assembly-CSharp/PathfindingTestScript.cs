using System;
using UnityEngine;

// Token: 0x020004FA RID: 1274
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E1ACC File Offset: 0x001DFCCC
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

	// Token: 0x04004844 RID: 18500
	private byte[] bytes;
}
