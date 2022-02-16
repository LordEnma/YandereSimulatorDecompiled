using System;
using UnityEngine;

// Token: 0x02000292 RID: 658
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013C0 RID: 5056 RVA: 0x000BACA8 File Offset: 0x000B8EA8
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D6C RID: 7532
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D6D RID: 7533
	public IncineratorScript Incinerator;

	// Token: 0x04001D6E RID: 7534
	public float Timer;
}
