using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CEA RID: 7402 RVA: 0x00158FE1 File Offset: 0x001571E1
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x00158FFD File Offset: 0x001571FD
	private void Update()
	{
	}

	// Token: 0x04003458 RID: 13400
	public Animation YandereAnim;
}
