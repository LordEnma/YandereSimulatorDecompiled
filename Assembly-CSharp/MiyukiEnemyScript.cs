using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019B7 RID: 6583 RVA: 0x0010707A File Offset: 0x0010527A
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019B8 RID: 6584 RVA: 0x001070B8 File Offset: 0x001052B8
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

	// Token: 0x060019B9 RID: 6585 RVA: 0x0010730C File Offset: 0x0010550C
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

	// Token: 0x04002928 RID: 10536
	public float Float;

	// Token: 0x04002929 RID: 10537
	public float Limit;

	// Token: 0x0400292A RID: 10538
	public float Speed;

	// Token: 0x0400292B RID: 10539
	public bool Dead;

	// Token: 0x0400292C RID: 10540
	public bool Down;

	// Token: 0x0400292D RID: 10541
	public GameObject DeathEffect;

	// Token: 0x0400292E RID: 10542
	public GameObject HitEffect;

	// Token: 0x0400292F RID: 10543
	public GameObject Enemy;

	// Token: 0x04002930 RID: 10544
	public Transform[] SpawnPoints;

	// Token: 0x04002931 RID: 10545
	public float RespawnTimer;

	// Token: 0x04002932 RID: 10546
	public float Health;

	// Token: 0x04002933 RID: 10547
	public int ID;
}
