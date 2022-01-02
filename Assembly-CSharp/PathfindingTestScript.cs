using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002109 RID: 8457 RVA: 0x001E37F0 File Offset: 0x001E19F0
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

	// Token: 0x0400488C RID: 18572
	private byte[] bytes;
}
