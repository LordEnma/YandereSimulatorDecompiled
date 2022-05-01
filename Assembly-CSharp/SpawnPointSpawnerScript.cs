using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D04 RID: 7428 RVA: 0x0015A918 File Offset: 0x00158B18
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

	// Token: 0x04003486 RID: 13446
	public Transform SpawnPointParent;

	// Token: 0x04003487 RID: 13447
	public GameObject SimpleGirl;

	// Token: 0x04003488 RID: 13448
	public GameObject SpawnPoint;

	// Token: 0x04003489 RID: 13449
	public int IterationsToWait = 3;

	// Token: 0x0400348A RID: 13450
	public int Direction = 1;

	// Token: 0x0400348B RID: 13451
	public int Column = -4;

	// Token: 0x0400348C RID: 13452
	public int Iterations;

	// Token: 0x0400348D RID: 13453
	public int Limit;

	// Token: 0x0400348E RID: 13454
	public int Row;

	// Token: 0x0400348F RID: 13455
	public int ID;

	// Token: 0x04003490 RID: 13456
	public bool SpawnGirl;
}
