using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD9 RID: 7385 RVA: 0x001579C0 File Offset: 0x00155BC0
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

	// Token: 0x04003402 RID: 13314
	public Transform SpawnPointParent;

	// Token: 0x04003403 RID: 13315
	public GameObject SimpleGirl;

	// Token: 0x04003404 RID: 13316
	public GameObject SpawnPoint;

	// Token: 0x04003405 RID: 13317
	public int IterationsToWait = 3;

	// Token: 0x04003406 RID: 13318
	public int Direction = 1;

	// Token: 0x04003407 RID: 13319
	public int Column = -4;

	// Token: 0x04003408 RID: 13320
	public int Iterations;

	// Token: 0x04003409 RID: 13321
	public int Limit;

	// Token: 0x0400340A RID: 13322
	public int Row;

	// Token: 0x0400340B RID: 13323
	public int ID;

	// Token: 0x0400340C RID: 13324
	public bool SpawnGirl;
}
