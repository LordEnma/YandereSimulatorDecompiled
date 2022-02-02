using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x0600206D RID: 8301 RVA: 0x001DC221 File Offset: 0x001DA421
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x001DC238 File Offset: 0x001DA438
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046F9 RID: 18169
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046FA RID: 18170
	public GameObject HitEffect;

	// Token: 0x040046FB RID: 18171
	public float Timer;
}
