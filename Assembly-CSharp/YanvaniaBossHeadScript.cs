using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020A0 RID: 8352 RVA: 0x001E0111 File Offset: 0x001DE311
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x001E0128 File Offset: 0x001DE328
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x04004797 RID: 18327
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004798 RID: 18328
	public GameObject HitEffect;

	// Token: 0x04004799 RID: 18329
	public float Timer;
}
