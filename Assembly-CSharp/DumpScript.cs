using System;
using UnityEngine;

// Token: 0x02000295 RID: 661
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013D9 RID: 5081 RVA: 0x000BC5E4 File Offset: 0x000BA7E4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001DA9 RID: 7593
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001DAA RID: 7594
	public IncineratorScript Incinerator;

	// Token: 0x04001DAB RID: 7595
	public float Timer;
}
