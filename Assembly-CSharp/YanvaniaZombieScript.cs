using System;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x060020B6 RID: 8374 RVA: 0x001E22E8 File Offset: 0x001E04E8
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

	// Token: 0x060020B7 RID: 8375 RVA: 0x001E2410 File Offset: 0x001E0610
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

	// Token: 0x060020B8 RID: 8376 RVA: 0x001E28E0 File Offset: 0x001E0AE0
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

	// Token: 0x060020B9 RID: 8377 RVA: 0x001E297C File Offset: 0x001E0B7C
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

	// Token: 0x0400480A RID: 18442
	public GameObject ZombieEffect;

	// Token: 0x0400480B RID: 18443
	public GameObject BloodEffect;

	// Token: 0x0400480C RID: 18444
	public GameObject DeathEffect;

	// Token: 0x0400480D RID: 18445
	public GameObject HitEffect;

	// Token: 0x0400480E RID: 18446
	public GameObject Character;

	// Token: 0x0400480F RID: 18447
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004810 RID: 18448
	public int HP;

	// Token: 0x04004811 RID: 18449
	public float WalkSpeed1;

	// Token: 0x04004812 RID: 18450
	public float WalkSpeed2;

	// Token: 0x04004813 RID: 18451
	public float Damage;

	// Token: 0x04004814 RID: 18452
	public float HitReactTimer;

	// Token: 0x04004815 RID: 18453
	public float DeathTimer;

	// Token: 0x04004816 RID: 18454
	public float WalkTimer;

	// Token: 0x04004817 RID: 18455
	public float Timer;

	// Token: 0x04004818 RID: 18456
	public int HitReactState;

	// Token: 0x04004819 RID: 18457
	public int WalkType;

	// Token: 0x0400481A RID: 18458
	public float LeftBoundary;

	// Token: 0x0400481B RID: 18459
	public float RightBoundary;

	// Token: 0x0400481C RID: 18460
	public bool EffectSpawned;

	// Token: 0x0400481D RID: 18461
	public bool Dying;

	// Token: 0x0400481E RID: 18462
	public bool Sink;

	// Token: 0x0400481F RID: 18463
	public bool Walk;

	// Token: 0x04004820 RID: 18464
	public Texture[] Textures;

	// Token: 0x04004821 RID: 18465
	public Renderer MyRenderer;

	// Token: 0x04004822 RID: 18466
	public Collider MyCollider;

	// Token: 0x04004823 RID: 18467
	public AudioClip DeathSound;

	// Token: 0x04004824 RID: 18468
	public AudioClip HitSound;

	// Token: 0x04004825 RID: 18469
	public AudioClip RisingSound;

	// Token: 0x04004826 RID: 18470
	public AudioClip SinkingSound;
}
