using System;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x06002086 RID: 8326 RVA: 0x001DE118 File Offset: 0x001DC318
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

	// Token: 0x04004734 RID: 18228
	public GameObject BlackHoleAttack;

	// Token: 0x04004735 RID: 18229
	public int Attacks;

	// Token: 0x04004736 RID: 18230
	public float SpawnTimer;

	// Token: 0x04004737 RID: 18231
	public float Timer;
}
