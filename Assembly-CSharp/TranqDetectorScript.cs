using System;
using UnityEngine;

// Token: 0x02000481 RID: 1153
public class TranqDetectorScript : MonoBehaviour
{
	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B277E File Offset: 0x001B097E
	private void Start()
	{
		this.Checklist.alpha = 0f;
		this.BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B279C File Offset: 0x001B099C
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

	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B2A34 File Offset: 0x001B0C34
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

	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B2BAC File Offset: 0x001B0DAC
	public void GarroteAttack()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
		component.Play();
		this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		this.Yandere.AttackManager.Stealth = true;
		this.StopChecking = true;
	}

	// Token: 0x0400403B RID: 16443
	public YandereScript Yandere;

	// Token: 0x0400403C RID: 16444
	public DoorScript Door;

	// Token: 0x0400403D RID: 16445
	public UIPanel Checklist;

	// Token: 0x0400403E RID: 16446
	public Collider MyCollider;

	// Token: 0x0400403F RID: 16447
	public UILabel KidnappingLabel;

	// Token: 0x04004040 RID: 16448
	public UISprite TranquilizerIcon;

	// Token: 0x04004041 RID: 16449
	public UISprite FollowerIcon;

	// Token: 0x04004042 RID: 16450
	public UISprite BiologyIcon;

	// Token: 0x04004043 RID: 16451
	public UISprite SyringeIcon;

	// Token: 0x04004044 RID: 16452
	public UISprite DoorIcon;

	// Token: 0x04004045 RID: 16453
	public bool StopChecking;

	// Token: 0x04004046 RID: 16454
	public bool CannotKidnap;

	// Token: 0x04004047 RID: 16455
	public int BasementPrisoner;

	// Token: 0x04004048 RID: 16456
	public AudioClip[] TranqClips;
}
