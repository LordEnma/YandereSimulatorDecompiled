using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002070 RID: 8304 RVA: 0x001DC6AC File Offset: 0x001DA8AC
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

	// Token: 0x040046FE RID: 18174
	public GameObject BlackHoleAttack;

	// Token: 0x040046FF RID: 18175
	public int Attacks;

	// Token: 0x04004700 RID: 18176
	public float SpawnTimer;

	// Token: 0x04004701 RID: 18177
	public float Timer;
}
