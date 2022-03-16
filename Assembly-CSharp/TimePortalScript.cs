using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TimePortalScript : MonoBehaviour
{
	// Token: 0x06001ECB RID: 7883 RVA: 0x001B1740 File Offset: 0x001AF940
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

	// Token: 0x04003FD6 RID: 16342
	public DelinquentScript[] Delinquent;

	// Token: 0x04003FD7 RID: 16343
	public GameObject BlackHole;

	// Token: 0x04003FD8 RID: 16344
	public float Timer;

	// Token: 0x04003FD9 RID: 16345
	public bool Suck;

	// Token: 0x04003FDA RID: 16346
	public int ID;
}
