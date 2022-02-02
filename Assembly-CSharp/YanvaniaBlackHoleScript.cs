using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBlackHoleScript : MonoBehaviour
{
	// Token: 0x0600206B RID: 8299 RVA: 0x001DC190 File Offset: 0x001DA390
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

	// Token: 0x040046F5 RID: 18165
	public GameObject BlackHoleAttack;

	// Token: 0x040046F6 RID: 18166
	public int Attacks;

	// Token: 0x040046F7 RID: 18167
	public float SpawnTimer;

	// Token: 0x040046F8 RID: 18168
	public float Timer;
}
