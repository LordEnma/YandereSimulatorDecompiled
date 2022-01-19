using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020A1 RID: 8353 RVA: 0x001DF738 File Offset: 0x001DD938
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

	// Token: 0x060020A2 RID: 8354 RVA: 0x001DF8EC File Offset: 0x001DDAEC
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

	// Token: 0x0400478C RID: 18316
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400478D RID: 18317
	public GameObject GroundImpact;

	// Token: 0x0400478E RID: 18318
	public GameObject BlackHole;

	// Token: 0x0400478F RID: 18319
	public GameObject Character;

	// Token: 0x04004790 RID: 18320
	public GameObject HitEffect;

	// Token: 0x04004791 RID: 18321
	public GameObject Wall;

	// Token: 0x04004792 RID: 18322
	public AudioClip DeathScream;

	// Token: 0x04004793 RID: 18323
	public AudioClip HitSound;

	// Token: 0x04004794 RID: 18324
	public float HitReactTimer;

	// Token: 0x04004795 RID: 18325
	public float AttackTimer = 10f;

	// Token: 0x04004796 RID: 18326
	public float HP = 100f;

	// Token: 0x04004797 RID: 18327
	public bool CastSpell;

	// Token: 0x04004798 RID: 18328
	public bool Casting;
}
