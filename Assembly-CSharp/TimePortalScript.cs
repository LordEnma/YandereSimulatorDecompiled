using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001E91 RID: 7825 RVA: 0x001AC3CC File Offset: 0x001AA5CC
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

	// Token: 0x04003F28 RID: 16168
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F29 RID: 16169
	public GameObject BlackHole;

	// Token: 0x04003F2A RID: 16170
	public float Timer;

	// Token: 0x04003F2B RID: 16171
	public bool Suck;

	// Token: 0x04003F2C RID: 16172
	public int ID;
}
