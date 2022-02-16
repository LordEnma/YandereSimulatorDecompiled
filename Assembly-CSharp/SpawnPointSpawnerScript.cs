using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD0 RID: 7376 RVA: 0x00156F14 File Offset: 0x00155114
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

	// Token: 0x040033F2 RID: 13298
	public Transform SpawnPointParent;

	// Token: 0x040033F3 RID: 13299
	public GameObject SimpleGirl;

	// Token: 0x040033F4 RID: 13300
	public GameObject SpawnPoint;

	// Token: 0x040033F5 RID: 13301
	public int IterationsToWait = 3;

	// Token: 0x040033F6 RID: 13302
	public int Direction = 1;

	// Token: 0x040033F7 RID: 13303
	public int Column = -4;

	// Token: 0x040033F8 RID: 13304
	public int Iterations;

	// Token: 0x040033F9 RID: 13305
	public int Limit;

	// Token: 0x040033FA RID: 13306
	public int Row;

	// Token: 0x040033FB RID: 13307
	public int ID;

	// Token: 0x040033FC RID: 13308
	public bool SpawnGirl;
}
