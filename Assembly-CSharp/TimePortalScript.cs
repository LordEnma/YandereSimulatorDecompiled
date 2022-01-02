using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001E93 RID: 7827 RVA: 0x001AC880 File Offset: 0x001AAA80
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

	// Token: 0x04003F2F RID: 16175
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F30 RID: 16176
	public GameObject BlackHole;

	// Token: 0x04003F31 RID: 16177
	public float Timer;

	// Token: 0x04003F32 RID: 16178
	public bool Suck;

	// Token: 0x04003F33 RID: 16179
	public int ID;
}
