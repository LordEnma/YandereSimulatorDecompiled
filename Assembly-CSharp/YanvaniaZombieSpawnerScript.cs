using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020C0 RID: 8384 RVA: 0x001E2F58 File Offset: 0x001E1158
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

	// Token: 0x04004830 RID: 18480
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x04004831 RID: 18481
	public GameObject Zombie;

	// Token: 0x04004832 RID: 18482
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004833 RID: 18483
	public float SpawnTimer;

	// Token: 0x04004834 RID: 18484
	public float RelativePoint;

	// Token: 0x04004835 RID: 18485
	public float RightBoundary;

	// Token: 0x04004836 RID: 18486
	public float LeftBoundary;

	// Token: 0x04004837 RID: 18487
	public int SpawnSide;

	// Token: 0x04004838 RID: 18488
	public int ID;

	// Token: 0x04004839 RID: 18489
	public GameObject[] Zombies;

	// Token: 0x0400483A RID: 18490
	public Vector3[] SpawnPoints;
}
