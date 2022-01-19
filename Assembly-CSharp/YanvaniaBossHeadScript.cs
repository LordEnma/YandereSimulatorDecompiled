using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002069 RID: 8297 RVA: 0x001DB981 File Offset: 0x001D9B81
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x001DB998 File Offset: 0x001D9B98
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046EE RID: 18158
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046EF RID: 18159
	public GameObject HitEffect;

	// Token: 0x040046F0 RID: 18160
	public float Timer;
}
