using System;
using UnityEngine;

// Token: 0x020004E1 RID: 1249
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x06002096 RID: 8342 RVA: 0x001DEE08 File Offset: 0x001DD008
	private void Update()
	{
		if (this.Yanmont.transform.position.y > 0f)
		{
			this.ID = 0;
			this.SpawnTimer += Time.deltaTime;
			if (this.SpawnTimer > 1f)
			{
				while (this.ID < 4)
				{
					if (this.Zombies[this.ID] == null)
					{
						this.SpawnSide = UnityEngine.Random.Range(1, 3);
						if (this.Yanmont.transform.position.x < this.LeftBoundary + 5f)
						{
							this.SpawnSide = 2;
						}
						if (this.Yanmont.transform.position.x > this.RightBoundary - 5f)
						{
							this.SpawnSide = 1;
						}
						if (this.Yanmont.transform.position.x < this.LeftBoundary)
						{
							this.RelativePoint = this.LeftBoundary;
						}
						else if (this.Yanmont.transform.position.x > this.RightBoundary)
						{
							this.RelativePoint = this.RightBoundary;
						}
						else
						{
							this.RelativePoint = this.Yanmont.transform.position.x;
						}
						if (this.SpawnSide == 1)
						{
							this.SpawnPoints[0].x = this.RelativePoint - 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint - 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint - 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint - 5.5f;
						}
						else
						{
							this.SpawnPoints[0].x = this.RelativePoint + 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint + 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint + 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint + 5.5f;
						}
						this.Zombies[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.Zombie, this.SpawnPoints[this.ID], Quaternion.identity);
						this.NewZombieScript = this.Zombies[this.ID].GetComponent<YanvaniaZombieScript>();
						this.NewZombieScript.LeftBoundary = this.LeftBoundary;
						this.NewZombieScript.RightBoundary = this.RightBoundary;
						this.NewZombieScript.Yanmont = this.Yanmont;
						break;
					}
					this.ID++;
				}
				this.SpawnTimer = 0f;
			}
		}
	}

	// Token: 0x040047B9 RID: 18361
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x040047BA RID: 18362
	public GameObject Zombie;

	// Token: 0x040047BB RID: 18363
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047BC RID: 18364
	public float SpawnTimer;

	// Token: 0x040047BD RID: 18365
	public float RelativePoint;

	// Token: 0x040047BE RID: 18366
	public float RightBoundary;

	// Token: 0x040047BF RID: 18367
	public float LeftBoundary;

	// Token: 0x040047C0 RID: 18368
	public int SpawnSide;

	// Token: 0x040047C1 RID: 18369
	public int ID;

	// Token: 0x040047C2 RID: 18370
	public GameObject[] Zombies;

	// Token: 0x040047C3 RID: 18371
	public Vector3[] SpawnPoints;
}
