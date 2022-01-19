using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002067 RID: 8295 RVA: 0x001DB8F0 File Offset: 0x001D9AF0
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

	// Token: 0x040046EA RID: 18154
	public GameObject BlackHoleAttack;

	// Token: 0x040046EB RID: 18155
	public int Attacks;

	// Token: 0x040046EC RID: 18156
	public float SpawnTimer;

	// Token: 0x040046ED RID: 18157
	public float Timer;
}
