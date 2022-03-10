using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013C9 RID: 5065 RVA: 0x000BB750 File Offset: 0x000B9950
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D84 RID: 7556
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D85 RID: 7557
	public IncineratorScript Incinerator;

	// Token: 0x04001D86 RID: 7558
	public float Timer;
}
