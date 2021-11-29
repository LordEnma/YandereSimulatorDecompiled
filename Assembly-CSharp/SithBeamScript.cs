using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class SithBeamScript : MonoBehaviour
{
	// Token: 0x06001C88 RID: 7304 RVA: 0x001501F8 File Offset: 0x0014E3F8
	private void Update()
	{
		if (this.Projectile)
		{
			base.transform.Translate(base.transform.forward * Time.deltaTime * 15f, Space.World);
		}
		this.Lifespan = Mathf.MoveTowards(this.Lifespan, 0f, Time.deltaTime);
		if (this.Lifespan == 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001C89 RID: 7305 RVA: 0x0015026C File Offset: 0x0014E46C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				AudioSource.PlayClipAtPoint(this.Hit, base.transform.position);
				this.RandomNumber = UnityEngine.Random.Range(0, 3);
				if (this.MalePain.Length != 0)
				{
					if (component.Male)
					{
						AudioSource.PlayClipAtPoint(this.MalePain[this.RandomNumber], base.transform.position);
					}
					else
					{
						AudioSource.PlayClipAtPoint(this.FemalePain[this.RandomNumber], base.transform.position);
					}
				}
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				component.Health -= this.Damage;
				component.HealthBar.transform.parent.gameObject.SetActive(true);
				component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
				component.Character.transform.localScale = new Vector3(component.Character.transform.localScale.x * -1f, component.Character.transform.localScale.y, component.Character.transform.localScale.z);
				if (component.Health <= 0f)
				{
					component.DeathType = DeathType.EasterEgg;
					component.HealthBar.transform.parent.gameObject.SetActive(false);
					component.BecomeRagdoll();
					component.Ragdoll.AllRigidbodies[0].isKinematic = false;
				}
				else
				{
					component.CharacterAnimation[component.SithReactAnim].time = 0f;
					component.CharacterAnimation.Play(component.SithReactAnim);
					component.Pathfinding.canSearch = false;
					component.Pathfinding.canMove = false;
					component.HitReacting = true;
					component.Routine = false;
					component.Fleeing = false;
				}
				if (this.Projectile)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x04003302 RID: 13058
	public GameObject BloodEffect;

	// Token: 0x04003303 RID: 13059
	public Collider MyCollider;

	// Token: 0x04003304 RID: 13060
	public float Damage = 10f;

	// Token: 0x04003305 RID: 13061
	public float Lifespan;

	// Token: 0x04003306 RID: 13062
	public int RandomNumber;

	// Token: 0x04003307 RID: 13063
	public AudioClip Hit;

	// Token: 0x04003308 RID: 13064
	public AudioClip[] FemalePain;

	// Token: 0x04003309 RID: 13065
	public AudioClip[] MalePain;

	// Token: 0x0400330A RID: 13066
	public bool Projectile;
}
