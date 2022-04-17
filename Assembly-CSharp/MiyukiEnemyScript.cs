using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019CF RID: 6607 RVA: 0x001087F2 File Offset: 0x001069F2
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x00108830 File Offset: 0x00106A30
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

	// Token: 0x060019D1 RID: 6609 RVA: 0x00108A84 File Offset: 0x00106C84
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

	// Token: 0x0400297E RID: 10622
	public float Float;

	// Token: 0x0400297F RID: 10623
	public float Limit;

	// Token: 0x04002980 RID: 10624
	public float Speed;

	// Token: 0x04002981 RID: 10625
	public bool Dead;

	// Token: 0x04002982 RID: 10626
	public bool Down;

	// Token: 0x04002983 RID: 10627
	public GameObject DeathEffect;

	// Token: 0x04002984 RID: 10628
	public GameObject HitEffect;

	// Token: 0x04002985 RID: 10629
	public GameObject Enemy;

	// Token: 0x04002986 RID: 10630
	public Transform[] SpawnPoints;

	// Token: 0x04002987 RID: 10631
	public float RespawnTimer;

	// Token: 0x04002988 RID: 10632
	public float Health;

	// Token: 0x04002989 RID: 10633
	public int ID;
}
