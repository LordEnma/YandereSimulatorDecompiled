using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020C6 RID: 8390 RVA: 0x001E3D65 File Offset: 0x001E1F65
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020C7 RID: 8391 RVA: 0x001E3D7C File Offset: 0x001E1F7C
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040047F4 RID: 18420
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047F5 RID: 18421
	public GameObject HitEffect;

	// Token: 0x040047F6 RID: 18422
	public float Timer;
}
