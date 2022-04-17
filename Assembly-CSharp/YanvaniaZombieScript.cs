using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x06002106 RID: 8454 RVA: 0x001E89A0 File Offset: 0x001E6BA0
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

	// Token: 0x06002107 RID: 8455 RVA: 0x001E8AC8 File Offset: 0x001E6CC8
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

	// Token: 0x06002108 RID: 8456 RVA: 0x001E8F98 File Offset: 0x001E7198
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

	// Token: 0x06002109 RID: 8457 RVA: 0x001E9034 File Offset: 0x001E7234
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

	// Token: 0x040048EF RID: 18671
	public GameObject ZombieEffect;

	// Token: 0x040048F0 RID: 18672
	public GameObject BloodEffect;

	// Token: 0x040048F1 RID: 18673
	public GameObject DeathEffect;

	// Token: 0x040048F2 RID: 18674
	public GameObject HitEffect;

	// Token: 0x040048F3 RID: 18675
	public GameObject Character;

	// Token: 0x040048F4 RID: 18676
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040048F5 RID: 18677
	public int HP;

	// Token: 0x040048F6 RID: 18678
	public float WalkSpeed1;

	// Token: 0x040048F7 RID: 18679
	public float WalkSpeed2;

	// Token: 0x040048F8 RID: 18680
	public float Damage;

	// Token: 0x040048F9 RID: 18681
	public float HitReactTimer;

	// Token: 0x040048FA RID: 18682
	public float DeathTimer;

	// Token: 0x040048FB RID: 18683
	public float WalkTimer;

	// Token: 0x040048FC RID: 18684
	public float Timer;

	// Token: 0x040048FD RID: 18685
	public int HitReactState;

	// Token: 0x040048FE RID: 18686
	public int WalkType;

	// Token: 0x040048FF RID: 18687
	public float LeftBoundary;

	// Token: 0x04004900 RID: 18688
	public float RightBoundary;

	// Token: 0x04004901 RID: 18689
	public bool EffectSpawned;

	// Token: 0x04004902 RID: 18690
	public bool Dying;

	// Token: 0x04004903 RID: 18691
	public bool Sink;

	// Token: 0x04004904 RID: 18692
	public bool Walk;

	// Token: 0x04004905 RID: 18693
	public Texture[] Textures;

	// Token: 0x04004906 RID: 18694
	public Renderer MyRenderer;

	// Token: 0x04004907 RID: 18695
	public Collider MyCollider;

	// Token: 0x04004908 RID: 18696
	public AudioClip DeathSound;

	// Token: 0x04004909 RID: 18697
	public AudioClip HitSound;

	// Token: 0x0400490A RID: 18698
	public AudioClip RisingSound;

	// Token: 0x0400490B RID: 18699
	public AudioClip SinkingSound;
}
