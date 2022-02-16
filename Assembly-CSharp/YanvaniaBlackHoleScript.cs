using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002077 RID: 8311 RVA: 0x001DCB60 File Offset: 0x001DAD60
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

	// Token: 0x04004707 RID: 18183
	public GameObject BlackHoleAttack;

	// Token: 0x04004708 RID: 18184
	public int Attacks;

	// Token: 0x04004709 RID: 18185
	public float SpawnTimer;

	// Token: 0x0400470A RID: 18186
	public float Timer;
}
