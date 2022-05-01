using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class YanvaniaWitchScript : MonoBehaviour
{
	// Token: 0x060020FE RID: 8446 RVA: 0x001E7B1C File Offset: 0x001E5D1C
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

	// Token: 0x060020FF RID: 8447 RVA: 0x001E7CD0 File Offset: 0x001E5ED0
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

	// Token: 0x04004892 RID: 18578
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004893 RID: 18579
	public GameObject GroundImpact;

	// Token: 0x04004894 RID: 18580
	public GameObject BlackHole;

	// Token: 0x04004895 RID: 18581
	public GameObject Character;

	// Token: 0x04004896 RID: 18582
	public GameObject HitEffect;

	// Token: 0x04004897 RID: 18583
	public GameObject Wall;

	// Token: 0x04004898 RID: 18584
	public AudioClip DeathScream;

	// Token: 0x04004899 RID: 18585
	public AudioClip HitSound;

	// Token: 0x0400489A RID: 18586
	public float HitReactTimer;

	// Token: 0x0400489B RID: 18587
	public float AttackTimer = 10f;

	// Token: 0x0400489C RID: 18588
	public float HP = 100f;

	// Token: 0x0400489D RID: 18589
	public bool CastSpell;

	// Token: 0x0400489E RID: 18590
	public bool Casting;
}
