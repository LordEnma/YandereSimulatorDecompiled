using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x0600206F RID: 8303 RVA: 0x001DC539 File Offset: 0x001DA739
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002070 RID: 8304 RVA: 0x001DC550 File Offset: 0x001DA750
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046FF RID: 18175
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004700 RID: 18176
	public GameObject HitEffect;

	// Token: 0x04004701 RID: 18177
	public float Timer;
}
