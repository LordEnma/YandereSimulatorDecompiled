using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013B1 RID: 5041 RVA: 0x000BA1E0 File Offset: 0x000B83E0
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D3C RID: 7484
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D3D RID: 7485
	public IncineratorScript Incinerator;

	// Token: 0x04001D3E RID: 7486
	public float Timer;
}
