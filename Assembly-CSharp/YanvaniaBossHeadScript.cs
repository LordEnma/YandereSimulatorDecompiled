using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002088 RID: 8328 RVA: 0x001DE1A9 File Offset: 0x001DC3A9
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x001DE1C0 File Offset: 0x001DC3C0
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x04004738 RID: 18232
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004739 RID: 18233
	public GameObject HitEffect;

	// Token: 0x0400473A RID: 18234
	public float Timer;
}
