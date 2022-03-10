using System;
using UnityEngine;

// Token: 0x020003EC RID: 1004
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BDE RID: 7134 RVA: 0x00145ED0 File Offset: 0x001440D0
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

	// Token: 0x040030F7 RID: 12535
	public GameObject[] DumpPoints;

	// Token: 0x040030F8 RID: 12536
	public GameObject Railing;

	// Token: 0x040030F9 RID: 12537
	public GameObject Fence;
}
