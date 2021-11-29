using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CB3 RID: 7347 RVA: 0x00153DBC File Offset: 0x00151FBC
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

	// Token: 0x040033A5 RID: 13221
	public Transform SpawnPointParent;

	// Token: 0x040033A6 RID: 13222
	public GameObject SimpleGirl;

	// Token: 0x040033A7 RID: 13223
	public GameObject SpawnPoint;

	// Token: 0x040033A8 RID: 13224
	public int IterationsToWait = 3;

	// Token: 0x040033A9 RID: 13225
	public int Direction = 1;

	// Token: 0x040033AA RID: 13226
	public int Column = -4;

	// Token: 0x040033AB RID: 13227
	public int Iterations;

	// Token: 0x040033AC RID: 13228
	public int Limit;

	// Token: 0x040033AD RID: 13229
	public int Row;

	// Token: 0x040033AE RID: 13230
	public int ID;

	// Token: 0x040033AF RID: 13231
	public bool SpawnGirl;
}
