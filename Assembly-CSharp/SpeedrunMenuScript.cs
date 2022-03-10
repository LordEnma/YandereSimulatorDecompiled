using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpeedrunMenuScript : MonoBehaviour
{
	// Token: 0x06001CDD RID: 7389 RVA: 0x001580D5 File Offset: 0x001562D5
	private void Start()
	{
		this.YandereAnim["f02_nierRun_00"].speed = 1.5f;
	}

	// Token: 0x06001CDE RID: 7390 RVA: 0x001580F1 File Offset: 0x001562F1
	private void Update()
	{
	}

	// Token: 0x04003423 RID: 13347
	public Animation YandereAnim;
}
