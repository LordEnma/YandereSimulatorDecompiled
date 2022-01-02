using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x001E03D8 File Offset: 0x001DE5D8
	private void Start()
	{
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, (this.Yanmont.transform.position.x > base.transform.position.x) ? 90f : -90f, base.transform.eulerAngles.z);
		UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
		base.transform.position = new Vector3(base.transform.position.x, -0.63f, base.transform.position.z);
		Animation component = this.Character.GetComponent<Animation>();
		component["getup1"].speed = 2f;
		component.Play("getup1");
		base.GetComponent<AudioSource>().PlayOneShot(this.RisingSound);
		this.MyRenderer.material.mainTexture = this.Textures[UnityEngine.Random.Range(0, 22)];
		this.MyCollider.enabled = false;
	}

	// Token: 0x060020A6 RID: 8358 RVA: 0x001E0500 File Offset: 0x001DE700
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Dying)
		{
			this.DeathTimer += Time.deltaTime;
			if (this.DeathTimer > 1f)
			{
				if (!this.EffectSpawned)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
					component.PlayOneShot(this.SinkingSound);
					this.EffectSpawned = true;
				}
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime, base.transform.position.z);
				if (base.transform.position.y < -0.4f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
		else
		{
			Animation component2 = this.Character.GetComponent<Animation>();
			if (this.Sink)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - Time.deltaTime * 0.74f, base.transform.position.z);
				if (base.transform.position.y < -0.63f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else if (this.Walk)
			{
				this.WalkTimer += Time.deltaTime;
				if (this.WalkType == 1)
				{
					base.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed1);
					component2.CrossFade("walk1");
				}
				else
				{
					base.transform.Translate(Vector3.forward * Time.deltaTime * this.WalkSpeed2);
					component2.CrossFade("walk2");
				}
				if (this.WalkTimer > 10f)
				{
					this.SinkNow();
				}
			}
			else
			{
				this.Timer += Time.deltaTime;
				if (base.transform.position.y < 0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime * 0.74f, base.transform.position.z);
					if (base.transform.position.y > 0f)
					{
						base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
					}
				}
				if (this.Timer > 0.85f)
				{
					this.Walk = true;
					this.MyCollider.enabled = true;
					this.WalkType = UnityEngine.Random.Range(1, 3);
				}
			}
			if (base.transform.position.x < this.LeftBoundary)
			{
				base.transform.position = new Vector3(this.LeftBoundary, base.transform.position.y, base.transform.position.z);
				this.SinkNow();
			}
			if (base.transform.position.x > this.RightBoundary)
			{
				base.transform.position = new Vector3(this.RightBoundary, base.transform.position.y, base.transform.position.z);
				this.SinkNow();
			}
			if (this.HP <= 0)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.DeathEffect, new Vector3(base.transform.position.x, base.transform.position.y + 1f, base.transform.position.z), Quaternion.identity);
				component2.Play("die");
				component.PlayOneShot(this.DeathSound);
				this.MyCollider.enabled = false;
				this.Yanmont.EXP += 10f;
				this.Dying = true;
			}
		}
		if (this.HitReactTimer < 1f)
		{
			this.MyRenderer.material.color = new Color(1f, this.HitReactTimer, this.HitReactTimer, 1f);
			this.HitReactTimer += Time.deltaTime * 10f;
			if (this.HitReactTimer >= 1f)
			{
				this.MyRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	// Token: 0x060020A7 RID: 8359 RVA: 0x001E09D0 File Offset: 0x001DEBD0
	private void SinkNow()
	{
		Animation component = this.Character.GetComponent<Animation>();
		component["getup1"].time = component["getup1"].length;
		component["getup1"].speed = -2f;
		component.Play("getup1");
		base.GetComponent<AudioSource>().PlayOneShot(this.SinkingSound);
		UnityEngine.Object.Instantiate<GameObject>(this.ZombieEffect, base.transform.position, Quaternion.identity);
		this.MyCollider.enabled = false;
		this.Sink = true;
	}

	// Token: 0x060020A8 RID: 8360 RVA: 0x001E0A6C File Offset: 0x001DEC6C
	private void OnTriggerEnter(Collider other)
	{
		if (!this.Dying)
		{
			if (other.gameObject.tag == "Player")
			{
				this.Yanmont.TakeDamage(5);
			}
			if (other.gameObject.name == "Heart" && this.HitReactTimer >= 1f)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
				base.GetComponent<AudioSource>().PlayOneShot(this.HitSound);
				this.HitReactTimer = 0f;
				this.HP -= 20 + (this.Yanmont.Level * 5 - 5);
			}
		}
	}

	// Token: 0x040047E4 RID: 18404
	public GameObject ZombieEffect;

	// Token: 0x040047E5 RID: 18405
	public GameObject BloodEffect;

	// Token: 0x040047E6 RID: 18406
	public GameObject DeathEffect;

	// Token: 0x040047E7 RID: 18407
	public GameObject HitEffect;

	// Token: 0x040047E8 RID: 18408
	public GameObject Character;

	// Token: 0x040047E9 RID: 18409
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047EA RID: 18410
	public int HP;

	// Token: 0x040047EB RID: 18411
	public float WalkSpeed1;

	// Token: 0x040047EC RID: 18412
	public float WalkSpeed2;

	// Token: 0x040047ED RID: 18413
	public float Damage;

	// Token: 0x040047EE RID: 18414
	public float HitReactTimer;

	// Token: 0x040047EF RID: 18415
	public float DeathTimer;

	// Token: 0x040047F0 RID: 18416
	public float WalkTimer;

	// Token: 0x040047F1 RID: 18417
	public float Timer;

	// Token: 0x040047F2 RID: 18418
	public int HitReactState;

	// Token: 0x040047F3 RID: 18419
	public int WalkType;

	// Token: 0x040047F4 RID: 18420
	public float LeftBoundary;

	// Token: 0x040047F5 RID: 18421
	public float RightBoundary;

	// Token: 0x040047F6 RID: 18422
	public bool EffectSpawned;

	// Token: 0x040047F7 RID: 18423
	public bool Dying;

	// Token: 0x040047F8 RID: 18424
	public bool Sink;

	// Token: 0x040047F9 RID: 18425
	public bool Walk;

	// Token: 0x040047FA RID: 18426
	public Texture[] Textures;

	// Token: 0x040047FB RID: 18427
	public Renderer MyRenderer;

	// Token: 0x040047FC RID: 18428
	public Collider MyCollider;

	// Token: 0x040047FD RID: 18429
	public AudioClip DeathSound;

	// Token: 0x040047FE RID: 18430
	public AudioClip HitSound;

	// Token: 0x040047FF RID: 18431
	public AudioClip RisingSound;

	// Token: 0x04004800 RID: 18432
	public AudioClip SinkingSound;
}
