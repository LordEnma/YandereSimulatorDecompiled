using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x0600206D RID: 8301 RVA: 0x001DC4A8 File Offset: 0x001DA6A8
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

	// Token: 0x040046FB RID: 18171
	public GameObject BlackHoleAttack;

	// Token: 0x040046FC RID: 18172
	public int Attacks;

	// Token: 0x040046FD RID: 18173
	public float SpawnTimer;

	// Token: 0x040046FE RID: 18174
	public float Timer;
}
