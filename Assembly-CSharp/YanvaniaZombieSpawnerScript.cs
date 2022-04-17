using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x0600210B RID: 8459 RVA: 0x001E90F4 File Offset: 0x001E72F4
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

	// Token: 0x0400490C RID: 18700
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x0400490D RID: 18701
	public GameObject Zombie;

	// Token: 0x0400490E RID: 18702
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400490F RID: 18703
	public float SpawnTimer;

	// Token: 0x04004910 RID: 18704
	public float RelativePoint;

	// Token: 0x04004911 RID: 18705
	public float RightBoundary;

	// Token: 0x04004912 RID: 18706
	public float LeftBoundary;

	// Token: 0x04004913 RID: 18707
	public int SpawnSide;

	// Token: 0x04004914 RID: 18708
	public int ID;

	// Token: 0x04004915 RID: 18709
	public GameObject[] Zombies;

	// Token: 0x04004916 RID: 18710
	public Vector3[] SpawnPoints;
}
