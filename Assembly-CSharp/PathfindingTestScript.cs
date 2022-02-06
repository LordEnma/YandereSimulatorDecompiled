using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001E5C1C File Offset: 0x001E3E1C
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

	// Token: 0x040048BB RID: 18619
	private byte[] bytes;
}
