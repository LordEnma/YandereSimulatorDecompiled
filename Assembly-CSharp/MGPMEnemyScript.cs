using UnityEngine;

public class MGPMEnemyScript : MonoBehaviour
{
	public MGPMManagerScript GameplayManager;

	public MGPMMiyukiScript Miyuki;

	public AudioSource MyAudio;

	public GameObject FinalBossExplosion;

	public GameObject Projectile;

	public GameObject Explosion;

	public GameObject PickUp;

	public GameObject Impact;

	public Renderer ExtraRenderer;

	public Renderer MyRenderer;

	public Collider MyCollider;

	public Transform HealthBar;

	public Texture[] Sprite;

	public int Pattern;

	public int Health;

	public int Frame;

	public int Phase;

	public int Side;

	public float AttackFrequency;

	public float ExplosionTimer;

	public float AttackTimer;

	public float DeathTimer;

	public float PhaseTimer;

	public float FlashWhite;

	public float Rotation;

	public float Speed;

	public float Timer;

	public float Spin;

	public float FPS;

	public float PositionX;

	public float PositionY;

	public bool ShootEverywhere;

	public bool QuintupleAttack;

	public bool SextupleAttack;

	public bool DoubleAttack;

	public bool TripleAttack;

	public bool Homing;

	private void Start()
	{
		if (Pattern != 10 && GameGlobals.HardMode)
		{
			Health += 6;
		}
		if (base.transform.localPosition.x < 0f)
		{
			Side = 1;
		}
		else
		{
			Side = -1;
		}
		if (Pattern == 11)
		{
			MyCollider.enabled = false;
		}
		if (GameplayManager.GameOver)
		{
			MyAudio.volume = 0f;
			AttackFrequency = 0f;
		}
		if (GameplayManager.Eighties)
		{
			MyRenderer.material.color = new Color(1f, 0f, 0f, 1f);
			if (ExtraRenderer != null)
			{
				ExtraRenderer.material.color = new Color(1f, 0f, 0f, 1f);
			}
		}
	}

	private void Update()
	{
		if (Health > 0)
		{
			Timer += Time.deltaTime;
			if (Timer > FPS)
			{
				Timer = 0f;
				Frame++;
				if (Frame == Sprite.Length)
				{
					Frame = 0;
				}
				MyRenderer.material.mainTexture = Sprite[Frame];
				if (ExtraRenderer != null)
				{
					ExtraRenderer.material.mainTexture = Sprite[Frame];
				}
			}
			switch (Pattern)
			{
			case 0:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - Speed * Time.deltaTime, 0f);
				Speed = Mathf.Lerp(Speed, 0f, Time.deltaTime);
				break;
			case 1:
				if (Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, Miyuki.transform.localPosition, Speed * Time.deltaTime);
					Speed = Mathf.Lerp(Speed, 0f, Time.deltaTime);
					PhaseTimer += Time.deltaTime;
					if (PhaseTimer > 2f)
					{
						AttackTimer = -100f;
						Phase++;
					}
				}
				else
				{
					Rotation = Mathf.Lerp(Rotation, 90 * Side, Speed * Time.deltaTime);
					base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Rotation);
					base.transform.Translate(base.transform.up * -1f * Speed * Time.deltaTime);
					Speed += Time.deltaTime;
					if (base.transform.localPosition.y > 288f)
					{
						Object.Destroy(base.gameObject);
					}
				}
				break;
			case 2:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + Speed * Time.deltaTime, base.transform.localPosition.y - 100f * Time.deltaTime, base.transform.localPosition.z);
				if (Phase == 1)
				{
					Speed -= Time.deltaTime * 200f;
					if (Speed < -200f)
					{
						Phase++;
					}
				}
				else
				{
					Speed += Time.deltaTime * 200f;
					if (Speed > 200f)
					{
						Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 3:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 4:
				base.transform.LookAt(Miyuki.transform.position);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - Speed * Time.deltaTime, 0f);
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 5:
				if (Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 0f, base.transform.localPosition.z), Speed * Time.deltaTime);
					PhaseTimer += Time.deltaTime;
					if (PhaseTimer > 1f)
					{
						Speed = 1f;
						Phase++;
					}
				}
				else
				{
					Speed += Speed * Time.deltaTime * 2.5f;
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, Speed * -1f, base.transform.localPosition.z);
				}
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 6:
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 135f, base.transform.localPosition.z), Speed * Time.deltaTime);
				break;
			case 7:
				base.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x - Speed * Time.deltaTime, base.transform.localPosition.y - Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x < -160f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 8:
				base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + Speed * Time.deltaTime, base.transform.localPosition.y - Speed * 0.25f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 160f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 9:
				base.transform.localPosition = new Vector3(base.transform.localPosition.x + Speed * Time.deltaTime, base.transform.localPosition.y - 20f * Time.deltaTime, base.transform.localPosition.z);
				if (base.transform.localPosition.x > 60f)
				{
					base.transform.localPosition = new Vector3(60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				else if (base.transform.localPosition.x < -60f)
				{
					base.transform.localPosition = new Vector3(-60f, base.transform.localPosition.y, base.transform.localPosition.z);
				}
				if (Phase == 1)
				{
					Speed -= Time.deltaTime * 120f;
					if (Speed < -120f)
					{
						Phase++;
					}
				}
				else
				{
					Speed += Time.deltaTime * 120f;
					if (Speed > 120f)
					{
						Phase--;
					}
				}
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 10:
				if (Phase == 1)
				{
					base.transform.LookAt(Miyuki.transform);
					Phase++;
				}
				else
				{
					base.transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
				}
				if (base.transform.localPosition.y < -288f)
				{
					Object.Destroy(base.gameObject);
				}
				break;
			case 11:
				if (Phase == 1)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), Speed * Time.deltaTime);
					PhaseTimer += Time.deltaTime;
					if (PhaseTimer > 5f)
					{
						MyCollider.enabled = true;
						AttackFrequency = 0.5f;
						PhaseTimer = 0f;
						Speed = 0f;
						Phase++;
					}
				}
				else if (Phase == 2)
				{
					PhaseTimer += Time.deltaTime;
					if (PhaseTimer > 10f)
					{
						QuintupleAttack = false;
						SextupleAttack = false;
						ShootEverywhere = true;
						AttackFrequency = 0.1f;
						PhaseTimer = 0f;
						Speed = 0.1f;
						Spin = 45f;
						Phase++;
					}
				}
				else if (Phase == 3)
				{
					PhaseTimer += Time.deltaTime;
					Speed += Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, -214f, base.transform.localPosition.z), Speed * Time.deltaTime);
					if (PhaseTimer > 5f)
					{
						PhaseTimer = 0f;
						Speed = 0.1f;
						Phase++;
					}
				}
				else if (Phase == 4)
				{
					PhaseTimer += Time.deltaTime;
					Speed += Speed * Time.deltaTime;
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, 150f, base.transform.localPosition.z), Speed * Time.deltaTime);
					if (PhaseTimer > 5f)
					{
						QuintupleAttack = true;
						SextupleAttack = true;
						ShootEverywhere = false;
						AttackFrequency = 0.5f;
						PhaseTimer = 0f;
						Phase = 2;
					}
				}
				break;
			}
			if (AttackFrequency > 0f)
			{
				AttackTimer += Time.deltaTime;
				if (AttackTimer > AttackFrequency)
				{
					if (ShootEverywhere)
					{
						Attack(5f, Spin);
						Spin += 5f;
					}
					else if (SextupleAttack)
					{
						Attack(5f, 115f);
						Attack(5f, 105f);
						Attack(5f, 95f);
						Attack(5f, 85f);
						Attack(5f, 75f);
						Attack(5f, 65f);
						QuintupleAttack = true;
						SextupleAttack = false;
					}
					else if (QuintupleAttack)
					{
						Attack(5f, 105f);
						Attack(5f, 97.5f);
						Attack(5f, 90f);
						Attack(5f, 82.5f);
						Attack(5f, 75f);
						QuintupleAttack = false;
						SextupleAttack = true;
					}
					else if (TripleAttack)
					{
						Attack(5f, 90f);
						Attack(5f, 75f);
						Attack(5f, 105f);
					}
					else if (DoubleAttack)
					{
						Attack(2.5f, 90f);
						Attack(5f, 90f);
					}
					else
					{
						Attack(5f, 90f);
					}
					AttackTimer = 0f;
				}
			}
		}
		else if (Pattern < 11)
		{
			GameObject gameObject = Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			if (Pattern == 6 || Pattern == 9 || Pattern == 12)
			{
				gameObject.transform.localScale = new Vector3(128f, 128f, 1f);
			}
			else
			{
				gameObject.transform.localScale = new Vector3(64f, 64f, 1f);
			}
			if (GameGlobals.EasyMode)
			{
				GameObject gameObject2 = Object.Instantiate(PickUp, base.transform.position, Quaternion.identity);
				gameObject2.transform.parent = base.transform.parent;
				gameObject2.transform.localScale = new Vector3(16f, 16f, 1f);
				if (Miyuki.GameplayManager.Eighties)
				{
					gameObject2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
			}
			GameplayManager.Score += 100;
			Object.Destroy(base.gameObject);
		}
		else
		{
			GameplayManager.Jukebox.volume -= Time.deltaTime * 0.1f;
			AttackFrequency = 0f;
			Pattern = 100;
			DeathTimer += Time.deltaTime;
			if (DeathTimer < 5f)
			{
				if (ExplosionTimer == 0f)
				{
					GameObject obj = Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
					obj.transform.parent = base.transform.parent;
					obj.transform.localPosition += new Vector3(Random.Range(-100f, 100f), Random.Range(-50f, 50f), 0f);
					obj.transform.localScale = new Vector3(128f, 128f, 1f);
					GameplayManager.Score += 100;
					ExplosionTimer = 0.1f;
				}
				else
				{
					ExplosionTimer = Mathf.MoveTowards(ExplosionTimer, 0f, Time.deltaTime);
				}
			}
			else
			{
				GameObject obj2 = Object.Instantiate(FinalBossExplosion, base.transform.position, Quaternion.identity);
				obj2.transform.parent = base.transform.parent;
				obj2.transform.localScale = new Vector3(256f, 256f, 1f);
				GameplayManager.StageClear = true;
				GameplayManager.Score += 1000;
				Object.Destroy(base.gameObject);
			}
		}
		if (!(FlashWhite > 0f))
		{
			return;
		}
		FlashWhite = Mathf.MoveTowards(FlashWhite, 0f, Time.deltaTime);
		if (FlashWhite == 0f)
		{
			MyRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
			if (ExtraRenderer != null)
			{
				ExtraRenderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 0f));
			}
		}
	}

	private void Attack(float AttackSpeed, float AttackRotation)
	{
		GameObject gameObject = Object.Instantiate(Projectile, base.transform.position, Quaternion.identity);
		gameObject.transform.parent = base.transform.parent;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 1f);
		if (Homing)
		{
			gameObject.transform.LookAt(Miyuki.transform);
		}
		else
		{
			gameObject.transform.localEulerAngles = new Vector3(AttackRotation, 90f, 0f);
		}
		gameObject.GetComponent<MGPMProjectileScript>().Speed = AttackSpeed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer != 8)
		{
			return;
		}
		GameObject obj = Object.Instantiate(Impact, base.transform.position, Quaternion.identity);
		obj.transform.parent = base.transform.parent;
		obj.transform.localScale = new Vector3(32f, 32f, 32f);
		obj.transform.localPosition = new Vector3(collision.gameObject.transform.localPosition.x, collision.gameObject.transform.localPosition.y, 1f);
		MyRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
		if (ExtraRenderer != null)
		{
			ExtraRenderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 1f, 1f));
		}
		Object.Destroy(collision.gameObject);
		FlashWhite = 0.05f;
		Health--;
		if (Health == 0 && MyCollider != null)
		{
			MyCollider.enabled = false;
			if (Pattern == 11)
			{
				Miyuki.Invincibility = 100f;
			}
		}
		if (HealthBar != null)
		{
			HealthBar.localScale = new Vector3((float)Health / 500f, 1f, 1f);
		}
	}
}
