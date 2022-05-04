using System;
using UnityEngine;

// Token: 0x020003F2 RID: 1010
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x0014872C File Offset: 0x0014692C
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

	// Token: 0x04003161 RID: 12641
	public GameObject[] DumpPoints;

	// Token: 0x04003162 RID: 12642
	public GameObject Railing;

	// Token: 0x04003163 RID: 12643
	public GameObject Fence;
}
