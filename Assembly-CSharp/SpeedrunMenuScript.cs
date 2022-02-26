using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CDB RID: 7387 RVA: 0x00157B51 File Offset: 0x00155D51
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CDC RID: 7388 RVA: 0x00157B6D File Offset: 0x00155D6D
	private void Update()
	{
	}

	// Token: 0x0400340D RID: 13325
	public Animation YandereAnim;
}
