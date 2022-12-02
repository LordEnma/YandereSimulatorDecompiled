using UnityEngine;

public class YanvaniaWitchScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject GroundImpact;

	public GameObject BlackHole;

	public GameObject Character;

	public GameObject HitEffect;

	public GameObject Wall;

	public AudioClip DeathScream;

	public AudioClip HitSound;

	public float HitReactTimer;

	public float AttackTimer = 10f;

	public float HP = 100f;

	public bool CastSpell;

	public bool Casting;

	private void Update()
	{
		Animation component = Character.GetComponent<Animation>();
		if (AttackTimer < 10f)
		{
			AttackTimer += Time.deltaTime;
			if (AttackTimer > 0.8f && !CastSpell)
			{
				CastSpell = true;
				Object.Instantiate(BlackHole, base.transform.position + Vector3.up * 3f + Vector3.right * 6f, Quaternion.identity);
				Object.Instantiate(GroundImpact, base.transform.position + Vector3.right * 1.15f, Quaternion.identity);
			}
			if (component["Staff Spell Ground"].time >= component["Staff Spell Ground"].length)
			{
				component.CrossFade("Staff Stance");
				Casting = false;
			}
		}
		else if (Vector3.Distance(base.transform.position, Yanmont.transform.position) < 5f)
		{
			AttackTimer = 0f;
			Casting = true;
			CastSpell = false;
			component["Staff Spell Ground"].time = 0f;
			component.CrossFade("Staff Spell Ground");
		}
		if (!Casting && component["Receive Damage"].time >= component["Receive Damage"].length)
		{
			component.CrossFade("Staff Stance");
		}
		HitReactTimer += Time.deltaTime * 10f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!(HP > 0f))
		{
			return;
		}
		if (other.gameObject.tag == "Player")
		{
			Yanmont.TakeDamage(5);
		}
		if (!(other.gameObject.name == "Heart"))
		{
			return;
		}
		Animation component = Character.GetComponent<Animation>();
		if (!Casting)
		{
			component["Receive Damage"].time = 0f;
			component.Play("Receive Damage");
		}
		if (HitReactTimer >= 1f)
		{
			Object.Instantiate(HitEffect, other.transform.position, Quaternion.identity);
			HitReactTimer = 0f;
			HP -= 5f + ((float)Yanmont.Level * 5f - 5f);
			AudioSource component2 = GetComponent<AudioSource>();
			if (HP <= 0f)
			{
				component2.PlayOneShot(DeathScream);
				component.Play("Die 2");
				Yanmont.EXP += 100f;
				base.enabled = false;
				Object.Destroy(Wall);
			}
			else
			{
				component2.PlayOneShot(HitSound);
			}
		}
	}
}
