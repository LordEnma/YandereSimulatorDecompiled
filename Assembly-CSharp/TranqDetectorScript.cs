using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TranqDetectorScript : MonoBehaviour
{
	// Token: 0x06001EC6 RID: 7878 RVA: 0x001AF6C6 File Offset: 0x001AD8C6
	private void Start()
	{
		this.Checklist.alpha = 0f;
		this.BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	// Token: 0x06001EC7 RID: 7879 RVA: 0x001AF6E4 File Offset: 0x001AD8E4
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

	// Token: 0x06001EC8 RID: 7880 RVA: 0x001AF97C File Offset: 0x001ADB7C
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

	// Token: 0x06001EC9 RID: 7881 RVA: 0x001AFAF4 File Offset: 0x001ADCF4
	public void GarroteAttack()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
		component.Play();
		this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		this.Yandere.AttackManager.Stealth = true;
		this.StopChecking = true;
	}

	// Token: 0x04003FDB RID: 16347
	public YandereScript Yandere;

	// Token: 0x04003FDC RID: 16348
	public DoorScript Door;

	// Token: 0x04003FDD RID: 16349
	public UIPanel Checklist;

	// Token: 0x04003FDE RID: 16350
	public Collider MyCollider;

	// Token: 0x04003FDF RID: 16351
	public UILabel KidnappingLabel;

	// Token: 0x04003FE0 RID: 16352
	public UISprite TranquilizerIcon;

	// Token: 0x04003FE1 RID: 16353
	public UISprite FollowerIcon;

	// Token: 0x04003FE2 RID: 16354
	public UISprite BiologyIcon;

	// Token: 0x04003FE3 RID: 16355
	public UISprite SyringeIcon;

	// Token: 0x04003FE4 RID: 16356
	public UISprite DoorIcon;

	// Token: 0x04003FE5 RID: 16357
	public bool StopChecking;

	// Token: 0x04003FE6 RID: 16358
	public bool CannotKidnap;

	// Token: 0x04003FE7 RID: 16359
	public int BasementPrisoner;

	// Token: 0x04003FE8 RID: 16360
	public AudioClip[] TranqClips;
}
