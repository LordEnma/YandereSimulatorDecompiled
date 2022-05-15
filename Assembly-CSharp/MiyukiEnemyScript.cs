using System;
using UnityEngine;

// Token: 0x0200036E RID: 878
public class MiyukiEnemyScript : MonoBehaviour
{
	// Token: 0x060019D9 RID: 6617 RVA: 0x001094FA File Offset: 0x001076FA
	private void Start()
	{
		base.transform.position = this.SpawnPoints[this.ID].position;
		base.transform.rotation = this.SpawnPoints[this.ID].rotation;
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x00109538 File Offset: 0x00107738
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

	// Token: 0x060019DB RID: 6619 RVA: 0x0010978C File Offset: 0x0010798C
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

	// Token: 0x04002998 RID: 10648
	public float Float;

	// Token: 0x04002999 RID: 10649
	public float Limit;

	// Token: 0x0400299A RID: 10650
	public float Speed;

	// Token: 0x0400299B RID: 10651
	public bool Dead;

	// Token: 0x0400299C RID: 10652
	public bool Down;

	// Token: 0x0400299D RID: 10653
	public GameObject DeathEffect;

	// Token: 0x0400299E RID: 10654
	public GameObject HitEffect;

	// Token: 0x0400299F RID: 10655
	public GameObject Enemy;

	// Token: 0x040029A0 RID: 10656
	public Transform[] SpawnPoints;

	// Token: 0x040029A1 RID: 10657
	public float RespawnTimer;

	// Token: 0x040029A2 RID: 10658
	public float Health;

	// Token: 0x040029A3 RID: 10659
	public int ID;
}
