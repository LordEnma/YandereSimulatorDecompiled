using System;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001C0C RID: 7180 RVA: 0x001493E0 File Offset: 0x001475E0
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

	// Token: 0x04003176 RID: 12662
	public GameObject[] DumpPoints;

	// Token: 0x04003177 RID: 12663
	public GameObject Railing;

	// Token: 0x04003178 RID: 12664
	public GameObject Fence;
}
