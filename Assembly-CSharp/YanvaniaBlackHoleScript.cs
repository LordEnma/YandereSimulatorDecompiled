using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x060020B4 RID: 8372 RVA: 0x001E1DEC File Offset: 0x001DFFEC
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

	// Token: 0x040047C8 RID: 18376
	public GameObject BlackHoleAttack;

	// Token: 0x040047C9 RID: 18377
	public int Attacks;

	// Token: 0x040047CA RID: 18378
	public float SpawnTimer;

	// Token: 0x040047CB RID: 18379
	public float Timer;
}
