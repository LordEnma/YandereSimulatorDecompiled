using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B6178 File Offset: 0x001B4378
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

	// Token: 0x0400404A RID: 16458
	public DelinquentScript[] Delinquent;

	// Token: 0x0400404B RID: 16459
	public GameObject BlackHole;

	// Token: 0x0400404C RID: 16460
	public float Timer;

	// Token: 0x0400404D RID: 16461
	public bool Suck;

	// Token: 0x0400404E RID: 16462
	public int ID;
}
