using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013BC RID: 5052 RVA: 0x000BAD64 File Offset: 0x000B8F64
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D69 RID: 7529
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D6A RID: 7530
	public IncineratorScript Incinerator;

	// Token: 0x04001D6B RID: 7531
	public float Timer;
}
