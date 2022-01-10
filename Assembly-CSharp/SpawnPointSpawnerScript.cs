using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CC4 RID: 7364 RVA: 0x00154E28 File Offset: 0x00153028
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

	// Token: 0x040033DD RID: 13277
	public Transform SpawnPointParent;

	// Token: 0x040033DE RID: 13278
	public GameObject SimpleGirl;

	// Token: 0x040033DF RID: 13279
	public GameObject SpawnPoint;

	// Token: 0x040033E0 RID: 13280
	public int IterationsToWait = 3;

	// Token: 0x040033E1 RID: 13281
	public int Direction = 1;

	// Token: 0x040033E2 RID: 13282
	public int Column = -4;

	// Token: 0x040033E3 RID: 13283
	public int Iterations;

	// Token: 0x040033E4 RID: 13284
	public int Limit;

	// Token: 0x040033E5 RID: 13285
	public int Row;

	// Token: 0x040033E6 RID: 13286
	public int ID;

	// Token: 0x040033E7 RID: 13287
	public bool SpawnGirl;
}
