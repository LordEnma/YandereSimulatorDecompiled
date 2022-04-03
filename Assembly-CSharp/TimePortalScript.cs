using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B2CB4 File Offset: 0x001B0EB4
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

	// Token: 0x04004003 RID: 16387
	public DelinquentScript[] Delinquent;

	// Token: 0x04004004 RID: 16388
	public GameObject BlackHole;

	// Token: 0x04004005 RID: 16389
	public float Timer;

	// Token: 0x04004006 RID: 16390
	public bool Suck;

	// Token: 0x04004007 RID: 16391
	public int ID;
}
