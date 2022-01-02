using System;
using UnityEngine;

// Token: 0x02000290 RID: 656
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013B8 RID: 5048 RVA: 0x000BA9C4 File Offset: 0x000B8BC4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D5F RID: 7519
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D60 RID: 7520
	public IncineratorScript Incinerator;

	// Token: 0x04001D61 RID: 7521
	public float Timer;
}
