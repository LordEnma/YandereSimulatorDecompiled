using System;
using UnityEngine;

// Token: 0x02000294 RID: 660
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013D3 RID: 5075 RVA: 0x000BBF00 File Offset: 0x000BA100
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D99 RID: 7577
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D9A RID: 7578
	public IncineratorScript Incinerator;

	// Token: 0x04001D9B RID: 7579
	public float Timer;
}
