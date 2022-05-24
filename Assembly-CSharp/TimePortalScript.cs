using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B6608 File Offset: 0x001B4808
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Suck = true;
		}
		if (this.Suck)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.BlackHole, base.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1.1f)
			{
				this.Delinquent[this.ID].Suck = true;
				this.Timer = 1f;
				this.ID++;
				if (this.ID > 9)
				{
					base.enabled = false;
				}
			}
		}
	}

	// Token: 0x04004053 RID: 16467
	public DelinquentScript[] Delinquent;

	// Token: 0x04004054 RID: 16468
	public GameObject BlackHole;

	// Token: 0x04004055 RID: 16469
	public float Timer;

	// Token: 0x04004056 RID: 16470
	public bool Suck;

	// Token: 0x04004057 RID: 16471
	public int ID;
}
