using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TranqDetectorScript : MonoBehaviour
{
	// Token: 0x06001F14 RID: 7956 RVA: 0x001B6D06 File Offset: 0x001B4F06
	private void Start()
	{
		this.Checklist.alpha = 0f;
		this.BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x001B6D24 File Offset: 0x001B4F24
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

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B6FBC File Offset: 0x001B51BC
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

	// Token: 0x06001F17 RID: 7959 RVA: 0x001B7134 File Offset: 0x001B5334
	public void GarroteAttack()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
		component.Play();
		this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		this.Yandere.AttackManager.Stealth = true;
		this.StopChecking = true;
	}

	// Token: 0x040040E6 RID: 16614
	public YandereScript Yandere;

	// Token: 0x040040E7 RID: 16615
	public DoorScript Door;

	// Token: 0x040040E8 RID: 16616
	public UIPanel Checklist;

	// Token: 0x040040E9 RID: 16617
	public Collider MyCollider;

	// Token: 0x040040EA RID: 16618
	public UILabel KidnappingLabel;

	// Token: 0x040040EB RID: 16619
	public UISprite TranquilizerIcon;

	// Token: 0x040040EC RID: 16620
	public UISprite FollowerIcon;

	// Token: 0x040040ED RID: 16621
	public UISprite BiologyIcon;

	// Token: 0x040040EE RID: 16622
	public UISprite SyringeIcon;

	// Token: 0x040040EF RID: 16623
	public UISprite DoorIcon;

	// Token: 0x040040F0 RID: 16624
	public bool StopChecking;

	// Token: 0x040040F1 RID: 16625
	public bool CannotKidnap;

	// Token: 0x040040F2 RID: 16626
	public int BasementPrisoner;

	// Token: 0x040040F3 RID: 16627
	public AudioClip[] TranqClips;
}
