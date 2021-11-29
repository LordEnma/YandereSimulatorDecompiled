using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BB6 RID: 7094 RVA: 0x00141E04 File Offset: 0x00140004
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

	// Token: 0x04003085 RID: 12421
	public GameObject[] DumpPoints;

	// Token: 0x04003086 RID: 12422
	public GameObject Railing;

	// Token: 0x04003087 RID: 12423
	public GameObject Fence;
}
