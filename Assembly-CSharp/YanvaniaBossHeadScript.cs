using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x001E54B1 File Offset: 0x001E36B1
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x001E54C8 File Offset: 0x001E36C8
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x0400481B RID: 18459
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400481C RID: 18460
	public GameObject HitEffect;

	// Token: 0x0400481D RID: 18461
	public float Timer;
}
