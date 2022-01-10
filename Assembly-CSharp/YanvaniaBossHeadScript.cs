using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002067 RID: 8295 RVA: 0x001DACB1 File Offset: 0x001D8EB1
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002068 RID: 8296 RVA: 0x001DACC8 File Offset: 0x001D8EC8
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040046E7 RID: 18151
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040046E8 RID: 18152
	public GameObject HitEffect;

	// Token: 0x040046E9 RID: 18153
	public float Timer;
}
