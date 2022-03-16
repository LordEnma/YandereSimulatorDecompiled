using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E3EC8 File Offset: 0x001E20C8
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

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E407C File Offset: 0x001E227C
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

	// Token: 0x04004835 RID: 18485
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004836 RID: 18486
	public GameObject GroundImpact;

	// Token: 0x04004837 RID: 18487
	public GameObject BlackHole;

	// Token: 0x04004838 RID: 18488
	public GameObject Character;

	// Token: 0x04004839 RID: 18489
	public GameObject HitEffect;

	// Token: 0x0400483A RID: 18490
	public GameObject Wall;

	// Token: 0x0400483B RID: 18491
	public AudioClip DeathScream;

	// Token: 0x0400483C RID: 18492
	public AudioClip HitSound;

	// Token: 0x0400483D RID: 18493
	public float HitReactTimer;

	// Token: 0x0400483E RID: 18494
	public float AttackTimer = 10f;

	// Token: 0x0400483F RID: 18495
	public float HP = 100f;

	// Token: 0x04004840 RID: 18496
	public bool CastSpell;

	// Token: 0x04004841 RID: 18497
	public bool Casting;
}
