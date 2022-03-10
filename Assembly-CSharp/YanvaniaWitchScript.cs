using System;
using UnityEngine;

// Token: 0x020004E6 RID: 1254
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020C0 RID: 8384 RVA: 0x001E1F60 File Offset: 0x001E0160
	private void Update()
	{
		Animation component = this.Character.GetComponent<Animation>();
		if (this.AttackTimer < 10f)
		{
			this.AttackTimer += Time.deltaTime;
			if (this.AttackTimer > 0.8f && !this.CastSpell)
			{
				this.CastSpell = true;
				UnityEngine.Object.Instantiate<GameObject>(this.BlackHole, base.transform.position + Vector3.up * 3f + Vector3.right * 6f, Quaternion.identity);
				UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position + Vector3.right * 1.15f, Quaternion.identity);
			}
			if (component["Staff Spell Ground"].time >= component["Staff Spell Ground"].length)
			{
				component.CrossFade("Staff Stance");
				this.Casting = false;
			}
		}
		else if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) < 5f)
		{
			this.AttackTimer = 0f;
			this.Casting = true;
			this.CastSpell = false;
			component["Staff Spell Ground"].time = 0f;
			component.CrossFade("Staff Spell Ground");
		}
		if (!this.Casting && component["Receive Damage"].time >= component["Receive Damage"].length)
		{
			component.CrossFade("Staff Stance");
		}
		this.HitReactTimer += Time.deltaTime * 10f;
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E2114 File Offset: 0x001E0314
	private void OnTriggerEnter(Collider other)
	{
		if (this.HP > 0f)
		{
			if (other.gameObject.tag == "Player")
			{
				this.Yanmont.TakeDamage(5);
			}
			if (other.gameObject.name == "Heart")
			{
				Animation component = this.Character.GetComponent<Animation>();
				if (!this.Casting)
				{
					component["Receive Damage"].time = 0f;
					component.Play("Receive Damage");
				}
				if (this.HitReactTimer >= 1f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
					this.HitReactTimer = 0f;
					this.HP -= 5f + ((float)this.Yanmont.Level * 5f - 5f);
					AudioSource component2 = base.GetComponent<AudioSource>();
					if (this.HP <= 0f)
					{
						component2.PlayOneShot(this.DeathScream);
						component.Play("Die 2");
						this.Yanmont.EXP += 100f;
						base.enabled = false;
						UnityEngine.Object.Destroy(this.Wall);
						return;
					}
					component2.PlayOneShot(this.HitSound);
				}
			}
		}
	}

	// Token: 0x040047D6 RID: 18390
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047D7 RID: 18391
	public GameObject GroundImpact;

	// Token: 0x040047D8 RID: 18392
	public GameObject BlackHole;

	// Token: 0x040047D9 RID: 18393
	public GameObject Character;

	// Token: 0x040047DA RID: 18394
	public GameObject HitEffect;

	// Token: 0x040047DB RID: 18395
	public GameObject Wall;

	// Token: 0x040047DC RID: 18396
	public AudioClip DeathScream;

	// Token: 0x040047DD RID: 18397
	public AudioClip HitSound;

	// Token: 0x040047DE RID: 18398
	public float HitReactTimer;

	// Token: 0x040047DF RID: 18399
	public float AttackTimer = 10f;

	// Token: 0x040047E0 RID: 18400
	public float HP = 100f;

	// Token: 0x040047E1 RID: 18401
	public bool CastSpell;

	// Token: 0x040047E2 RID: 18402
	public bool Casting;
}
