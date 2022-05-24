using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020D0 RID: 8400 RVA: 0x001E5988 File Offset: 0x001E3B88
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

	// Token: 0x04004820 RID: 18464
	public GameObject BlackHoleAttack;

	// Token: 0x04004821 RID: 18465
	public int Attacks;

	// Token: 0x04004822 RID: 18466
	public float SpawnTimer;

	// Token: 0x04004823 RID: 18467
	public float Timer;
}
