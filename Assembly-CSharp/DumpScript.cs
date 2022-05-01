using System;
using UnityEngine;

// Token: 0x02000294 RID: 660
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013D7 RID: 5079 RVA: 0x000BC3A4 File Offset: 0x000BA5A4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001DA2 RID: 7586
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001DA3 RID: 7587
	public IncineratorScript Incinerator;

	// Token: 0x04001DA4 RID: 7588
	public float Timer;
}
