using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020BB RID: 8379 RVA: 0x001E2848 File Offset: 0x001E0A48
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

	// Token: 0x040047DA RID: 18394
	public GameObject BlackHoleAttack;

	// Token: 0x040047DB RID: 18395
	public int Attacks;

	// Token: 0x040047DC RID: 18396
	public float SpawnTimer;

	// Token: 0x040047DD RID: 18397
	public float Timer;
}
