using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020A7 RID: 8359 RVA: 0x001E053C File Offset: 0x001DE73C
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

	// Token: 0x040047F8 RID: 18424
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x040047F9 RID: 18425
	public GameObject Zombie;

	// Token: 0x040047FA RID: 18426
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047FB RID: 18427
	public float SpawnTimer;

	// Token: 0x040047FC RID: 18428
	public float RelativePoint;

	// Token: 0x040047FD RID: 18429
	public float RightBoundary;

	// Token: 0x040047FE RID: 18430
	public float LeftBoundary;

	// Token: 0x040047FF RID: 18431
	public int SpawnSide;

	// Token: 0x04004800 RID: 18432
	public int ID;

	// Token: 0x04004801 RID: 18433
	public GameObject[] Zombies;

	// Token: 0x04004802 RID: 18434
	public Vector3[] SpawnPoints;
}
