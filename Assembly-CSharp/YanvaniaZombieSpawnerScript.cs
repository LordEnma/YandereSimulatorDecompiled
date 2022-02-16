using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020C7 RID: 8391 RVA: 0x001E340C File Offset: 0x001E160C
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

	// Token: 0x04004839 RID: 18489
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x0400483A RID: 18490
	public GameObject Zombie;

	// Token: 0x0400483B RID: 18491
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400483C RID: 18492
	public float SpawnTimer;

	// Token: 0x0400483D RID: 18493
	public float RelativePoint;

	// Token: 0x0400483E RID: 18494
	public float RightBoundary;

	// Token: 0x0400483F RID: 18495
	public float LeftBoundary;

	// Token: 0x04004840 RID: 18496
	public int SpawnSide;

	// Token: 0x04004841 RID: 18497
	public int ID;

	// Token: 0x04004842 RID: 18498
	public GameObject[] Zombies;

	// Token: 0x04004843 RID: 18499
	public Vector3[] SpawnPoints;
}
