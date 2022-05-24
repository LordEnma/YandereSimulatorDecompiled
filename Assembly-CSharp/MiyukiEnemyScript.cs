using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019DA RID: 6618 RVA: 0x001096FE File Offset: 0x001078FE
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019DB RID: 6619 RVA: 0x0010973C File Offset: 0x0010793C
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

	// Token: 0x060019DC RID: 6620 RVA: 0x00109990 File Offset: 0x00107B90
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

	// Token: 0x0400299F RID: 10655
	public float Float;

	// Token: 0x040029A0 RID: 10656
	public float Limit;

	// Token: 0x040029A1 RID: 10657
	public float Speed;

	// Token: 0x040029A2 RID: 10658
	public bool Dead;

	// Token: 0x040029A3 RID: 10659
	public bool Down;

	// Token: 0x040029A4 RID: 10660
	public GameObject DeathEffect;

	// Token: 0x040029A5 RID: 10661
	public GameObject HitEffect;

	// Token: 0x040029A6 RID: 10662
	public GameObject Enemy;

	// Token: 0x040029A7 RID: 10663
	public Transform[] SpawnPoints;

	// Token: 0x040029A8 RID: 10664
	public float RespawnTimer;

	// Token: 0x040029A9 RID: 10665
	public float Health;

	// Token: 0x040029AA RID: 10666
	public int ID;
}
