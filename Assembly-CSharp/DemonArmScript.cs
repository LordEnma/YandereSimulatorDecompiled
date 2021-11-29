using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x06001369 RID: 4969 RVA: 0x000B1F58 File Offset: 0x000B0158
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x0600136A RID: 4970 RVA: 0x000B1FB8 File Offset: 0x000B01B8
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

	// Token: 0x0600136B RID: 4971 RVA: 0x000B2118 File Offset: 0x000B0318
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

	// Token: 0x04001C69 RID: 7273
	public GameObject DismembermentCollider;

	// Token: 0x04001C6A RID: 7274
	public Animation MyAnimation;

	// Token: 0x04001C6B RID: 7275
	public Collider ClawCollider;

	// Token: 0x04001C6C RID: 7276
	public bool Attacking;

	// Token: 0x04001C6D RID: 7277
	public bool Attacked;

	// Token: 0x04001C6E RID: 7278
	public bool Rising = true;

	// Token: 0x04001C6F RID: 7279
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001C70 RID: 7280
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001C71 RID: 7281
	public AudioClip Whoosh;

	// Token: 0x04001C72 RID: 7282
	public float AnimSpeed = 1f;

	// Token: 0x04001C73 RID: 7283
	public float AnimTime;
}
