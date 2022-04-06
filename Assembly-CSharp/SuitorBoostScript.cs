using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class SuitorBoostScript : MonoBehaviour
{
	// Token: 0x06001E99 RID: 7833 RVA: 0x001A6EA4 File Offset: 0x001A50A4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				if (!this.TaughtSuitor)
				{
					if (this.Yandere.Followers > 0 && this.Yandere.Follower.StudentID == this.LoveManager.SuitorID && this.Yandere.Follower.DistanceToPlayer < 2f)
					{
						this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
						this.Yandere.RPGCamera.enabled = false;
						this.Yandere.CanMove = false;
						this.Yandere.Follower.CharacterAnimation.CrossFade(this.Yandere.Follower.IdleAnim);
						this.Yandere.Follower.Pathfinding.canSearch = false;
						this.Yandere.Follower.Pathfinding.canMove = false;
						this.Yandere.Follower.enabled = false;
						this.Darkness.enabled = true;
						this.Boosting = true;
						this.FadeOut = true;
						this.Label.text = this.BoostText;
					}
					else
					{
						this.Yandere.NotificationManager.CustomText = "your rival and bring him here.";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						this.Yandere.NotificationManager.CustomText = "Find a boy who has a crush on";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.Yandere.NotificationManager.CustomText = "Can't! You already did that today!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else
			{
				this.Yandere.NotificationManager.CustomText = "Can't! You're being chased!";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (this.Boosting)
		{
			if (this.FadeOut)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						if (this.Phase == 1)
						{
							this.Yandere.MainCamera.transform.position = this.BoostSpot.position;
							this.Yandere.MainCamera.transform.eulerAngles = this.BoostSpot.eulerAngles;
							this.Yandere.Follower.Character.transform.localScale = new Vector3(1f, 1f, 1f);
							if (this.TraitID == 1)
							{
								this.Yandere.Follower.CharacterAnimation.Play("paranoidIdle_00");
								this.Yandere.transform.position = this.YandereSpot.position;
								this.Yandere.transform.eulerAngles = this.YandereSpot.eulerAngles;
								this.Yandere.Follower.transform.position = this.SuitorSpot.position;
								this.Yandere.Follower.transform.eulerAngles = this.SuitorSpot.eulerAngles;
							}
							else if (this.TraitID == 2)
							{
								this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.6f);
								this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.6f);
								this.Yandere.CharacterAnimation.Play("f02_sit_01");
								this.Yandere.Follower.CharacterAnimation.Play("sit_01");
								this.Yandere.transform.eulerAngles = Vector3.zero;
								this.Yandere.Follower.transform.eulerAngles = Vector3.zero;
								this.Yandere.transform.position = this.YandereSitSpot.position;
								this.Yandere.Follower.transform.position = this.SuitorSitSpot.position;
							}
							else if (this.TraitID == 3)
							{
								this.Yandere.Follower.CharacterAnimation.Play("stretch_00");
								this.Yandere.transform.position = this.YandereSpot.position;
								this.Yandere.transform.eulerAngles = this.YandereSpot.eulerAngles;
								this.Yandere.Follower.transform.position = this.SuitorSpot.position;
								this.Yandere.Follower.transform.eulerAngles = this.SuitorSpot.eulerAngles;
							}
						}
						else
						{
							this.Yandere.FixCamera();
							this.Yandere.Follower.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
							if (this.TraitID == 2)
							{
								this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.33333334f);
								this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.33333334f);
							}
							this.Yandere.CharacterAnimation.Play(this.Yandere.IdleAnim);
							this.Yandere.Follower.CharacterAnimation.Play(this.Yandere.Follower.IdleAnim);
							this.Yandere.transform.position = this.YandereSpot.position;
							this.Yandere.Follower.transform.position = this.SuitorSpot.position;
						}
						this.PromptBar.ClearButtons();
						this.FadeOut = false;
						this.Phase++;
						return;
					}
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					if (this.Phase == 2)
					{
						this.TextBox.gameObject.SetActive(true);
						this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
						if (this.TextBox.localScale.x > 0.9f)
						{
							if (!this.PromptBar.Show)
							{
								this.PromptBar.ClearButtons();
								this.PromptBar.Label[0].text = "Continue";
								this.PromptBar.UpdateButtons();
								this.PromptBar.Show = true;
							}
							if (Input.GetButtonDown("A"))
							{
								this.PromptBar.Show = false;
								this.Phase++;
								return;
							}
						}
					}
					else if (this.Phase == 3)
					{
						if (this.TextBox.localScale.x > 0.1f)
						{
							this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, Vector3.zero, Time.deltaTime * 10f);
							return;
						}
						this.TextBox.gameObject.SetActive(false);
						this.FadeOut = true;
						this.Phase++;
						return;
					}
					else if (this.Phase == 5)
					{
						this.Yandere.StudentManager.DatingMinigame.DataNeedsSaving = true;
						this.Yandere.StudentManager.DatingMinigame.Trait[this.TraitID]++;
						if (this.TraitID == 1)
						{
							this.Yandere.StudentManager.DatingMinigame.CourageTrait++;
						}
						else if (this.TraitID == 2)
						{
							this.Yandere.StudentManager.DatingMinigame.WisdomTrait++;
						}
						else if (this.TraitID == 3)
						{
							this.Yandere.StudentManager.DatingMinigame.StrengthTrait++;
						}
						this.Yandere.RPGCamera.enabled = true;
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Boosting = false;
						this.Yandere.Follower.Pathfinding.canSearch = true;
						this.Yandere.Follower.Pathfinding.canMove = true;
						this.Yandere.Follower.enabled = true;
						this.TaughtSuitor = true;
					}
				}
			}
		}
	}

	// Token: 0x06001E9A RID: 7834 RVA: 0x001A78D0 File Offset: 0x001A5AD0
	private void LateUpdate()
	{
		if (this.TraitID == 2 && this.Boosting && this.Phase > 1 && this.Phase < 5)
		{
			this.Yandere.Head.LookAt(this.LookTarget);
			this.Yandere.Follower.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04003EEB RID: 16107
	public LoveManagerScript LoveManager;

	// Token: 0x04003EEC RID: 16108
	public PromptBarScript PromptBar;

	// Token: 0x04003EED RID: 16109
	public YandereScript Yandere;

	// Token: 0x04003EEE RID: 16110
	public PromptScript Prompt;

	// Token: 0x04003EEF RID: 16111
	public UISprite Darkness;

	// Token: 0x04003EF0 RID: 16112
	public UILabel Label;

	// Token: 0x04003EF1 RID: 16113
	public Transform YandereSitSpot;

	// Token: 0x04003EF2 RID: 16114
	public Transform SuitorSitSpot;

	// Token: 0x04003EF3 RID: 16115
	public Transform YandereChair;

	// Token: 0x04003EF4 RID: 16116
	public Transform SuitorChair;

	// Token: 0x04003EF5 RID: 16117
	public Transform YandereSpot;

	// Token: 0x04003EF6 RID: 16118
	public Transform SuitorSpot;

	// Token: 0x04003EF7 RID: 16119
	public Transform LookTarget;

	// Token: 0x04003EF8 RID: 16120
	public Transform TextBox;

	// Token: 0x04003EF9 RID: 16121
	public Transform BoostSpot;

	// Token: 0x04003EFA RID: 16122
	public bool TaughtSuitor;

	// Token: 0x04003EFB RID: 16123
	public bool TimeSkipping;

	// Token: 0x04003EFC RID: 16124
	public bool Boosting;

	// Token: 0x04003EFD RID: 16125
	public bool FadeOut;

	// Token: 0x04003EFE RID: 16126
	public float Timer;

	// Token: 0x04003EFF RID: 16127
	public string BoostText;

	// Token: 0x04003F00 RID: 16128
	public int TraitID = 2;

	// Token: 0x04003F01 RID: 16129
	public int Phase = 1;
}
