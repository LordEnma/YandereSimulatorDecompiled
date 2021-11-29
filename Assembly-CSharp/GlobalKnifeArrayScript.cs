using System;
using UnityEngine;

// Token: 0x020002E2 RID: 738
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014E9 RID: 5353 RVA: 0x000D6360 File Offset: 0x000D4560
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

	// Token: 0x04002159 RID: 8537
	public TimeStopKnifeScript[] Knives;

	// Token: 0x0400215A RID: 8538
	public int ID;
}
