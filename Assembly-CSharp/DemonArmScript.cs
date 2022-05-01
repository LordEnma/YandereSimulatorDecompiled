using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x0600137D RID: 4989 RVA: 0x000B36E8 File Offset: 0x000B18E8
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000B3748 File Offset: 0x000B1948
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

	// Token: 0x0600137F RID: 4991 RVA: 0x000B38A8 File Offset: 0x000B1AA8
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

	// Token: 0x04001CBB RID: 7355
	public GameObject DismembermentCollider;

	// Token: 0x04001CBC RID: 7356
	public Animation MyAnimation;

	// Token: 0x04001CBD RID: 7357
	public Collider ClawCollider;

	// Token: 0x04001CBE RID: 7358
	public bool Attacking;

	// Token: 0x04001CBF RID: 7359
	public bool Attacked;

	// Token: 0x04001CC0 RID: 7360
	public bool Rising = true;

	// Token: 0x04001CC1 RID: 7361
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001CC2 RID: 7362
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001CC3 RID: 7363
	public AudioClip Whoosh;

	// Token: 0x04001CC4 RID: 7364
	public float AnimSpeed = 1f;

	// Token: 0x04001CC5 RID: 7365
	public float AnimTime;
}
