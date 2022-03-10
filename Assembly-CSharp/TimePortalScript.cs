using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AFFF0 File Offset: 0x001AE1F0
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

	// Token: 0x04003F8B RID: 16267
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F8C RID: 16268
	public GameObject BlackHole;

	// Token: 0x04003F8D RID: 16269
	public float Timer;

	// Token: 0x04003F8E RID: 16270
	public bool Suck;

	// Token: 0x04003F8F RID: 16271
	public int ID;
}
