using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EA0 RID: 7840 RVA: 0x001ADED0 File Offset: 0x001AC0D0
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

	// Token: 0x04003F4A RID: 16202
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F4B RID: 16203
	public GameObject BlackHole;

	// Token: 0x04003F4C RID: 16204
	public float Timer;

	// Token: 0x04003F4D RID: 16205
	public bool Suck;

	// Token: 0x04003F4E RID: 16206
	public int ID;
}
