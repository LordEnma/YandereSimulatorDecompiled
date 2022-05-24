using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D0B RID: 7435 RVA: 0x0015B854 File Offset: 0x00159A54
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

	// Token: 0x040034A3 RID: 13475
	public Transform SpawnPointParent;

	// Token: 0x040034A4 RID: 13476
	public GameObject SimpleGirl;

	// Token: 0x040034A5 RID: 13477
	public GameObject SpawnPoint;

	// Token: 0x040034A6 RID: 13478
	public int IterationsToWait = 3;

	// Token: 0x040034A7 RID: 13479
	public int Direction = 1;

	// Token: 0x040034A8 RID: 13480
	public int Column = -4;

	// Token: 0x040034A9 RID: 13481
	public int Iterations;

	// Token: 0x040034AA RID: 13482
	public int Limit;

	// Token: 0x040034AB RID: 13483
	public int Row;

	// Token: 0x040034AC RID: 13484
	public int ID;

	// Token: 0x040034AD RID: 13485
	public bool SpawnGirl;
}
