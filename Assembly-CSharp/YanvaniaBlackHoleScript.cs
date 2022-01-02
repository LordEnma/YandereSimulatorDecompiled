using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x0600205A RID: 8282 RVA: 0x001DA280 File Offset: 0x001D8480
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

	// Token: 0x040046CF RID: 18127
	public GameObject BlackHoleAttack;

	// Token: 0x040046D0 RID: 18128
	public int Attacks;

	// Token: 0x040046D1 RID: 18129
	public float SpawnTimer;

	// Token: 0x040046D2 RID: 18130
	public float Timer;
}
