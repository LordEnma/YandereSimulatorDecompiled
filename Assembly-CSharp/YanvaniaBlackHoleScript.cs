using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x0600209E RID: 8350 RVA: 0x001E0080 File Offset: 0x001DE280
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

	// Token: 0x04004793 RID: 18323
	public GameObject BlackHoleAttack;

	// Token: 0x04004794 RID: 18324
	public int Attacks;

	// Token: 0x04004795 RID: 18325
	public float SpawnTimer;

	// Token: 0x04004796 RID: 18326
	public float Timer;
}
