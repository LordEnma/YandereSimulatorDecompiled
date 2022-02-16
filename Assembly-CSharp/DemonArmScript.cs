using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x06001375 RID: 4981 RVA: 0x000B28C8 File Offset: 0x000B0AC8
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x000B2928 File Offset: 0x000B0B28
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

	// Token: 0x06001377 RID: 4983 RVA: 0x000B2A88 File Offset: 0x000B0C88
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

	// Token: 0x04001C97 RID: 7319
	public GameObject DismembermentCollider;

	// Token: 0x04001C98 RID: 7320
	public Animation MyAnimation;

	// Token: 0x04001C99 RID: 7321
	public Collider ClawCollider;

	// Token: 0x04001C9A RID: 7322
	public bool Attacking;

	// Token: 0x04001C9B RID: 7323
	public bool Attacked;

	// Token: 0x04001C9C RID: 7324
	public bool Rising = true;

	// Token: 0x04001C9D RID: 7325
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001C9E RID: 7326
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001C9F RID: 7327
	public AudioClip Whoosh;

	// Token: 0x04001CA0 RID: 7328
	public float AnimSpeed = 1f;

	// Token: 0x04001CA1 RID: 7329
	public float AnimTime;
}
