using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CBF RID: 7359 RVA: 0x00154CB5 File Offset: 0x00152EB5
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x00154CD1 File Offset: 0x00152ED1
	private void Update()
	{
	}

	// Token: 0x040033E2 RID: 13282
	public Animation YandereAnim;
}
