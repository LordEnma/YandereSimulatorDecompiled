using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013CC RID: 5068 RVA: 0x000BBB68 File Offset: 0x000B9D68
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D93 RID: 7571
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D94 RID: 7572
	public IncineratorScript Incinerator;

	// Token: 0x04001D95 RID: 7573
	public float Timer;
}
