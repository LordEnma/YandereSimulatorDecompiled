using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002057 RID: 8279 RVA: 0x001D9C90 File Offset: 0x001D7E90
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

	// Token: 0x040046C6 RID: 18118
	public GameObject BlackHoleAttack;

	// Token: 0x040046C7 RID: 18119
	public int Attacks;

	// Token: 0x040046C8 RID: 18120
	public float SpawnTimer;

	// Token: 0x040046C9 RID: 18121
	public float Timer;
}
