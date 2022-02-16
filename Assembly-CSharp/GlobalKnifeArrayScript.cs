using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014FA RID: 5370 RVA: 0x000D7800 File Offset: 0x000D5A00
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

	// Token: 0x04002190 RID: 8592
	public TimeStopKnifeScript[] Knives;

	// Token: 0x04002191 RID: 8593
	public int ID;
}
