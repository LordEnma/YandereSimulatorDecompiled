using System;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600214D RID: 8525 RVA: 0x001E95F0 File Offset: 0x001E77F0
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

	// Token: 0x04004950 RID: 18768
	private byte[] bytes;
}
