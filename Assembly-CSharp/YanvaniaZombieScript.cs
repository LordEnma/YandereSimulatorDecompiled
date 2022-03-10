using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaZombieScript : MonoBehaviour
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x001E4270 File Offset: 0x001E2470
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

	// Token: 0x060020D2 RID: 8402 RVA: 0x001E4398 File Offset: 0x001E2598
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

	// Token: 0x060020D3 RID: 8403 RVA: 0x001E4868 File Offset: 0x001E2A68
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

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E4904 File Offset: 0x001E2B04
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

	// Token: 0x04004849 RID: 18505
	public GameObject ZombieEffect;

	// Token: 0x0400484A RID: 18506
	public GameObject BloodEffect;

	// Token: 0x0400484B RID: 18507
	public GameObject DeathEffect;

	// Token: 0x0400484C RID: 18508
	public GameObject HitEffect;

	// Token: 0x0400484D RID: 18509
	public GameObject Character;

	// Token: 0x0400484E RID: 18510
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400484F RID: 18511
	public int HP;

	// Token: 0x04004850 RID: 18512
	public float WalkSpeed1;

	// Token: 0x04004851 RID: 18513
	public float WalkSpeed2;

	// Token: 0x04004852 RID: 18514
	public float Damage;

	// Token: 0x04004853 RID: 18515
	public float HitReactTimer;

	// Token: 0x04004854 RID: 18516
	public float DeathTimer;

	// Token: 0x04004855 RID: 18517
	public float WalkTimer;

	// Token: 0x04004856 RID: 18518
	public float Timer;

	// Token: 0x04004857 RID: 18519
	public int HitReactState;

	// Token: 0x04004858 RID: 18520
	public int WalkType;

	// Token: 0x04004859 RID: 18521
	public float LeftBoundary;

	// Token: 0x0400485A RID: 18522
	public float RightBoundary;

	// Token: 0x0400485B RID: 18523
	public bool EffectSpawned;

	// Token: 0x0400485C RID: 18524
	public bool Dying;

	// Token: 0x0400485D RID: 18525
	public bool Sink;

	// Token: 0x0400485E RID: 18526
	public bool Walk;

	// Token: 0x0400485F RID: 18527
	public Texture[] Textures;

	// Token: 0x04004860 RID: 18528
	public Renderer MyRenderer;

	// Token: 0x04004861 RID: 18529
	public Collider MyCollider;

	// Token: 0x04004862 RID: 18530
	public AudioClip DeathSound;

	// Token: 0x04004863 RID: 18531
	public AudioClip HitSound;

	// Token: 0x04004864 RID: 18532
	public AudioClip RisingSound;

	// Token: 0x04004865 RID: 18533
	public AudioClip SinkingSound;
}
