using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CC6 RID: 7366 RVA: 0x00154FB9 File Offset: 0x001531B9
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CC7 RID: 7367 RVA: 0x00154FD5 File Offset: 0x001531D5
	private void Update()
	{
	}

	// Token: 0x040033E8 RID: 13288
	public Animation YandereAnim;
}
