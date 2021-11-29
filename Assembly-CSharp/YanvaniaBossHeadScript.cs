using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002048 RID: 8264 RVA: 0x001D85ED File Offset: 0x001D67ED
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002049 RID: 8265 RVA: 0x001D8604 File Offset: 0x001D6804
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x0400468B RID: 18059
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400468C RID: 18060
	public GameObject HitEffect;

	// Token: 0x0400468D RID: 18061
	public float Timer;
}
