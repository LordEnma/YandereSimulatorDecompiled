using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020BD RID: 8381 RVA: 0x001E28D9 File Offset: 0x001E0AD9
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020BE RID: 8382 RVA: 0x001E28F0 File Offset: 0x001E0AF0
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040047DE RID: 18398
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047DF RID: 18399
	public GameObject HitEffect;

	// Token: 0x040047E0 RID: 18400
	public float Timer;
}
