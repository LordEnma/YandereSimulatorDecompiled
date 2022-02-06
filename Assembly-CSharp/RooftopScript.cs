using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RooftopScript : MonoBehaviour
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x00144C1C File Offset: 0x00142E1C
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

	// Token: 0x040030CB RID: 12491
	public GameObject[] DumpPoints;

	// Token: 0x040030CC RID: 12492
	public GameObject Railing;

	// Token: 0x040030CD RID: 12493
	public GameObject Fence;
}
