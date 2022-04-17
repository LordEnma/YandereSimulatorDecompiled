using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BFF RID: 7167 RVA: 0x00147F24 File Offset: 0x00146124
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

	// Token: 0x04003152 RID: 12626
	public GameObject[] DumpPoints;

	// Token: 0x04003153 RID: 12627
	public GameObject Railing;

	// Token: 0x04003154 RID: 12628
	public GameObject Fence;
}
