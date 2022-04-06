using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B31BC File Offset: 0x001B13BC
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

	// Token: 0x04004006 RID: 16390
	public DelinquentScript[] Delinquent;

	// Token: 0x04004007 RID: 16391
	public GameObject BlackHole;

	// Token: 0x04004008 RID: 16392
	public float Timer;

	// Token: 0x04004009 RID: 16393
	public bool Suck;

	// Token: 0x0400400A RID: 16394
	public int ID;
}
