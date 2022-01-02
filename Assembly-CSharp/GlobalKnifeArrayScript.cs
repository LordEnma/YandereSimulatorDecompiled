using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014F0 RID: 5360 RVA: 0x000D6D70 File Offset: 0x000D4F70
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

	// Token: 0x0400217C RID: 8572
	public TimeStopKnifeScript[] Knives;

	// Token: 0x0400217D RID: 8573
	public int ID;
}
