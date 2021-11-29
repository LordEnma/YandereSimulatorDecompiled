using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class MGPMEnemyScript : MonoBehaviour
{
	// Token: 0x06000027 RID: 39 RVA: 0x0000351C File Offset: 0x0000171C
	private void Start()
	{
		if (this.Pattern != 10 && GameGlobals.HardMode)
		{
			this.Health += 6;
		}
		if (base.transform.localPosition.x < 0f)
		{
			this.Side = 1;
		}
		else
		{
			this.Side = -1;
		}
		if (this.Pattern == 11)
		{
			this.MyCollider.enabled = false;
		}
		if (this.GameplayManager.GameOver)
		{
			this.MyAudio.volume = 0f;
			this.AttackFrequency = 0f;
		}
		if (this.GameplayManager.Eighties)
		{
			this.MyRenderer.material.color = new Color(1f, 0f, 0f, 1f);
		}
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000035E4 File Offset: 0x000017E4
	private void Update()
	{
		if (this.Health > 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.FPS)
			{
				this.Timer = 0f;
				this.Frame++;
				if (this.Frame == this.Sprite.Length)
				{
					this.Frame = 0;
				}
				this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
				if (this.ExtraRenderer != null)
				{
					this.ExtraRenderer.material.mainTexture = this.Sprite[this.Frame];
				}
			}
			switch (this.Pattern)
			{
			case 0:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				this.Speed = Mathf.Lerp(this.Speed, 0f, Time.deltaTime);
				break;
			case 1:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, this.Miyuki.transform.localPosition, this.Speed * Time.deltaTime);
					this.Speed = Mathf.Lerp(this.Speed, 0f, Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 2f)
					{
						this.AttackTimer = -100f;
						this.Phase++;
					}
				}
				else
				{
					this.Rotation = Mathf.Lerp(this.Rotation, (float)(90 * this.Side), this.Speed * Time.deltaTime);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, this.Rotation);
					base.transform.Translate(base.transform.up * -1f * this.Speed * Time.deltaTime);
					this.Speed += Time.deltaTime;
					if (base.transform.localPosition.y > 288f)
					{
						UnityEngine.Object.Destroy(base.gameObject);
					}
				}
				break;
			case 2:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - 100f * Time.deltaTime, base.transform.localPosition.z);
				if (this.Phase == 1)
				{
					this.Speed -= Time.deltaTime * 200f;
					if (this.Speed < -200f)
					{
						this.Phase++;
					}
				}
				else
				{
					this.Speed += Time.deltaTime * 200f;
					if (this.Speed > 200f)
					{
						this.Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 3:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 4:
				base.transform.LookAt(this.Miyuki.transform.position);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 5:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 1f)
					{
						this.Speed = 1f;
						this.Phase++;
					}
				}
				else
				{
					this.Speed += this.Speed * Time.deltaTime * 2.5f;
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, this.Speed * -1f, base.transform.localPosition.z);
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 6:
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 135f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
				break;
			case 7:
				base.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x - this.Speed * Time.deltaTime, base.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x < -160f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 8:
				base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - this.Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 160f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 9:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + this.Speed * Time.deltaTime, base.transform.localPosition.y - 20f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 60f)
				{
					base.transform.localPosition = new Vector3(60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				else if (base.transform.localPosition.x < -60f)
				{
					base.transform.localPosition = new Vector3(-60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				if (this.Phase == 1)
				{
					this.Speed -= Time.deltaTime * 120f;
					if (this.Speed < -120f)
					{
						this.Phase++;
					}
				}
				else
				{
					this.Speed += Time.deltaTime * 120f;
					if (this.Speed > 120f)
					{
						this.Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 10:
				if (this.Phase == 1)
				{
					base.transform.LookAt(this.Miyuki.transform);
					this.Phase++;
				}
				else
				{
					base.transform.Translate(Vector3.forward * this.Speed * Time.deltaTime, Space.Self);
				}
				if (base.transform.localPosition.y < -288f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
				break;
			case 11:
				if (this.Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 5f)
					{
						this.MyCollider.enabled = true;
						this.AttackFrequency = 0.5f;
						this.PhaseTimer = 0f;
						this.Speed = 0f;
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					this.PhaseTimer += Time.deltaTime;
					if (this.PhaseTimer > 10f)
					{
						this.QuintupleAttack = false;
						this.SextupleAttack = false;
						this.ShootEverywhere = true;
						this.AttackFrequency = 0.1f;
						this.PhaseTimer = 0f;
						this.Speed = 0.1f;
						this.Spin = 45f;
						this.Phase++;
					}
				}
				else if (this.Phase == 3)
				{
					this.PhaseTimer += Time.deltaTime;
					this.Speed += this.Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, -214f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					if (this.PhaseTimer > 5f)
					{
						this.PhaseTimer = 0f;
						this.Speed = 0.1f;
						this.Phase++;
					}
				}
				else if (this.Phase == 4)
				{
					this.PhaseTimer += Time.deltaTime;
					this.Speed += this.Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), this.Speed * Time.deltaTime);
					if (this.PhaseTimer > 5f)
					{
						this.QuintupleAttack = true;
						this.SextupleAttack = true;
						this.ShootEverywhere = false;
						this.AttackFrequency = 0.5f;
						this.PhaseTimer = 0f;
						this.Phase = 2;
					}
				}
				break;
			}
			if (this.AttackFrequency > 0f)
			{
				this.AttackTimer += Time.deltaTime;
				if (this.AttackTimer > this.AttackFrequency)
				{
					if (this.ShootEverywhere)
					{
						this.Attack(5f, this.Spin);
						this.Spin += 5f;
					}
					else if (this.SextupleAttack)
					{
						this.Attack(5f, 115f);
						this.Attack(5f, 105f);
						this.Attack(5f, 95f);
						this.Attack(5f, 85f);
						this.Attack(5f, 75f);
						this.Attack(5f, 65f);
						this.QuintupleAttack = true;
						this.SextupleAttack = false;
					}
					else if (this.QuintupleAttack)
					{
						this.Attack(5f, 105f);
						this.Attack(5f, 97.5f);
						this.Attack(5f, 90f);
						this.Attack(5f, 82.5f);
						this.Attack(5f, 75f);
						this.QuintupleAttack = false;
						this.SextupleAttack = true;
					}
					else if (this.TripleAttack)
					{
						this.Attack(5f, 90f);
						this.Attack(5f, 75f);
						this.Attack(5f, 105f);
					}
					else if (this.DoubleAttack)
					{
						this.Attack(2.5f, 90f);
						this.Attack(5f, 90f);
					}
					else
					{
						this.Attack(5f, 90f);
					}
					this.AttackTimer = 0f;
				}
			}
		}
		else if (this.Pattern < 11)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			if (this.Pattern == 6 || this.Pattern == 9 || this.Pattern == 12)
			{
				gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
			}
			if (GameGlobals.EasyMode)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.PickUp, base.transform.position, Quaternion.identity);
				gameObject2.transform.parent = base.transform.parent;
				gameObject2.transform.localScale = new Vector3(16f, 16f, 1f);
				if (this.Miyuki.GameplayManager.Eighties)
				{
					gameObject2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
			}
			this.GameplayManager.Score += 100;
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			this.GameplayManager.Jukebox.volume -= Time.deltaTime * 0.1f;
			this.AttackFrequency = 0f;
			this.Pattern = 100;
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer < 5f)
			{
				if (this.ExplosionTimer == 0f)
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
					gameObject3.transform.parent = base.transform.parent;
					gameObject3.transform.localPosition += new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-50f, 50f), 0f);
					gameObject3.transform.localScale = new Vector3(128f, 128f, 1f);
					this.GameplayManager.Score += 100;
					this.ExplosionTimer = 0.1f;
				}
				else
				{
					this.ExplosionTimer = Mathf.MoveTowards(this.ExplosionTimer, 0f, Time.deltaTime);
				}
			}
			else
			{
				GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.FinalBossExplosion, base.transform.position, Quaternion.identity);
				gameObject4.transform.parent = base.transform.parent;
				gameObject4.transform.localScale = new Vector3(256f, 256f, 1f);
				this.GameplayManager.StageClear = true;
				this.GameplayManager.Score += 1000;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		if (this.FlashWhite > 0f)
		{
			this.FlashWhite = Mathf.MoveTowards(this.FlashWhite, 0f, Time.deltaTime);
			if (this.FlashWhite == 0f)
			{
				this.MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
				if (this.ExtraRenderer != null)
				{
					this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
				}
			}
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00004790 File Offset: 0x00002990
	private void Attack(float AttackSpeed, float AttackRotation)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Projectile, base.transform.position, Quaternion.identity);
		gameObject.transform.parent = base.transform.parent;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
		if (this.Homing)
		{
			gameObject.transform.LookAt(this.Miyuki.transform);
		}
		else
		{
			gameObject.transform.localEulerAngles = new Vector3(AttackRotation, 90f, 0f);
		}
		gameObject.GetComponent<MGPMProjectileScript>().Speed = AttackSpeed;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000486C File Offset: 0x00002A6C
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 8)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Impact, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			gameObject.transform.localScale = new Vector3(32f, 32f, 32f);
			gameObject.transform.localPosition = new Vector3(collision.gameObject.transform.localPosition.x, collision.gameObject.transform.localPosition.y, 1f);
			this.MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
			if (this.ExtraRenderer != null)
			{
				this.ExtraRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
			}
			UnityEngine.Object.Destroy(collision.gameObject);
			this.FlashWhite = 0.05f;
			this.Health--;
			if (this.Health == 0 && this.MyCollider != null)
			{
				this.MyCollider.enabled = false;
			}
			if (this.HealthBar != null)
			{
				this.HealthBar.localScale = new Vector3((float)this.Health / 500f, 1f, 1f);
			}
		}
	}

	// Token: 0x04000060 RID: 96
	public MGPMManagerScript GameplayManager;

	// Token: 0x04000061 RID: 97
	public MGPMMiyukiScript Miyuki;

	// Token: 0x04000062 RID: 98
	public AudioSource MyAudio;

	// Token: 0x04000063 RID: 99
	public GameObject FinalBossExplosion;

	// Token: 0x04000064 RID: 100
	public GameObject Projectile;

	// Token: 0x04000065 RID: 101
	public GameObject Explosion;

	// Token: 0x04000066 RID: 102
	public GameObject PickUp;

	// Token: 0x04000067 RID: 103
	public GameObject Impact;

	// Token: 0x04000068 RID: 104
	public Renderer ExtraRenderer;

	// Token: 0x04000069 RID: 105
	public Renderer MyRenderer;

	// Token: 0x0400006A RID: 106
	public Collider MyCollider;

	// Token: 0x0400006B RID: 107
	public Transform HealthBar;

	// Token: 0x0400006C RID: 108
	public Texture[] Sprite;

	// Token: 0x0400006D RID: 109
	public int Pattern;

	// Token: 0x0400006E RID: 110
	public int Health;

	// Token: 0x0400006F RID: 111
	public int Frame;

	// Token: 0x04000070 RID: 112
	public int Phase;

	// Token: 0x04000071 RID: 113
	public int Side;

	// Token: 0x04000072 RID: 114
	public float AttackFrequency;

	// Token: 0x04000073 RID: 115
	public float ExplosionTimer;

	// Token: 0x04000074 RID: 116
	public float AttackTimer;

	// Token: 0x04000075 RID: 117
	public float DeathTimer;

	// Token: 0x04000076 RID: 118
	public float PhaseTimer;

	// Token: 0x04000077 RID: 119
	public float FlashWhite;

	// Token: 0x04000078 RID: 120
	public float Rotation;

	// Token: 0x04000079 RID: 121
	public float Speed;

	// Token: 0x0400007A RID: 122
	public float Timer;

	// Token: 0x0400007B RID: 123
	public float Spin;

	// Token: 0x0400007C RID: 124
	public float FPS;

	// Token: 0x0400007D RID: 125
	public float PositionX;

	// Token: 0x0400007E RID: 126
	public float PositionY;

	// Token: 0x0400007F RID: 127
	public bool ShootEverywhere;

	// Token: 0x04000080 RID: 128
	public bool QuintupleAttack;

	// Token: 0x04000081 RID: 129
	public bool SextupleAttack;

	// Token: 0x04000082 RID: 130
	public bool DoubleAttack;

	// Token: 0x04000083 RID: 131
	public bool TripleAttack;

	// Token: 0x04000084 RID: 132
	public bool Homing;
}
