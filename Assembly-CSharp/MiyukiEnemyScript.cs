using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019BF RID: 6591 RVA: 0x00107D72 File Offset: 0x00105F72
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x00107DB0 File Offset: 0x00105FB0
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

	// Token: 0x060019C1 RID: 6593 RVA: 0x00108004 File Offset: 0x00106204
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

	// Token: 0x04002960 RID: 10592
	public float Float;

	// Token: 0x04002961 RID: 10593
	public float Limit;

	// Token: 0x04002962 RID: 10594
	public float Speed;

	// Token: 0x04002963 RID: 10595
	public bool Dead;

	// Token: 0x04002964 RID: 10596
	public bool Down;

	// Token: 0x04002965 RID: 10597
	public GameObject DeathEffect;

	// Token: 0x04002966 RID: 10598
	public GameObject HitEffect;

	// Token: 0x04002967 RID: 10599
	public GameObject Enemy;

	// Token: 0x04002968 RID: 10600
	public Transform[] SpawnPoints;

	// Token: 0x04002969 RID: 10601
	public float RespawnTimer;

	// Token: 0x0400296A RID: 10602
	public float Health;

	// Token: 0x0400296B RID: 10603
	public int ID;
}
