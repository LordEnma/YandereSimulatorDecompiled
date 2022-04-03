using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x06001379 RID: 4985 RVA: 0x000B30C8 File Offset: 0x000B12C8
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x0600137A RID: 4986 RVA: 0x000B3128 File Offset: 0x000B1328
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

	// Token: 0x0600137B RID: 4987 RVA: 0x000B3288 File Offset: 0x000B1488
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

	// Token: 0x04001CB2 RID: 7346
	public GameObject DismembermentCollider;

	// Token: 0x04001CB3 RID: 7347
	public Animation MyAnimation;

	// Token: 0x04001CB4 RID: 7348
	public Collider ClawCollider;

	// Token: 0x04001CB5 RID: 7349
	public bool Attacking;

	// Token: 0x04001CB6 RID: 7350
	public bool Attacked;

	// Token: 0x04001CB7 RID: 7351
	public bool Rising = true;

	// Token: 0x04001CB8 RID: 7352
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001CB9 RID: 7353
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001CBA RID: 7354
	public AudioClip Whoosh;

	// Token: 0x04001CBB RID: 7355
	public float AnimSpeed = 1f;

	// Token: 0x04001CBC RID: 7356
	public float AnimTime;
}
