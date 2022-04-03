using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x060020FC RID: 8444 RVA: 0x001E8168 File Offset: 0x001E6368
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

	// Token: 0x040048F6 RID: 18678
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x040048F7 RID: 18679
	public GameObject Zombie;

	// Token: 0x040048F8 RID: 18680
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040048F9 RID: 18681
	public float SpawnTimer;

	// Token: 0x040048FA RID: 18682
	public float RelativePoint;

	// Token: 0x040048FB RID: 18683
	public float RightBoundary;

	// Token: 0x040048FC RID: 18684
	public float LeftBoundary;

	// Token: 0x040048FD RID: 18685
	public int SpawnSide;

	// Token: 0x040048FE RID: 18686
	public int ID;

	// Token: 0x040048FF RID: 18687
	public GameObject[] Zombies;

	// Token: 0x04004900 RID: 18688
	public Vector3[] SpawnPoints;
}
