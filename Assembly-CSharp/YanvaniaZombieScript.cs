using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x06002091 RID: 8337 RVA: 0x001DE6B4 File Offset: 0x001DC8B4
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

	// Token: 0x06002092 RID: 8338 RVA: 0x001DE7DC File Offset: 0x001DC9DC
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

	// Token: 0x06002093 RID: 8339 RVA: 0x001DECAC File Offset: 0x001DCEAC
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

	// Token: 0x06002094 RID: 8340 RVA: 0x001DED48 File Offset: 0x001DCF48
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

	// Token: 0x0400479C RID: 18332
	public GameObject ZombieEffect;

	// Token: 0x0400479D RID: 18333
	public GameObject BloodEffect;

	// Token: 0x0400479E RID: 18334
	public GameObject DeathEffect;

	// Token: 0x0400479F RID: 18335
	public GameObject HitEffect;

	// Token: 0x040047A0 RID: 18336
	public GameObject Character;

	// Token: 0x040047A1 RID: 18337
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047A2 RID: 18338
	public int HP;

	// Token: 0x040047A3 RID: 18339
	public float WalkSpeed1;

	// Token: 0x040047A4 RID: 18340
	public float WalkSpeed2;

	// Token: 0x040047A5 RID: 18341
	public float Damage;

	// Token: 0x040047A6 RID: 18342
	public float HitReactTimer;

	// Token: 0x040047A7 RID: 18343
	public float DeathTimer;

	// Token: 0x040047A8 RID: 18344
	public float WalkTimer;

	// Token: 0x040047A9 RID: 18345
	public float Timer;

	// Token: 0x040047AA RID: 18346
	public int HitReactState;

	// Token: 0x040047AB RID: 18347
	public int WalkType;

	// Token: 0x040047AC RID: 18348
	public float LeftBoundary;

	// Token: 0x040047AD RID: 18349
	public float RightBoundary;

	// Token: 0x040047AE RID: 18350
	public bool EffectSpawned;

	// Token: 0x040047AF RID: 18351
	public bool Dying;

	// Token: 0x040047B0 RID: 18352
	public bool Sink;

	// Token: 0x040047B1 RID: 18353
	public bool Walk;

	// Token: 0x040047B2 RID: 18354
	public Texture[] Textures;

	// Token: 0x040047B3 RID: 18355
	public Renderer MyRenderer;

	// Token: 0x040047B4 RID: 18356
	public Collider MyCollider;

	// Token: 0x040047B5 RID: 18357
	public AudioClip DeathSound;

	// Token: 0x040047B6 RID: 18358
	public AudioClip HitSound;

	// Token: 0x040047B7 RID: 18359
	public AudioClip RisingSound;

	// Token: 0x040047B8 RID: 18360
	public AudioClip SinkingSound;
}
