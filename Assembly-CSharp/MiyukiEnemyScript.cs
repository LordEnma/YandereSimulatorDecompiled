using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019CB RID: 6603 RVA: 0x0010852E File Offset: 0x0010672E
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x0010856C File Offset: 0x0010676C
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

	// Token: 0x060019CD RID: 6605 RVA: 0x001087C0 File Offset: 0x001069C0
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

	// Token: 0x04002976 RID: 10614
	public float Float;

	// Token: 0x04002977 RID: 10615
	public float Limit;

	// Token: 0x04002978 RID: 10616
	public float Speed;

	// Token: 0x04002979 RID: 10617
	public bool Dead;

	// Token: 0x0400297A RID: 10618
	public bool Down;

	// Token: 0x0400297B RID: 10619
	public GameObject DeathEffect;

	// Token: 0x0400297C RID: 10620
	public GameObject HitEffect;

	// Token: 0x0400297D RID: 10621
	public GameObject Enemy;

	// Token: 0x0400297E RID: 10622
	public Transform[] SpawnPoints;

	// Token: 0x0400297F RID: 10623
	public float RespawnTimer;

	// Token: 0x04002980 RID: 10624
	public float Health;

	// Token: 0x04002981 RID: 10625
	public int ID;
}
