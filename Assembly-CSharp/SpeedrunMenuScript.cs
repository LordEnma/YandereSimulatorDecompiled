using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CBD RID: 7357 RVA: 0x00154871 File Offset: 0x00152A71
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x0015488D File Offset: 0x00152A8D
	private void Update()
	{
	}

	// Token: 0x040033DB RID: 13275
	public Animation YandereAnim;
}
