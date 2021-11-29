using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x06002080 RID: 8320 RVA: 0x001DC3A4 File Offset: 0x001DA5A4
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

	// Token: 0x06002081 RID: 8321 RVA: 0x001DC558 File Offset: 0x001DA758
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

	// Token: 0x04004729 RID: 18217
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400472A RID: 18218
	public GameObject GroundImpact;

	// Token: 0x0400472B RID: 18219
	public GameObject BlackHole;

	// Token: 0x0400472C RID: 18220
	public GameObject Character;

	// Token: 0x0400472D RID: 18221
	public GameObject HitEffect;

	// Token: 0x0400472E RID: 18222
	public GameObject Wall;

	// Token: 0x0400472F RID: 18223
	public AudioClip DeathScream;

	// Token: 0x04004730 RID: 18224
	public AudioClip HitSound;

	// Token: 0x04004731 RID: 18225
	public float HitReactTimer;

	// Token: 0x04004732 RID: 18226
	public float AttackTimer = 10f;

	// Token: 0x04004733 RID: 18227
	public float HP = 100f;

	// Token: 0x04004734 RID: 18228
	public bool CastSpell;

	// Token: 0x04004735 RID: 18229
	public bool Casting;
}
