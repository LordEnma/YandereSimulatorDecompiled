using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BF5 RID: 7157 RVA: 0x00147830 File Offset: 0x00145A30
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

	// Token: 0x04003144 RID: 12612
	public GameObject[] DumpPoints;

	// Token: 0x04003145 RID: 12613
	public GameObject Railing;

	// Token: 0x04003146 RID: 12614
	public GameObject Fence;
}
