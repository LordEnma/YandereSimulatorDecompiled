using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019AE RID: 6574 RVA: 0x0010674A File Offset: 0x0010494A
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019AF RID: 6575 RVA: 0x00106788 File Offset: 0x00104988
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

	// Token: 0x060019B0 RID: 6576 RVA: 0x001069DC File Offset: 0x00104BDC
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

	// Token: 0x04002919 RID: 10521
	public float Float;

	// Token: 0x0400291A RID: 10522
	public float Limit;

	// Token: 0x0400291B RID: 10523
	public float Speed;

	// Token: 0x0400291C RID: 10524
	public bool Dead;

	// Token: 0x0400291D RID: 10525
	public bool Down;

	// Token: 0x0400291E RID: 10526
	public GameObject DeathEffect;

	// Token: 0x0400291F RID: 10527
	public GameObject HitEffect;

	// Token: 0x04002920 RID: 10528
	public GameObject Enemy;

	// Token: 0x04002921 RID: 10529
	public Transform[] SpawnPoints;

	// Token: 0x04002922 RID: 10530
	public float RespawnTimer;

	// Token: 0x04002923 RID: 10531
	public float Health;

	// Token: 0x04002924 RID: 10532
	public int ID;
}
