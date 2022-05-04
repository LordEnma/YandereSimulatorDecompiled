using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x0015AA75 File Offset: 0x00158C75
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x0015AA91 File Offset: 0x00158C91
	private void Update()
	{
	}

	// Token: 0x04003491 RID: 13457
	public Animation YandereAnim;
}
