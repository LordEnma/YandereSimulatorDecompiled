using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BD3 RID: 7123 RVA: 0x00144F1C File Offset: 0x0014311C
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

	// Token: 0x040030D1 RID: 12497
	public GameObject[] DumpPoints;

	// Token: 0x040030D2 RID: 12498
	public GameObject Railing;

	// Token: 0x040030D3 RID: 12499
	public GameObject Fence;
}
