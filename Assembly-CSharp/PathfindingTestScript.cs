using System;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class PathfindingTestScript : MonoBehaviour
{
	// Token: 0x06002135 RID: 8501 RVA: 0x001E7688 File Offset: 0x001E5888
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

	// Token: 0x040048F1 RID: 18673
	private byte[] bytes;
}
