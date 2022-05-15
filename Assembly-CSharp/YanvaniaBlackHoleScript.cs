using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020CF RID: 8399 RVA: 0x001E5420 File Offset: 0x001E3620
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f)
		{
			this.SpawnTimer -= Time.deltaTime;
			if (this.SpawnTimer <= 0f && this.Attacks < 5)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BlackHoleAttack, base.transform.position, Quaternion.identity);
				this.SpawnTimer = 0.5f;
				this.Attacks++;
			}
		}
	}

	// Token: 0x04004817 RID: 18455
	public GameObject BlackHoleAttack;

	// Token: 0x04004818 RID: 18456
	public int Attacks;

	// Token: 0x04004819 RID: 18457
	public float SpawnTimer;

	// Token: 0x0400481A RID: 18458
	public float Timer;
}
