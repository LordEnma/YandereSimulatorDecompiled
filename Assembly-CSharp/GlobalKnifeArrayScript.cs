using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014F5 RID: 5365 RVA: 0x000D770C File Offset: 0x000D590C
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

	// Token: 0x0400218B RID: 8587
	public TimeStopKnifeScript[] Knives;

	// Token: 0x0400218C RID: 8588
	public int ID;
}
