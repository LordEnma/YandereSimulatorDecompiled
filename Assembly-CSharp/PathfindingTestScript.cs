using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002126 RID: 8486 RVA: 0x001E60D0 File Offset: 0x001E42D0
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

	// Token: 0x040048C4 RID: 18628
	private byte[] bytes;
}
