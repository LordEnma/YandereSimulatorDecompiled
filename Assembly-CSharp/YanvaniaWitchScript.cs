using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x001DFFD8 File Offset: 0x001DE1D8
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

	// Token: 0x060020A6 RID: 8358 RVA: 0x001E018C File Offset: 0x001DE38C
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

	// Token: 0x04004797 RID: 18327
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004798 RID: 18328
	public GameObject GroundImpact;

	// Token: 0x04004799 RID: 18329
	public GameObject BlackHole;

	// Token: 0x0400479A RID: 18330
	public GameObject Character;

	// Token: 0x0400479B RID: 18331
	public GameObject HitEffect;

	// Token: 0x0400479C RID: 18332
	public GameObject Wall;

	// Token: 0x0400479D RID: 18333
	public AudioClip DeathScream;

	// Token: 0x0400479E RID: 18334
	public AudioClip HitSound;

	// Token: 0x0400479F RID: 18335
	public float HitReactTimer;

	// Token: 0x040047A0 RID: 18336
	public float AttackTimer = 10f;

	// Token: 0x040047A1 RID: 18337
	public float HP = 100f;

	// Token: 0x040047A2 RID: 18338
	public bool CastSpell;

	// Token: 0x040047A3 RID: 18339
	public bool Casting;
}
