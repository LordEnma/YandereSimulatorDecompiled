using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EA1 RID: 7841 RVA: 0x001AE3A8 File Offset: 0x001AC5A8
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

	// Token: 0x04003F52 RID: 16210
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F53 RID: 16211
	public GameObject BlackHole;

	// Token: 0x04003F54 RID: 16212
	public float Timer;

	// Token: 0x04003F55 RID: 16213
	public bool Suck;

	// Token: 0x04003F56 RID: 16214
	public int ID;
}
