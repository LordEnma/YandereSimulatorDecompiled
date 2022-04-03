using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013CD RID: 5069 RVA: 0x000BBC74 File Offset: 0x000B9E74
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D96 RID: 7574
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D97 RID: 7575
	public IncineratorScript Incinerator;

	// Token: 0x04001D98 RID: 7576
	public float Timer;
}
