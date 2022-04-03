using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020AC RID: 8364 RVA: 0x001E18BC File Offset: 0x001DFABC
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

	// Token: 0x040047C4 RID: 18372
	public GameObject BlackHoleAttack;

	// Token: 0x040047C5 RID: 18373
	public int Attacks;

	// Token: 0x040047C6 RID: 18374
	public float SpawnTimer;

	// Token: 0x040047C7 RID: 18375
	public float Timer;
}
