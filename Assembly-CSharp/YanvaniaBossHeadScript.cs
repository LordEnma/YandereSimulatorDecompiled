using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x0600205C RID: 8284 RVA: 0x001DA311 File Offset: 0x001D8511
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x0600205D RID: 8285 RVA: 0x001DA328 File Offset: 0x001D8528
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046D3 RID: 18131
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046D4 RID: 18132
	public GameObject HitEffect;

	// Token: 0x040046D5 RID: 18133
	public float Timer;
}
