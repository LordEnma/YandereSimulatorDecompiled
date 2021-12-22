using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002059 RID: 8281 RVA: 0x001D9D21 File Offset: 0x001D7F21
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x0600205A RID: 8282 RVA: 0x001D9D38 File Offset: 0x001D7F38
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046CA RID: 18122
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046CB RID: 18123
	public GameObject HitEffect;

	// Token: 0x040046CC RID: 18124
	public float Timer;
}
