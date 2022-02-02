using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020BB RID: 8379 RVA: 0x001E2A3C File Offset: 0x001E0C3C
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

	// Token: 0x04004827 RID: 18471
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x04004828 RID: 18472
	public GameObject Zombie;

	// Token: 0x04004829 RID: 18473
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400482A RID: 18474
	public float SpawnTimer;

	// Token: 0x0400482B RID: 18475
	public float RelativePoint;

	// Token: 0x0400482C RID: 18476
	public float RightBoundary;

	// Token: 0x0400482D RID: 18477
	public float LeftBoundary;

	// Token: 0x0400482E RID: 18478
	public int SpawnSide;

	// Token: 0x0400482F RID: 18479
	public int ID;

	// Token: 0x04004830 RID: 18480
	public GameObject[] Zombies;

	// Token: 0x04004831 RID: 18481
	public Vector3[] SpawnPoints;
}
