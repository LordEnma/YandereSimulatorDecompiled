using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020C4 RID: 8388 RVA: 0x001E3CD4 File Offset: 0x001E1ED4
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

	// Token: 0x040047F0 RID: 18416
	public GameObject BlackHoleAttack;

	// Token: 0x040047F1 RID: 18417
	public int Attacks;

	// Token: 0x040047F2 RID: 18418
	public float SpawnTimer;

	// Token: 0x040047F3 RID: 18419
	public float Timer;
}
