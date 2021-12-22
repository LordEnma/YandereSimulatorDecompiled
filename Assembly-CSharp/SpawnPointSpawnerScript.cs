using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CBB RID: 7355 RVA: 0x001546E0 File Offset: 0x001528E0
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

	// Token: 0x040033D0 RID: 13264
	public Transform SpawnPointParent;

	// Token: 0x040033D1 RID: 13265
	public GameObject SimpleGirl;

	// Token: 0x040033D2 RID: 13266
	public GameObject SpawnPoint;

	// Token: 0x040033D3 RID: 13267
	public int IterationsToWait = 3;

	// Token: 0x040033D4 RID: 13268
	public int Direction = 1;

	// Token: 0x040033D5 RID: 13269
	public int Column = -4;

	// Token: 0x040033D6 RID: 13270
	public int Iterations;

	// Token: 0x040033D7 RID: 13271
	public int Limit;

	// Token: 0x040033D8 RID: 13272
	public int Row;

	// Token: 0x040033D9 RID: 13273
	public int ID;

	// Token: 0x040033DA RID: 13274
	public bool SpawnGirl;
}
