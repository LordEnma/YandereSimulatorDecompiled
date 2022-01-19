using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class SithBeamScript : MonoBehaviour
{
	// Token: 0x06001C9B RID: 7323 RVA: 0x00152940 File Offset: 0x00150B40
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

	// Token: 0x06001C9C RID: 7324 RVA: 0x001529B4 File Offset: 0x00150BB4
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

	// Token: 0x0400333F RID: 13119
	public GameObject BloodEffect;

	// Token: 0x04003340 RID: 13120
	public Collider MyCollider;

	// Token: 0x04003341 RID: 13121
	public float Damage = 10f;

	// Token: 0x04003342 RID: 13122
	public float Lifespan;

	// Token: 0x04003343 RID: 13123
	public int RandomNumber;

	// Token: 0x04003344 RID: 13124
	public AudioClip Hit;

	// Token: 0x04003345 RID: 13125
	public AudioClip[] FemalePain;

	// Token: 0x04003346 RID: 13126
	public AudioClip[] MalePain;

	// Token: 0x04003347 RID: 13127
	public bool Projectile;
}
