using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x06001375 RID: 4981 RVA: 0x000B2C3C File Offset: 0x000B0E3C
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x000B2C9C File Offset: 0x000B0E9C
	private void Update()
	{
		if (!this.Rising)
		{
			if (!this.Attacking)
			{
				this.MyAnimation.CrossFade(this.IdleAnim);
				return;
			}
			if (!this.Attacked)
			{
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length * 0.15f)
				{
					this.ClawCollider.enabled = true;
					this.Attacked = true;
					return;
				}
			}
			else
			{
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length * 0.4f)
				{
					this.ClawCollider.enabled = false;
				}
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.ClawCollider.enabled = false;
					this.Attacking = false;
					this.Attacked = false;
					this.AnimTime = 0f;
					return;
				}
			}
		}
		else if (this.MyAnimation["DemonArmRise"].time >= this.MyAnimation["DemonArmRise"].length)
		{
			this.Rising = false;
		}
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x000B2DFC File Offset: 0x000B0FFC
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			AudioSource component2 = base.GetComponent<AudioSource>();
			component2.clip = this.Whoosh;
			component2.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
			component2.Play();
			base.GetComponent<Animation>().CrossFade(this.AttackAnim);
			this.Attacking = true;
		}
	}

	// Token: 0x04001CA1 RID: 7329
	public GameObject DismembermentCollider;

	// Token: 0x04001CA2 RID: 7330
	public Animation MyAnimation;

	// Token: 0x04001CA3 RID: 7331
	public Collider ClawCollider;

	// Token: 0x04001CA4 RID: 7332
	public bool Attacking;

	// Token: 0x04001CA5 RID: 7333
	public bool Attacked;

	// Token: 0x04001CA6 RID: 7334
	public bool Rising = true;

	// Token: 0x04001CA7 RID: 7335
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001CA8 RID: 7336
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001CA9 RID: 7337
	public AudioClip Whoosh;

	// Token: 0x04001CAA RID: 7338
	public float AnimSpeed = 1f;

	// Token: 0x04001CAB RID: 7339
	public float AnimTime;
}
