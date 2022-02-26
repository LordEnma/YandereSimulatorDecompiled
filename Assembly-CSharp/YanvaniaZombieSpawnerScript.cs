using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020D0 RID: 8400 RVA: 0x001E3FEC File Offset: 0x001E21EC
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

	// Token: 0x04004849 RID: 18505
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x0400484A RID: 18506
	public GameObject Zombie;

	// Token: 0x0400484B RID: 18507
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400484C RID: 18508
	public float SpawnTimer;

	// Token: 0x0400484D RID: 18509
	public float RelativePoint;

	// Token: 0x0400484E RID: 18510
	public float RightBoundary;

	// Token: 0x0400484F RID: 18511
	public float LeftBoundary;

	// Token: 0x04004850 RID: 18512
	public int SpawnSide;

	// Token: 0x04004851 RID: 18513
	public int ID;

	// Token: 0x04004852 RID: 18514
	public GameObject[] Zombies;

	// Token: 0x04004853 RID: 18515
	public Vector3[] SpawnPoints;
}
