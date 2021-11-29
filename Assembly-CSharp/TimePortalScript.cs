using System;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x001AB640 File Offset: 0x001A9840
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

	// Token: 0x04003EF8 RID: 16120
	public DelinquentScript[] Delinquent;

	// Token: 0x04003EF9 RID: 16121
	public GameObject BlackHole;

	// Token: 0x04003EFA RID: 16122
	public float Timer;

	// Token: 0x04003EFB RID: 16123
	public bool Suck;

	// Token: 0x04003EFC RID: 16124
	public int ID;
}
