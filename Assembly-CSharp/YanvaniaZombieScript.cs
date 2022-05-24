using System;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x0600211B RID: 8475 RVA: 0x001EBAE0 File Offset: 0x001E9CE0
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

	// Token: 0x0600211C RID: 8476 RVA: 0x001EBC08 File Offset: 0x001E9E08
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

	// Token: 0x0600211D RID: 8477 RVA: 0x001EC0D8 File Offset: 0x001EA2D8
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

	// Token: 0x0600211E RID: 8478 RVA: 0x001EC174 File Offset: 0x001EA374
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

	// Token: 0x04004935 RID: 18741
	public GameObject ZombieEffect;

	// Token: 0x04004936 RID: 18742
	public GameObject BloodEffect;

	// Token: 0x04004937 RID: 18743
	public GameObject DeathEffect;

	// Token: 0x04004938 RID: 18744
	public GameObject HitEffect;

	// Token: 0x04004939 RID: 18745
	public GameObject Character;

	// Token: 0x0400493A RID: 18746
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400493B RID: 18747
	public int HP;

	// Token: 0x0400493C RID: 18748
	public float WalkSpeed1;

	// Token: 0x0400493D RID: 18749
	public float WalkSpeed2;

	// Token: 0x0400493E RID: 18750
	public float Damage;

	// Token: 0x0400493F RID: 18751
	public float HitReactTimer;

	// Token: 0x04004940 RID: 18752
	public float DeathTimer;

	// Token: 0x04004941 RID: 18753
	public float WalkTimer;

	// Token: 0x04004942 RID: 18754
	public float Timer;

	// Token: 0x04004943 RID: 18755
	public int HitReactState;

	// Token: 0x04004944 RID: 18756
	public int WalkType;

	// Token: 0x04004945 RID: 18757
	public float LeftBoundary;

	// Token: 0x04004946 RID: 18758
	public float RightBoundary;

	// Token: 0x04004947 RID: 18759
	public bool EffectSpawned;

	// Token: 0x04004948 RID: 18760
	public bool Dying;

	// Token: 0x04004949 RID: 18761
	public bool Sink;

	// Token: 0x0400494A RID: 18762
	public bool Walk;

	// Token: 0x0400494B RID: 18763
	public Texture[] Textures;

	// Token: 0x0400494C RID: 18764
	public Renderer MyRenderer;

	// Token: 0x0400494D RID: 18765
	public Collider MyCollider;

	// Token: 0x0400494E RID: 18766
	public AudioClip DeathSound;

	// Token: 0x0400494F RID: 18767
	public AudioClip HitSound;

	// Token: 0x04004950 RID: 18768
	public AudioClip RisingSound;

	// Token: 0x04004951 RID: 18769
	public AudioClip SinkingSound;
}
