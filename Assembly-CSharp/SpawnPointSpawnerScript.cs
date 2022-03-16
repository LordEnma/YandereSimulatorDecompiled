using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CE8 RID: 7400 RVA: 0x00158E50 File Offset: 0x00157050
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

	// Token: 0x0400344D RID: 13389
	public Transform SpawnPointParent;

	// Token: 0x0400344E RID: 13390
	public GameObject SimpleGirl;

	// Token: 0x0400344F RID: 13391
	public GameObject SpawnPoint;

	// Token: 0x04003450 RID: 13392
	public int IterationsToWait = 3;

	// Token: 0x04003451 RID: 13393
	public int Direction = 1;

	// Token: 0x04003452 RID: 13394
	public int Column = -4;

	// Token: 0x04003453 RID: 13395
	public int Iterations;

	// Token: 0x04003454 RID: 13396
	public int Limit;

	// Token: 0x04003455 RID: 13397
	public int Row;

	// Token: 0x04003456 RID: 13398
	public int ID;

	// Token: 0x04003457 RID: 13399
	public bool SpawnGirl;
}
