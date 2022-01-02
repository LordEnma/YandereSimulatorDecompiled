using System;
using UnityEngine;

// Token: 0x020004E0 RID: 1248
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x06002094 RID: 8340 RVA: 0x001DE0C8 File Offset: 0x001DC2C8
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

	// Token: 0x06002095 RID: 8341 RVA: 0x001DE27C File Offset: 0x001DC47C
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

	// Token: 0x04004771 RID: 18289
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004772 RID: 18290
	public GameObject GroundImpact;

	// Token: 0x04004773 RID: 18291
	public GameObject BlackHole;

	// Token: 0x04004774 RID: 18292
	public GameObject Character;

	// Token: 0x04004775 RID: 18293
	public GameObject HitEffect;

	// Token: 0x04004776 RID: 18294
	public GameObject Wall;

	// Token: 0x04004777 RID: 18295
	public AudioClip DeathScream;

	// Token: 0x04004778 RID: 18296
	public AudioClip HitSound;

	// Token: 0x04004779 RID: 18297
	public float HitReactTimer;

	// Token: 0x0400477A RID: 18298
	public float AttackTimer = 10f;

	// Token: 0x0400477B RID: 18299
	public float HP = 100f;

	// Token: 0x0400477C RID: 18300
	public bool CastSpell;

	// Token: 0x0400477D RID: 18301
	public bool Casting;
}
