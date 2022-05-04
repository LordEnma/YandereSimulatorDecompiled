using System;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x06002110 RID: 8464 RVA: 0x001E9F28 File Offset: 0x001E8128
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

	// Token: 0x06002111 RID: 8465 RVA: 0x001EA050 File Offset: 0x001E8250
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

	// Token: 0x06002112 RID: 8466 RVA: 0x001EA520 File Offset: 0x001E8720
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

	// Token: 0x06002113 RID: 8467 RVA: 0x001EA5BC File Offset: 0x001E87BC
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

	// Token: 0x04004905 RID: 18693
	public GameObject ZombieEffect;

	// Token: 0x04004906 RID: 18694
	public GameObject BloodEffect;

	// Token: 0x04004907 RID: 18695
	public GameObject DeathEffect;

	// Token: 0x04004908 RID: 18696
	public GameObject HitEffect;

	// Token: 0x04004909 RID: 18697
	public GameObject Character;

	// Token: 0x0400490A RID: 18698
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400490B RID: 18699
	public int HP;

	// Token: 0x0400490C RID: 18700
	public float WalkSpeed1;

	// Token: 0x0400490D RID: 18701
	public float WalkSpeed2;

	// Token: 0x0400490E RID: 18702
	public float Damage;

	// Token: 0x0400490F RID: 18703
	public float HitReactTimer;

	// Token: 0x04004910 RID: 18704
	public float DeathTimer;

	// Token: 0x04004911 RID: 18705
	public float WalkTimer;

	// Token: 0x04004912 RID: 18706
	public float Timer;

	// Token: 0x04004913 RID: 18707
	public int HitReactState;

	// Token: 0x04004914 RID: 18708
	public int WalkType;

	// Token: 0x04004915 RID: 18709
	public float LeftBoundary;

	// Token: 0x04004916 RID: 18710
	public float RightBoundary;

	// Token: 0x04004917 RID: 18711
	public bool EffectSpawned;

	// Token: 0x04004918 RID: 18712
	public bool Dying;

	// Token: 0x04004919 RID: 18713
	public bool Sink;

	// Token: 0x0400491A RID: 18714
	public bool Walk;

	// Token: 0x0400491B RID: 18715
	public Texture[] Textures;

	// Token: 0x0400491C RID: 18716
	public Renderer MyRenderer;

	// Token: 0x0400491D RID: 18717
	public Collider MyCollider;

	// Token: 0x0400491E RID: 18718
	public AudioClip DeathSound;

	// Token: 0x0400491F RID: 18719
	public AudioClip HitSound;

	// Token: 0x04004920 RID: 18720
	public AudioClip RisingSound;

	// Token: 0x04004921 RID: 18721
	public AudioClip SinkingSound;
}
