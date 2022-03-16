using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E692C File Offset: 0x001E4B2C
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

	// Token: 0x040048C5 RID: 18629
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x040048C6 RID: 18630
	public GameObject Zombie;

	// Token: 0x040048C7 RID: 18631
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040048C8 RID: 18632
	public float SpawnTimer;

	// Token: 0x040048C9 RID: 18633
	public float RelativePoint;

	// Token: 0x040048CA RID: 18634
	public float RightBoundary;

	// Token: 0x040048CB RID: 18635
	public float LeftBoundary;

	// Token: 0x040048CC RID: 18636
	public int SpawnSide;

	// Token: 0x040048CD RID: 18637
	public int ID;

	// Token: 0x040048CE RID: 18638
	public GameObject[] Zombies;

	// Token: 0x040048CF RID: 18639
	public Vector3[] SpawnPoints;
}
