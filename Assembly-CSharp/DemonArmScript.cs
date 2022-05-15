using System;
using UnityEngine;

// Token: 0x0200027D RID: 637
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x0600137F RID: 4991 RVA: 0x000B3930 File Offset: 0x000B1B30
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x000B3990 File Offset: 0x000B1B90
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

	// Token: 0x06001381 RID: 4993 RVA: 0x000B3AF0 File Offset: 0x000B1CF0
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

	// Token: 0x04001CC2 RID: 7362
	public GameObject DismembermentCollider;

	// Token: 0x04001CC3 RID: 7363
	public Animation MyAnimation;

	// Token: 0x04001CC4 RID: 7364
	public Collider ClawCollider;

	// Token: 0x04001CC5 RID: 7365
	public bool Attacking;

	// Token: 0x04001CC6 RID: 7366
	public bool Attacked;

	// Token: 0x04001CC7 RID: 7367
	public bool Rising = true;

	// Token: 0x04001CC8 RID: 7368
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001CC9 RID: 7369
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001CCA RID: 7370
	public AudioClip Whoosh;

	// Token: 0x04001CCB RID: 7371
	public float AnimSpeed = 1f;

	// Token: 0x04001CCC RID: 7372
	public float AnimTime;
}
