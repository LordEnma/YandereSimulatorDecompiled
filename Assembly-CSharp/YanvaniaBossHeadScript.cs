using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBossHeadScript : MonoBehaviour
{
	// Token: 0x06002072 RID: 8306 RVA: 0x001DC73D File Offset: 0x001DA93D
	private void Update()
	{
		this.Timer -= Time.deltaTime;
	}

	// Token: 0x06002073 RID: 8307 RVA: 0x001DC754 File Offset: 0x001DA954
	private void OnTriggerEnter(Collider other)
	{
		if (this.Timer <= 0f && this.Dracula.NewTeleportEffect == null && other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, base.transform.position, Quaternion.identity);
			this.Timer = 1f;
			this.Dracula.TakeDamage();
		}
	}

	// Token: 0x04004702 RID: 18178
	public YanvaniaDraculaScript Dracula;

	// Token: 0x04004703 RID: 18179
	public GameObject HitEffect;

	// Token: 0x04004704 RID: 18180
	public float Timer;
}
