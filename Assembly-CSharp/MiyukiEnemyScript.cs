using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019B7 RID: 6583 RVA: 0x001073E2 File Offset: 0x001055E2
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019B8 RID: 6584 RVA: 0x00107420 File Offset: 0x00105620
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

	// Token: 0x060019B9 RID: 6585 RVA: 0x00107674 File Offset: 0x00105874
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

	// Token: 0x0400293E RID: 10558
	public float Float;

	// Token: 0x0400293F RID: 10559
	public float Limit;

	// Token: 0x04002940 RID: 10560
	public float Speed;

	// Token: 0x04002941 RID: 10561
	public bool Dead;

	// Token: 0x04002942 RID: 10562
	public bool Down;

	// Token: 0x04002943 RID: 10563
	public GameObject DeathEffect;

	// Token: 0x04002944 RID: 10564
	public GameObject HitEffect;

	// Token: 0x04002945 RID: 10565
	public GameObject Enemy;

	// Token: 0x04002946 RID: 10566
	public Transform[] SpawnPoints;

	// Token: 0x04002947 RID: 10567
	public float RespawnTimer;

	// Token: 0x04002948 RID: 10568
	public float Health;

	// Token: 0x04002949 RID: 10569
	public int ID;
}
