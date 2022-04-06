using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E5C34 File Offset: 0x001E3E34
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

	// Token: 0x060020EF RID: 8431 RVA: 0x001E5DE8 File Offset: 0x001E3FE8
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

	// Token: 0x0400486A RID: 18538
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400486B RID: 18539
	public GameObject GroundImpact;

	// Token: 0x0400486C RID: 18540
	public GameObject BlackHole;

	// Token: 0x0400486D RID: 18541
	public GameObject Character;

	// Token: 0x0400486E RID: 18542
	public GameObject HitEffect;

	// Token: 0x0400486F RID: 18543
	public GameObject Wall;

	// Token: 0x04004870 RID: 18544
	public AudioClip DeathScream;

	// Token: 0x04004871 RID: 18545
	public AudioClip HitSound;

	// Token: 0x04004872 RID: 18546
	public float HitReactTimer;

	// Token: 0x04004873 RID: 18547
	public float AttackTimer = 10f;

	// Token: 0x04004874 RID: 18548
	public float HP = 100f;

	// Token: 0x04004875 RID: 18549
	public bool CastSpell;

	// Token: 0x04004876 RID: 18550
	public bool Casting;
}
