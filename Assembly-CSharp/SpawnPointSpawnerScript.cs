using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CFD RID: 7421 RVA: 0x0015A0DC File Offset: 0x001582DC
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

	// Token: 0x04003477 RID: 13431
	public Transform SpawnPointParent;

	// Token: 0x04003478 RID: 13432
	public GameObject SimpleGirl;

	// Token: 0x04003479 RID: 13433
	public GameObject SpawnPoint;

	// Token: 0x0400347A RID: 13434
	public int IterationsToWait = 3;

	// Token: 0x0400347B RID: 13435
	public int Direction = 1;

	// Token: 0x0400347C RID: 13436
	public int Column = -4;

	// Token: 0x0400347D RID: 13437
	public int Iterations;

	// Token: 0x0400347E RID: 13438
	public int Limit;

	// Token: 0x0400347F RID: 13439
	public int Row;

	// Token: 0x04003480 RID: 13440
	public int ID;

	// Token: 0x04003481 RID: 13441
	public bool SpawnGirl;
}
