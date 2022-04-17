using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CFF RID: 7423 RVA: 0x0015A26D File Offset: 0x0015846D
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001D00 RID: 7424 RVA: 0x0015A289 File Offset: 0x00158489
	private void Update()
	{
	}

	// Token: 0x04003482 RID: 13442
	public Animation YandereAnim;
}
