using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002181 RID: 8577 RVA: 0x001EEF2C File Offset: 0x001ED12C
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

	// Token: 0x040049DE RID: 18910
	private byte[] bytes;
}
