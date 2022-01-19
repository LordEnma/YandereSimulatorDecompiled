using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001E4E60 File Offset: 0x001E3060
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

	// Token: 0x040048A7 RID: 18599
	private byte[] bytes;
}
