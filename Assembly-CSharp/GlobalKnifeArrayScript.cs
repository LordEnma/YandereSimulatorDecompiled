using System;
using UnityEngine;

// Token: 0x020002E3 RID: 739
public class GlobalKnifeArrayScript : MonoBehaviour
{
	// Token: 0x060014F0 RID: 5360 RVA: 0x000D6B20 File Offset: 0x000D4D20
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

	// Token: 0x04002179 RID: 8569
	public TimeStopKnifeScript[] Knives;

	// Token: 0x0400217A RID: 8570
	public int ID;
}
