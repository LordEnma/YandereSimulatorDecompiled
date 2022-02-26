using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x060020CB RID: 8395 RVA: 0x001E3898 File Offset: 0x001E1A98
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

	// Token: 0x060020CC RID: 8396 RVA: 0x001E39C0 File Offset: 0x001E1BC0
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

	// Token: 0x060020CD RID: 8397 RVA: 0x001E3E90 File Offset: 0x001E2090
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

	// Token: 0x060020CE RID: 8398 RVA: 0x001E3F2C File Offset: 0x001E212C
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

	// Token: 0x0400482C RID: 18476
	public GameObject ZombieEffect;

	// Token: 0x0400482D RID: 18477
	public GameObject BloodEffect;

	// Token: 0x0400482E RID: 18478
	public GameObject DeathEffect;

	// Token: 0x0400482F RID: 18479
	public GameObject HitEffect;

	// Token: 0x04004830 RID: 18480
	public GameObject Character;

	// Token: 0x04004831 RID: 18481
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004832 RID: 18482
	public int HP;

	// Token: 0x04004833 RID: 18483
	public float WalkSpeed1;

	// Token: 0x04004834 RID: 18484
	public float WalkSpeed2;

	// Token: 0x04004835 RID: 18485
	public float Damage;

	// Token: 0x04004836 RID: 18486
	public float HitReactTimer;

	// Token: 0x04004837 RID: 18487
	public float DeathTimer;

	// Token: 0x04004838 RID: 18488
	public float WalkTimer;

	// Token: 0x04004839 RID: 18489
	public float Timer;

	// Token: 0x0400483A RID: 18490
	public int HitReactState;

	// Token: 0x0400483B RID: 18491
	public int WalkType;

	// Token: 0x0400483C RID: 18492
	public float LeftBoundary;

	// Token: 0x0400483D RID: 18493
	public float RightBoundary;

	// Token: 0x0400483E RID: 18494
	public bool EffectSpawned;

	// Token: 0x0400483F RID: 18495
	public bool Dying;

	// Token: 0x04004840 RID: 18496
	public bool Sink;

	// Token: 0x04004841 RID: 18497
	public bool Walk;

	// Token: 0x04004842 RID: 18498
	public Texture[] Textures;

	// Token: 0x04004843 RID: 18499
	public Renderer MyRenderer;

	// Token: 0x04004844 RID: 18500
	public Collider MyCollider;

	// Token: 0x04004845 RID: 18501
	public AudioClip DeathSound;

	// Token: 0x04004846 RID: 18502
	public AudioClip HitSound;

	// Token: 0x04004847 RID: 18503
	public AudioClip RisingSound;

	// Token: 0x04004848 RID: 18504
	public AudioClip SinkingSound;
}
