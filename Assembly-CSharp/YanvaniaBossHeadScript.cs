using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002079 RID: 8313 RVA: 0x001DCBF1 File Offset: 0x001DADF1
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x0600207A RID: 8314 RVA: 0x001DCC08 File Offset: 0x001DAE08
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x0400470B RID: 18187
	public YanvaniaDraculaScript Dracula;

	// Token: 0x0400470C RID: 18188
	public GameObject HitEffect;

	// Token: 0x0400470D RID: 18189
	public float Timer;
}
