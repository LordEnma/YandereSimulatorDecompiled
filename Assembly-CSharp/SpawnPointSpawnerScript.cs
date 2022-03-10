using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CDB RID: 7387 RVA: 0x00157F44 File Offset: 0x00156144
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

	// Token: 0x04003418 RID: 13336
	public Transform SpawnPointParent;

	// Token: 0x04003419 RID: 13337
	public GameObject SimpleGirl;

	// Token: 0x0400341A RID: 13338
	public GameObject SpawnPoint;

	// Token: 0x0400341B RID: 13339
	public int IterationsToWait = 3;

	// Token: 0x0400341C RID: 13340
	public int Direction = 1;

	// Token: 0x0400341D RID: 13341
	public int Column = -4;

	// Token: 0x0400341E RID: 13342
	public int Iterations;

	// Token: 0x0400341F RID: 13343
	public int Limit;

	// Token: 0x04003420 RID: 13344
	public int Row;

	// Token: 0x04003421 RID: 13345
	public int ID;

	// Token: 0x04003422 RID: 13346
	public bool SpawnGirl;
}
