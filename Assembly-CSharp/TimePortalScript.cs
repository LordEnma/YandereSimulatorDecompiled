using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EEC RID: 7916 RVA: 0x001B4F04 File Offset: 0x001B3104
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

	// Token: 0x0400402C RID: 16428
	public DelinquentScript[] Delinquent;

	// Token: 0x0400402D RID: 16429
	public GameObject BlackHole;

	// Token: 0x0400402E RID: 16430
	public float Timer;

	// Token: 0x0400402F RID: 16431
	public bool Suck;

	// Token: 0x04004030 RID: 16432
	public int ID;
}
