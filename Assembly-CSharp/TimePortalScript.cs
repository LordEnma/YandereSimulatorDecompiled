using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EA3 RID: 7843 RVA: 0x001AE6B4 File Offset: 0x001AC8B4
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

	// Token: 0x04003F58 RID: 16216
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F59 RID: 16217
	public GameObject BlackHole;

	// Token: 0x04003F5A RID: 16218
	public float Timer;

	// Token: 0x04003F5B RID: 16219
	public bool Suck;

	// Token: 0x04003F5C RID: 16220
	public int ID;
}
