using System;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014F5 RID: 5365 RVA: 0x000D7658 File Offset: 0x000D5858
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

	// Token: 0x04002189 RID: 8585
	public TimeStopKnifeScript[] Knives;

	// Token: 0x0400218A RID: 8586
	public int ID;
}
