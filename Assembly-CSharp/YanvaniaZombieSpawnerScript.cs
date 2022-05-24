using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x06002120 RID: 8480 RVA: 0x001EC234 File Offset: 0x001EA434
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

	// Token: 0x04004952 RID: 18770
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x04004953 RID: 18771
	public GameObject Zombie;

	// Token: 0x04004954 RID: 18772
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004955 RID: 18773
	public float SpawnTimer;

	// Token: 0x04004956 RID: 18774
	public float RelativePoint;

	// Token: 0x04004957 RID: 18775
	public float RightBoundary;

	// Token: 0x04004958 RID: 18776
	public float LeftBoundary;

	// Token: 0x04004959 RID: 18777
	public int SpawnSide;

	// Token: 0x0400495A RID: 18778
	public int ID;

	// Token: 0x0400495B RID: 18779
	public GameObject[] Zombies;

	// Token: 0x0400495C RID: 18780
	public Vector3[] SpawnPoints;
}
