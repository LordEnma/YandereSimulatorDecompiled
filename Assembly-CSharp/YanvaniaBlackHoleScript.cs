using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002080 RID: 8320 RVA: 0x001DD740 File Offset: 0x001DB940
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

	// Token: 0x04004717 RID: 18199
	public GameObject BlackHoleAttack;

	// Token: 0x04004718 RID: 18200
	public int Attacks;

	// Token: 0x04004719 RID: 18201
	public float SpawnTimer;

	// Token: 0x0400471A RID: 18202
	public float Timer;
}
