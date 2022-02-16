using System;
using UnityEngine;

// Token: 0x02000460 RID: 1120
public class SuitorBoostScript : MonoBehaviour
{
	// Token: 0x06001E6B RID: 7787 RVA: 0x001A2D88 File Offset: 0x001A0F88
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

	// Token: 0x06001E6C RID: 7788 RVA: 0x001A37B4 File Offset: 0x001A19B4
	private void LateUpdate()
	{
		if (this.TraitID == 2 && this.Boosting && this.Phase > 1 && this.Phase < 5)
		{
			this.Yandere.Head.LookAt(this.LookTarget);
			this.Yandere.Follower.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04003E4C RID: 15948
	public LoveManagerScript LoveManager;

	// Token: 0x04003E4D RID: 15949
	public PromptBarScript PromptBar;

	// Token: 0x04003E4E RID: 15950
	public YandereScript Yandere;

	// Token: 0x04003E4F RID: 15951
	public PromptScript Prompt;

	// Token: 0x04003E50 RID: 15952
	public UISprite Darkness;

	// Token: 0x04003E51 RID: 15953
	public UILabel Label;

	// Token: 0x04003E52 RID: 15954
	public Transform YandereSitSpot;

	// Token: 0x04003E53 RID: 15955
	public Transform SuitorSitSpot;

	// Token: 0x04003E54 RID: 15956
	public Transform YandereChair;

	// Token: 0x04003E55 RID: 15957
	public Transform SuitorChair;

	// Token: 0x04003E56 RID: 15958
	public Transform YandereSpot;

	// Token: 0x04003E57 RID: 15959
	public Transform SuitorSpot;

	// Token: 0x04003E58 RID: 15960
	public Transform LookTarget;

	// Token: 0x04003E59 RID: 15961
	public Transform TextBox;

	// Token: 0x04003E5A RID: 15962
	public Transform BoostSpot;

	// Token: 0x04003E5B RID: 15963
	public bool TaughtSuitor;

	// Token: 0x04003E5C RID: 15964
	public bool TimeSkipping;

	// Token: 0x04003E5D RID: 15965
	public bool Boosting;

	// Token: 0x04003E5E RID: 15966
	public bool FadeOut;

	// Token: 0x04003E5F RID: 15967
	public float Timer;

	// Token: 0x04003E60 RID: 15968
	public string BoostText;

	// Token: 0x04003E61 RID: 15969
	public int TraitID = 2;

	// Token: 0x04003E62 RID: 15970
	public int Phase = 1;
}
