using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002046 RID: 8262 RVA: 0x001D855C File Offset: 0x001D675C
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

	// Token: 0x04004687 RID: 18055
	public GameObject BlackHoleAttack;

	// Token: 0x04004688 RID: 18056
	public int Attacks;

	// Token: 0x04004689 RID: 18057
	public float SpawnTimer;

	// Token: 0x0400468A RID: 18058
	public float Timer;
}
