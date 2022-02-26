using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002082 RID: 8322 RVA: 0x001DD7D1 File Offset: 0x001DB9D1
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x001DD7E8 File Offset: 0x001DB9E8
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x0400471B RID: 18203
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400471C RID: 18204
	public GameObject HitEffect;

	// Token: 0x0400471D RID: 18205
	public float Timer;
}
