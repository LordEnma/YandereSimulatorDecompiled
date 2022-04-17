using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B3B94 File Offset: 0x001B1D94
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

	// Token: 0x04004016 RID: 16406
	public DelinquentScript[] Delinquent;

	// Token: 0x04004017 RID: 16407
	public GameObject BlackHole;

	// Token: 0x04004018 RID: 16408
	public float Timer;

	// Token: 0x04004019 RID: 16409
	public bool Suck;

	// Token: 0x0400401A RID: 16410
	public int ID;
}
