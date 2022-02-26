using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BDC RID: 7132 RVA: 0x00145994 File Offset: 0x00143B94
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			GameObject[] dumpPoints = this.DumpPoints;
			for (int i = 0; i < dumpPoints.Length; i++)
			{
				dumpPoints[i].SetActive(false);
			}
			this.Railing.SetActive(false);
			this.Fence.SetActive(true);
		}
	}

	// Token: 0x040030E1 RID: 12513
	public GameObject[] DumpPoints;

	// Token: 0x040030E2 RID: 12514
	public GameObject Railing;

	// Token: 0x040030E3 RID: 12515
	public GameObject Fence;
}
