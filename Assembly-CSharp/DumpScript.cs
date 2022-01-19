using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013BB RID: 5051 RVA: 0x000BAACC File Offset: 0x000B8CCC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D62 RID: 7522
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D63 RID: 7523
	public IncineratorScript Incinerator;

	// Token: 0x04001D64 RID: 7524
	public float Timer;
}
