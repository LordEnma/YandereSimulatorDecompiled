using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020B7 RID: 8375 RVA: 0x001E219C File Offset: 0x001E039C
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

	// Token: 0x0400481C RID: 18460
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x0400481D RID: 18461
	public GameObject Zombie;

	// Token: 0x0400481E RID: 18462
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400481F RID: 18463
	public float SpawnTimer;

	// Token: 0x04004820 RID: 18464
	public float RelativePoint;

	// Token: 0x04004821 RID: 18465
	public float RightBoundary;

	// Token: 0x04004822 RID: 18466
	public float LeftBoundary;

	// Token: 0x04004823 RID: 18467
	public int SpawnSide;

	// Token: 0x04004824 RID: 18468
	public int ID;

	// Token: 0x04004825 RID: 18469
	public GameObject[] Zombies;

	// Token: 0x04004826 RID: 18470
	public Vector3[] SpawnPoints;
}
