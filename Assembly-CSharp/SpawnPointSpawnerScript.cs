using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CF2 RID: 7410 RVA: 0x001599AC File Offset: 0x00157BAC
	private void Start()
	{
		while (this.ID < this.Limit)
		{
			if (this.Iterations == 0)
			{
				GameObject gameObject;
				if (this.SpawnGirl)
				{
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SimpleGirl, new Vector3((float)this.Column, 0f, (float)this.Row), Quaternion.identity);
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SpawnPoint, new Vector3((float)this.Column, 0f, (float)this.Row), Quaternion.identity);
				}
				gameObject.transform.parent = this.SpawnPointParent;
				this.Iterations += this.IterationsToWait;
				this.Row--;
				this.ID++;
				gameObject.name = "SpawnPoint_" + this.ID.ToString();
			}
			this.Column += this.Direction;
			if (this.Column > 4 || this.Column < -4)
			{
				this.Direction *= -1;
			}
			if (this.Column > 4)
			{
				this.Column -= 2;
			}
			if (this.Column < -4)
			{
				this.Column += 2;
			}
			if (this.Column == 0)
			{
				this.Column += this.Direction;
			}
			this.Iterations--;
		}
	}

	// Token: 0x04003469 RID: 13417
	public Transform SpawnPointParent;

	// Token: 0x0400346A RID: 13418
	public GameObject SimpleGirl;

	// Token: 0x0400346B RID: 13419
	public GameObject SpawnPoint;

	// Token: 0x0400346C RID: 13420
	public int IterationsToWait = 3;

	// Token: 0x0400346D RID: 13421
	public int Direction = 1;

	// Token: 0x0400346E RID: 13422
	public int Column = -4;

	// Token: 0x0400346F RID: 13423
	public int Iterations;

	// Token: 0x04003470 RID: 13424
	public int Limit;

	// Token: 0x04003471 RID: 13425
	public int Row;

	// Token: 0x04003472 RID: 13426
	public int ID;

	// Token: 0x04003473 RID: 13427
	public bool SpawnGirl;
}
