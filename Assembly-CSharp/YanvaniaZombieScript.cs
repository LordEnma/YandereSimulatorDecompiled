using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x060020E9 RID: 8425 RVA: 0x001E61D8 File Offset: 0x001E43D8
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

	// Token: 0x060020EA RID: 8426 RVA: 0x001E6300 File Offset: 0x001E4500
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

	// Token: 0x060020EB RID: 8427 RVA: 0x001E67D0 File Offset: 0x001E49D0
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

	// Token: 0x060020EC RID: 8428 RVA: 0x001E686C File Offset: 0x001E4A6C
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

	// Token: 0x040048A8 RID: 18600
	public GameObject ZombieEffect;

	// Token: 0x040048A9 RID: 18601
	public GameObject BloodEffect;

	// Token: 0x040048AA RID: 18602
	public GameObject DeathEffect;

	// Token: 0x040048AB RID: 18603
	public GameObject HitEffect;

	// Token: 0x040048AC RID: 18604
	public GameObject Character;

	// Token: 0x040048AD RID: 18605
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040048AE RID: 18606
	public int HP;

	// Token: 0x040048AF RID: 18607
	public float WalkSpeed1;

	// Token: 0x040048B0 RID: 18608
	public float WalkSpeed2;

	// Token: 0x040048B1 RID: 18609
	public float Damage;

	// Token: 0x040048B2 RID: 18610
	public float HitReactTimer;

	// Token: 0x040048B3 RID: 18611
	public float DeathTimer;

	// Token: 0x040048B4 RID: 18612
	public float WalkTimer;

	// Token: 0x040048B5 RID: 18613
	public float Timer;

	// Token: 0x040048B6 RID: 18614
	public int HitReactState;

	// Token: 0x040048B7 RID: 18615
	public int WalkType;

	// Token: 0x040048B8 RID: 18616
	public float LeftBoundary;

	// Token: 0x040048B9 RID: 18617
	public float RightBoundary;

	// Token: 0x040048BA RID: 18618
	public bool EffectSpawned;

	// Token: 0x040048BB RID: 18619
	public bool Dying;

	// Token: 0x040048BC RID: 18620
	public bool Sink;

	// Token: 0x040048BD RID: 18621
	public bool Walk;

	// Token: 0x040048BE RID: 18622
	public Texture[] Textures;

	// Token: 0x040048BF RID: 18623
	public Renderer MyRenderer;

	// Token: 0x040048C0 RID: 18624
	public Collider MyCollider;

	// Token: 0x040048C1 RID: 18625
	public AudioClip DeathSound;

	// Token: 0x040048C2 RID: 18626
	public AudioClip HitSound;

	// Token: 0x040048C3 RID: 18627
	public AudioClip RisingSound;

	// Token: 0x040048C4 RID: 18628
	public AudioClip SinkingSound;
}
