using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600212F RID: 8495 RVA: 0x001E6CB0 File Offset: 0x001E4EB0
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

	// Token: 0x040048D4 RID: 18644
	private byte[] bytes;
}
