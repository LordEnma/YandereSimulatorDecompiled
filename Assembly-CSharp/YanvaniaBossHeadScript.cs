using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020AE RID: 8366 RVA: 0x001E194D File Offset: 0x001DFB4D
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020AF RID: 8367 RVA: 0x001E1964 File Offset: 0x001DFB64
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040047C8 RID: 18376
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047C9 RID: 18377
	public GameObject HitEffect;

	// Token: 0x040047CA RID: 18378
	public float Timer;
}
