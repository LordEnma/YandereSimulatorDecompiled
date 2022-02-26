using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EB6 RID: 7862 RVA: 0x001AF8C8 File Offset: 0x001ADAC8
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

	// Token: 0x04003F74 RID: 16244
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F75 RID: 16245
	public GameObject BlackHole;

	// Token: 0x04003F76 RID: 16246
	public float Timer;

	// Token: 0x04003F77 RID: 16247
	public bool Suck;

	// Token: 0x04003F78 RID: 16248
	public int ID;
}
