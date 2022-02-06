using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AE8D4 File Offset: 0x001ACAD4
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

	// Token: 0x04003F5B RID: 16219
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F5C RID: 16220
	public GameObject BlackHole;

	// Token: 0x04003F5D RID: 16221
	public float Timer;

	// Token: 0x04003F5E RID: 16222
	public bool Suck;

	// Token: 0x04003F5F RID: 16223
	public int ID;
}
