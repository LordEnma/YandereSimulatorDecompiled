using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00156B01 File Offset: 0x00154D01
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CCA RID: 7370 RVA: 0x00156B1D File Offset: 0x00154D1D
	private void Update()
	{
	}

	// Token: 0x040033F3 RID: 13299
	public Animation YandereAnim;
}
