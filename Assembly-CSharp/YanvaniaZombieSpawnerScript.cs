using System;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x06002115 RID: 8469 RVA: 0x001EA67C File Offset: 0x001E887C
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

	// Token: 0x04004922 RID: 18722
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x04004923 RID: 18723
	public GameObject Zombie;

	// Token: 0x04004924 RID: 18724
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004925 RID: 18725
	public float SpawnTimer;

	// Token: 0x04004926 RID: 18726
	public float RelativePoint;

	// Token: 0x04004927 RID: 18727
	public float RightBoundary;

	// Token: 0x04004928 RID: 18728
	public float LeftBoundary;

	// Token: 0x04004929 RID: 18729
	public int SpawnSide;

	// Token: 0x0400492A RID: 18730
	public int ID;

	// Token: 0x0400492B RID: 18731
	public GameObject[] Zombies;

	// Token: 0x0400492C RID: 18732
	public Vector3[] SpawnPoints;
}
