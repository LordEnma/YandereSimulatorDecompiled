using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001C0D RID: 7181 RVA: 0x0014969C File Offset: 0x0014789C
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

	// Token: 0x0400317E RID: 12670
	public GameObject[] DumpPoints;

	// Token: 0x0400317F RID: 12671
	public GameObject Railing;

	// Token: 0x04003180 RID: 12672
	public GameObject Fence;
}
