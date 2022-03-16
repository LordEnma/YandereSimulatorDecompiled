using System;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x06001506 RID: 5382 RVA: 0x000D8884 File Offset: 0x000D6A84
	public void ActivateKnives()
	{
		foreach (TimeStopKnifeScript timeStopKnifeScript in this.Knives)
		{
			if (timeStopKnifeScript != null)
			{
				timeStopKnifeScript.Unfreeze = true;
			}
		}
		this.ID = 0;
	}

	// Token: 0x040021C3 RID: 8643
	public TimeStopKnifeScript[] Knives;

	// Token: 0x040021C4 RID: 8644
	public int ID;
}
