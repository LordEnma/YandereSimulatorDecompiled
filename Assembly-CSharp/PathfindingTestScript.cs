using System;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600215D RID: 8541 RVA: 0x001EAE60 File Offset: 0x001E9060
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

	// Token: 0x04004982 RID: 18818
	private byte[] bytes;
}
