using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CC6 RID: 7366 RVA: 0x0015653C File Offset: 0x0015473C
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

	// Token: 0x040033E2 RID: 13282
	public Transform SpawnPointParent;

	// Token: 0x040033E3 RID: 13283
	public GameObject SimpleGirl;

	// Token: 0x040033E4 RID: 13284
	public GameObject SpawnPoint;

	// Token: 0x040033E5 RID: 13285
	public int IterationsToWait = 3;

	// Token: 0x040033E6 RID: 13286
	public int Direction = 1;

	// Token: 0x040033E7 RID: 13287
	public int Column = -4;

	// Token: 0x040033E8 RID: 13288
	public int Iterations;

	// Token: 0x040033E9 RID: 13289
	public int Limit;

	// Token: 0x040033EA RID: 13290
	public int Row;

	// Token: 0x040033EB RID: 13291
	public int ID;

	// Token: 0x040033EC RID: 13292
	public bool SpawnGirl;
}
