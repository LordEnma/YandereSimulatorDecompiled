using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020B6 RID: 8374 RVA: 0x001E1E7D File Offset: 0x001E007D
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020B7 RID: 8375 RVA: 0x001E1E94 File Offset: 0x001E0094
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x040047CC RID: 18380
	public YanvaniaDraculaScript Dracula;

	// Token: 0x040047CD RID: 18381
	public GameObject HitEffect;

	// Token: 0x040047CE RID: 18382
	public float Timer;
}
