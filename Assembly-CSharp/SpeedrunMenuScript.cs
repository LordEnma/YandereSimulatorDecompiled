using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CB5 RID: 7349 RVA: 0x00153F4D File Offset: 0x0015214D
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00153F69 File Offset: 0x00152169
	private void Update()
	{
	}

	// Token: 0x040033B0 RID: 13232
	public Animation YandereAnim;
}
