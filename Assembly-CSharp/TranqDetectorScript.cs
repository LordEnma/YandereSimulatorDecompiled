using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TranqDetectorScript : MonoBehaviour
{
	// Token: 0x06001F2C RID: 7980 RVA: 0x001B9052 File Offset: 0x001B7252
	private void Start()
	{
		this.Checklist.alpha = 0f;
		this.BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x001B9070 File Offset: 0x001B7270
	private void Update()
	{
		if (!this.StopChecking)
		{
			if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
			{
				if (this.BasementPrisoner > 0)
				{
					this.KidnappingLabel.text = "There is no room for another prisoner in your basement.";
					this.CannotKidnap = true;
				}
				else
				{
					if (this.Yandere.Inventory.Tranquilizer || this.Yandere.Inventory.Sedative)
					{
						this.TranquilizerIcon.spriteName = "Yes";
					}
					else
					{
						this.TranquilizerIcon.spriteName = "No";
					}
					if (this.Yandere.Followers != 1)
					{
						this.FollowerIcon.spriteName = "No";
					}
					else if (this.Yandere.Follower.Male)
					{
						this.KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
						this.FollowerIcon.spriteName = "No";
						this.CannotKidnap = true;
					}
					else
					{
						this.KidnappingLabel.text = "Kidnapping Checklist";
						this.FollowerIcon.spriteName = "Yes";
						this.CannotKidnap = false;
					}
					this.BiologyIcon.spriteName = ((this.Yandere.Class.BiologyGrade + this.Yandere.Class.BiologyBonus != 0) ? "Yes" : "No");
					if (!this.Yandere.Armed)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else if (this.Yandere.EquippedWeapon.WeaponID != 3)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else
					{
						this.SyringeIcon.spriteName = "Yes";
					}
					if (this.Door.Open || this.Door.Timer < 1f)
					{
						this.DoorIcon.spriteName = "No";
					}
					else
					{
						this.DoorIcon.spriteName = "Yes";
					}
				}
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 1f, Time.deltaTime);
				return;
			}
			if (this.Checklist.alpha != 0f)
			{
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
				return;
			}
		}
		else
		{
			this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
			if (this.Checklist.alpha == 0f)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x001B9308 File Offset: 0x001B7508
	public void TranqCheck()
	{
		if (!this.StopChecking && !this.CannotKidnap && this.TranquilizerIcon.spriteName == "Yes" && this.FollowerIcon.spriteName == "Yes" && this.BiologyIcon.spriteName == "Yes" && this.SyringeIcon.spriteName == "Yes" && this.DoorIcon.spriteName == "Yes")
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
			component.Play();
			this.Door.Prompt.Hide();
			this.Door.Prompt.enabled = false;
			this.Door.enabled = false;
			if (this.Yandere.Inventory.Tranquilizer)
			{
				this.Yandere.Inventory.Tranquilizer = false;
			}
			else
			{
				this.Yandere.Inventory.Sedative = false;
			}
			if (!this.Yandere.Follower.Male)
			{
				this.Yandere.CanTranq = true;
			}
			this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
			this.Yandere.AttackManager.Stealth = true;
			this.StopChecking = true;
		}
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x001B9480 File Offset: 0x001B7680
	public void GarroteAttack()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
		component.Play();
		this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		this.Yandere.AttackManager.Stealth = true;
		this.StopChecking = true;
	}

	// Token: 0x0400410F RID: 16655
	public YandereScript Yandere;

	// Token: 0x04004110 RID: 16656
	public DoorScript Door;

	// Token: 0x04004111 RID: 16657
	public UIPanel Checklist;

	// Token: 0x04004112 RID: 16658
	public Collider MyCollider;

	// Token: 0x04004113 RID: 16659
	public UILabel KidnappingLabel;

	// Token: 0x04004114 RID: 16660
	public UISprite TranquilizerIcon;

	// Token: 0x04004115 RID: 16661
	public UISprite FollowerIcon;

	// Token: 0x04004116 RID: 16662
	public UISprite BiologyIcon;

	// Token: 0x04004117 RID: 16663
	public UISprite SyringeIcon;

	// Token: 0x04004118 RID: 16664
	public UISprite DoorIcon;

	// Token: 0x04004119 RID: 16665
	public bool StopChecking;

	// Token: 0x0400411A RID: 16666
	public bool CannotKidnap;

	// Token: 0x0400411B RID: 16667
	public int BasementPrisoner;

	// Token: 0x0400411C RID: 16668
	public AudioClip[] TranqClips;
}
