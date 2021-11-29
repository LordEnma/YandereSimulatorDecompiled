using System;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x06001997 RID: 6551 RVA: 0x00104D9A File Offset: 0x00102F9A
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x00104DD8 File Offset: 0x00102FD8
	private void Update()
	{
		if (this.Enemy.activeInHierarchy)
		{
			if (!this.Down)
			{
				this.Float += Time.deltaTime * this.Speed;
				if (this.Float > this.Limit)
				{
					this.Down = true;
				}
			}
			else
			{
				this.Float -= Time.deltaTime * this.Speed;
				if (this.Float < -1f * this.Limit)
				{
					this.Down = false;
				}
			}
			this.Enemy.transform.position += new Vector3(0f, this.Float * Time.deltaTime, 0f);
			if (this.Enemy.transform.position.y > this.SpawnPoints[this.ID].position.y + 1.5f)
			{
				this.Enemy.transform.position = new Vector3(this.Enemy.transform.position.x, this.SpawnPoints[this.ID].position.y + 1.5f, this.Enemy.transform.position.z);
			}
			if (this.Enemy.transform.position.y < this.SpawnPoints[this.ID].position.y + 0.5f)
			{
				this.Enemy.transform.position = new Vector3(this.Enemy.transform.position.x, this.SpawnPoints[this.ID].position.y + 0.5f, this.Enemy.transform.position.z);
				return;
			}
		}
		else
		{
			this.RespawnTimer += Time.deltaTime;
			if (this.RespawnTimer > 5f)
			{
				base.transform.position = this.SpawnPoints[this.ID].position;
				base.transform.rotation = this.SpawnPoints[this.ID].rotation;
				this.Enemy.SetActive(true);
				this.RespawnTimer = 0f;
			}
		}
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x0010502C File Offset: 0x0010322C
	private void OnTriggerEnter(Collider other)
	{
		if (this.Enemy.activeInHierarchy && other.gameObject.tag == "missile")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(other.gameObject);
			this.Health -= 1f;
			if (this.Health == 0f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.DeathEffect, other.transform.position, Quaternion.identity);
				this.Enemy.SetActive(false);
				this.Health = 50f;
				this.ID++;
				if (this.ID >= this.SpawnPoints.Length)
				{
					this.ID = 0;
				}
			}
		}
	}

	// Token: 0x040028D7 RID: 10455
	public float Float;

	// Token: 0x040028D8 RID: 10456
	public float Limit;

	// Token: 0x040028D9 RID: 10457
	public float Speed;

	// Token: 0x040028DA RID: 10458
	public bool Dead;

	// Token: 0x040028DB RID: 10459
	public bool Down;

	// Token: 0x040028DC RID: 10460
	public GameObject DeathEffect;

	// Token: 0x040028DD RID: 10461
	public GameObject HitEffect;

	// Token: 0x040028DE RID: 10462
	public GameObject Enemy;

	// Token: 0x040028DF RID: 10463
	public Transform[] SpawnPoints;

	// Token: 0x040028E0 RID: 10464
	public float RespawnTimer;

	// Token: 0x040028E1 RID: 10465
	public float Health;

	// Token: 0x040028E2 RID: 10466
	public int ID;
}
