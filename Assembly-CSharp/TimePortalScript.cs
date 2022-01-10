using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001E9E RID: 7838 RVA: 0x001AD200 File Offset: 0x001AB400
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

	// Token: 0x04003F43 RID: 16195
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F44 RID: 16196
	public GameObject BlackHole;

	// Token: 0x04003F45 RID: 16197
	public float Timer;

	// Token: 0x04003F46 RID: 16198
	public bool Suck;

	// Token: 0x04003F47 RID: 16199
	public int ID;
}
