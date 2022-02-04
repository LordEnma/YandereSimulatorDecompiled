using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00156C05 File Offset: 0x00154E05
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CCA RID: 7370 RVA: 0x00156C21 File Offset: 0x00154E21
	private void Update()
	{
	}

	// Token: 0x040033F4 RID: 13300
	public Animation YandereAnim;
}
