using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BBE RID: 7102 RVA: 0x001426C4 File Offset: 0x001408C4
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

	// Token: 0x040030AF RID: 12463
	public GameObject[] DumpPoints;

	// Token: 0x040030B0 RID: 12464
	public GameObject Railing;

	// Token: 0x040030B1 RID: 12465
	public GameObject Fence;
}
