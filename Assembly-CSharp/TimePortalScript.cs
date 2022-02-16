using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001AED8C File Offset: 0x001ACF8C
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

	// Token: 0x04003F64 RID: 16228
	public DelinquentScript[] Delinquent;

	// Token: 0x04003F65 RID: 16229
	public GameObject BlackHole;

	// Token: 0x04003F66 RID: 16230
	public float Timer;

	// Token: 0x04003F67 RID: 16231
	public bool Suck;

	// Token: 0x04003F68 RID: 16232
	public int ID;
}
