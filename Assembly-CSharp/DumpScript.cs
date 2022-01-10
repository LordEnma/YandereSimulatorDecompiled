using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013BB RID: 5051 RVA: 0x000BAA68 File Offset: 0x000B8C68
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D60 RID: 7520
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D61 RID: 7521
	public IncineratorScript Incinerator;

	// Token: 0x04001D62 RID: 7522
	public float Timer;
}
