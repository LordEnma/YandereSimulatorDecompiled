using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CCB RID: 7371 RVA: 0x00156D9D File Offset: 0x00154F9D
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CCC RID: 7372 RVA: 0x00156DB9 File Offset: 0x00154FB9
	private void Update()
	{
	}

	// Token: 0x040033F7 RID: 13303
	public Animation YandereAnim;
}
