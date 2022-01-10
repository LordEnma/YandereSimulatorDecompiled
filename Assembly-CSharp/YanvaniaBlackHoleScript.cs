using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002065 RID: 8293 RVA: 0x001DAC20 File Offset: 0x001D8E20
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

	// Token: 0x040046E3 RID: 18147
	public GameObject BlackHoleAttack;

	// Token: 0x040046E4 RID: 18148
	public int Attacks;

	// Token: 0x040046E5 RID: 18149
	public float SpawnTimer;

	// Token: 0x040046E6 RID: 18150
	public float Timer;
}
