using System;
using UnityEngine;

// Token: 0x0200050C RID: 1292
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x0600216C RID: 8556 RVA: 0x001EBDEC File Offset: 0x001E9FEC
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

	// Token: 0x04004998 RID: 18840
	private byte[] bytes;
}
