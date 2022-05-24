using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x060020D2 RID: 8402 RVA: 0x001E5A19 File Offset: 0x001E3C19
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x001E5A30 File Offset: 0x001E3C30
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x04004824 RID: 18468
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004825 RID: 18469
	public GameObject HitEffect;

	// Token: 0x04004826 RID: 18470
	public float Timer;
}
