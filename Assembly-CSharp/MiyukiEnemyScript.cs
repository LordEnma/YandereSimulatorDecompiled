using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019A0 RID: 6560 RVA: 0x00105916 File Offset: 0x00103B16
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x00105954 File Offset: 0x00103B54
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

	// Token: 0x060019A2 RID: 6562 RVA: 0x00105BA8 File Offset: 0x00103DA8
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

	// Token: 0x04002900 RID: 10496
	public float Float;

	// Token: 0x04002901 RID: 10497
	public float Limit;

	// Token: 0x04002902 RID: 10498
	public float Speed;

	// Token: 0x04002903 RID: 10499
	public bool Dead;

	// Token: 0x04002904 RID: 10500
	public bool Down;

	// Token: 0x04002905 RID: 10501
	public GameObject DeathEffect;

	// Token: 0x04002906 RID: 10502
	public GameObject HitEffect;

	// Token: 0x04002907 RID: 10503
	public GameObject Enemy;

	// Token: 0x04002908 RID: 10504
	public Transform[] SpawnPoints;

	// Token: 0x04002909 RID: 10505
	public float RespawnTimer;

	// Token: 0x0400290A RID: 10506
	public float Health;

	// Token: 0x0400290B RID: 10507
	public int ID;
}
