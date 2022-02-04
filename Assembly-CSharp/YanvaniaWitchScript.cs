using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020A7 RID: 8359 RVA: 0x001E02F0 File Offset: 0x001DE4F0
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

	// Token: 0x060020A8 RID: 8360 RVA: 0x001E04A4 File Offset: 0x001DE6A4
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

	// Token: 0x0400479D RID: 18333
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400479E RID: 18334
	public GameObject GroundImpact;

	// Token: 0x0400479F RID: 18335
	public GameObject BlackHole;

	// Token: 0x040047A0 RID: 18336
	public GameObject Character;

	// Token: 0x040047A1 RID: 18337
	public GameObject HitEffect;

	// Token: 0x040047A2 RID: 18338
	public GameObject Wall;

	// Token: 0x040047A3 RID: 18339
	public AudioClip DeathScream;

	// Token: 0x040047A4 RID: 18340
	public AudioClip HitSound;

	// Token: 0x040047A5 RID: 18341
	public float HitReactTimer;

	// Token: 0x040047A6 RID: 18342
	public float AttackTimer = 10f;

	// Token: 0x040047A7 RID: 18343
	public float HP = 100f;

	// Token: 0x040047A8 RID: 18344
	public bool CastSpell;

	// Token: 0x040047A9 RID: 18345
	public bool Casting;
}
