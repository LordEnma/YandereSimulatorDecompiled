using System;
using UnityEngine;

// Token: 0x02000293 RID: 659
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013C9 RID: 5065 RVA: 0x000BB5E8 File Offset: 0x000B97E8
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D7B RID: 7547
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D7C RID: 7548
	public IncineratorScript Incinerator;

	// Token: 0x04001D7D RID: 7549
	public float Timer;
}
