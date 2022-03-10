using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020D6 RID: 8406 RVA: 0x001E49C4 File Offset: 0x001E2BC4
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

	// Token: 0x04004866 RID: 18534
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x04004867 RID: 18535
	public GameObject Zombie;

	// Token: 0x04004868 RID: 18536
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004869 RID: 18537
	public float SpawnTimer;

	// Token: 0x0400486A RID: 18538
	public float RelativePoint;

	// Token: 0x0400486B RID: 18539
	public float RightBoundary;

	// Token: 0x0400486C RID: 18540
	public float LeftBoundary;

	// Token: 0x0400486D RID: 18541
	public int SpawnSide;

	// Token: 0x0400486E RID: 18542
	public int ID;

	// Token: 0x0400486F RID: 18543
	public GameObject[] Zombies;

	// Token: 0x04004870 RID: 18544
	public Vector3[] SpawnPoints;
}
