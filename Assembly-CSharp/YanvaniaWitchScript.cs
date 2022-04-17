using System;
using UnityEngine;

// Token: 0x020004EF RID: 1263
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E6690 File Offset: 0x001E4890
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

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E6844 File Offset: 0x001E4A44
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

	// Token: 0x0400487C RID: 18556
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400487D RID: 18557
	public GameObject GroundImpact;

	// Token: 0x0400487E RID: 18558
	public GameObject BlackHole;

	// Token: 0x0400487F RID: 18559
	public GameObject Character;

	// Token: 0x04004880 RID: 18560
	public GameObject HitEffect;

	// Token: 0x04004881 RID: 18561
	public GameObject Wall;

	// Token: 0x04004882 RID: 18562
	public AudioClip DeathScream;

	// Token: 0x04004883 RID: 18563
	public AudioClip HitSound;

	// Token: 0x04004884 RID: 18564
	public float HitReactTimer;

	// Token: 0x04004885 RID: 18565
	public float AttackTimer = 10f;

	// Token: 0x04004886 RID: 18566
	public float HP = 100f;

	// Token: 0x04004887 RID: 18567
	public bool CastSpell;

	// Token: 0x04004888 RID: 18568
	public bool Casting;
}
