using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013B8 RID: 5048 RVA: 0x000BA77C File Offset: 0x000B897C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D5C RID: 7516
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D5D RID: 7517
	public IncineratorScript Incinerator;

	// Token: 0x04001D5E RID: 7518
	public float Timer;
}
