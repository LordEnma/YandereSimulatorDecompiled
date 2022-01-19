using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BC9 RID: 7113 RVA: 0x0014453C File Offset: 0x0014273C
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

	// Token: 0x040030C1 RID: 12481
	public GameObject[] DumpPoints;

	// Token: 0x040030C2 RID: 12482
	public GameObject Railing;

	// Token: 0x040030C3 RID: 12483
	public GameObject Fence;
}
