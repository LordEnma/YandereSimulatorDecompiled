using System;
using UnityEngine;

// Token: 0x02000485 RID: 1157
public class ToiletEventScript : MonoBehaviour
{
	// Token: 0x06001F1E RID: 7966 RVA: 0x001B91B5 File Offset: 0x001B73B5
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == this.EventDay)
		{
			this.EventCheck = true;
		}
	}

	// Token: 0x06001F1F RID: 7967 RVA: 0x001B91E0 File Offset: 0x001B73E0
	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[30];
			if (this.EventStudent != null && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Alarmed && !this.EventStudent.Meeting)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.CurrentDestination = this.EventLocation[1];
					this.EventStudent.Pathfinding.target = this.EventLocation[1];
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.LightSwitch = this.LightSwitch;
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.SpeechLines.Stop();
					this.EventStudent.ToiletEvent = this;
					this.EventStudent.InEvent = true;
					this.EventStudent.Prompt.Hide();
					this.Prompt.enabled = true;
					this.EventCheck = false;
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.speed = 1f;
						this.EventStudent.Following = false;
						this.EventStudent.Routine = true;
						this.Yandere.Follower = null;
						this.Yandere.Followers--;
						this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
						this.EventStudent.Prompt.Label[0].text = "     Talk";
					}
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Yandere.EmptyHands();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.EventPhase = 5;
				this.Timer = 0f;
				AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
				this.EventSubtitle.text = this.EventSpeech[1];
				this.EventStudent.MyController.enabled = false;
				this.EventStudent.Distracted = true;
				this.EventStudent.Routine = false;
				this.EventStudent.Drowned = true;
				this.Yandere.TargetStudent = this.EventStudent;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Drown = true;
				this.Yandere.DrownAnim = "f02_toiletDrownA_00";
				this.EventStudent.DrownAnim = "f02_toiletDrownB_00";
				this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.DrownAnim);
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dying || this.EventStudent.Alarmed)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					if (this.Timer == 0f)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
						this.Prompt.HideButton[0] = false;
						this.EventStudent.Prompt.Hide();
						this.EventStudent.Prompt.enabled = false;
						this.StallDoor.Prompt.enabled = false;
						this.StallDoor.Prompt.Hide();
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 3f)
					{
						this.StallDoor.Locked = true;
						this.StallDoor.CloseDoor();
						this.Toilet.enabled = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.EventStudent.CurrentDestination = this.EventLocation[2];
						this.EventStudent.Pathfinding.target = this.EventLocation[2];
						this.EventStudent.TargetDistance = 2f;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 2)
				{
					if (this.Timer == 0f)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[1]);
						this.BucketPour.enabled = true;
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 10f)
					{
						AudioClipPlayer.Play(this.EventClip[2], this.Toilet.transform.position, 5f, 10f, out this.VoiceClip);
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 3)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 4f)
					{
						this.EventStudent.CurrentDestination = this.EventLocation[3];
						this.EventStudent.Pathfinding.target = this.EventLocation[3];
						this.EventStudent.TargetDistance = 2f;
						this.StallDoor.gameObject.SetActive(true);
						this.StallDoor.Prompt.enabled = true;
						this.StallDoor.Locked = false;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_washHands_00");
					this.Timer += Time.deltaTime;
					if (this.Timer > 5f)
					{
						this.EndEvent();
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 9f)
					{
						this.Splashes.Stop();
						this.EventOver = true;
						this.EndEvent();
					}
					else if (this.Timer > 3f)
					{
						this.EventSubtitle.text = string.Empty;
						this.Splashes.Play();
					}
				}
				this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (this.Distance < 10f)
				{
					float num = Mathf.Abs((this.Distance - 10f) * 0.2f);
					if (num < 0f)
					{
						num = 0f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
				}
				else
				{
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		if (this.ToiletCountdown > 0f)
		{
			this.ToiletCountdown -= Time.deltaTime;
			if (this.ToiletCountdown < 0f)
			{
				this.Toilet.enabled = true;
			}
		}
	}

	// Token: 0x06001F20 RID: 7968 RVA: 0x001B9A0C File Offset: 0x001B7C0C
	public void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			this.EventStudent.TargetDistance = 1f;
			this.EventStudent.ToiletEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.StallDoor.gameObject.SetActive(true);
		this.StallDoor.Prompt.enabled = true;
		this.StallDoor.Locked = false;
		this.BucketPour.enabled = false;
		this.BucketPour.Prompt.Hide();
		this.BucketPour.Prompt.enabled = false;
		this.EventActive = false;
		this.EventCheck = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.ToiletCountdown = 1f;
	}

	// Token: 0x040040EE RID: 16622
	public StudentManagerScript StudentManager;

	// Token: 0x040040EF RID: 16623
	public LightSwitchScript LightSwitch;

	// Token: 0x040040F0 RID: 16624
	public BucketPourScript BucketPour;

	// Token: 0x040040F1 RID: 16625
	public ParticleSystem Splashes;

	// Token: 0x040040F2 RID: 16626
	public UILabel EventSubtitle;

	// Token: 0x040040F3 RID: 16627
	public YandereScript Yandere;

	// Token: 0x040040F4 RID: 16628
	public DoorScript StallDoor;

	// Token: 0x040040F5 RID: 16629
	public PromptScript Prompt;

	// Token: 0x040040F6 RID: 16630
	public ClockScript Clock;

	// Token: 0x040040F7 RID: 16631
	public Collider Toilet;

	// Token: 0x040040F8 RID: 16632
	public StudentScript EventStudent;

	// Token: 0x040040F9 RID: 16633
	public Transform[] EventLocation;

	// Token: 0x040040FA RID: 16634
	public AudioClip[] EventClip;

	// Token: 0x040040FB RID: 16635
	public string[] EventSpeech;

	// Token: 0x040040FC RID: 16636
	public string[] EventAnim;

	// Token: 0x040040FD RID: 16637
	public GameObject VoiceClip;

	// Token: 0x040040FE RID: 16638
	public bool EventActive;

	// Token: 0x040040FF RID: 16639
	public bool EventCheck;

	// Token: 0x04004100 RID: 16640
	public bool EventOver;

	// Token: 0x04004101 RID: 16641
	public float EventTime = 7f;

	// Token: 0x04004102 RID: 16642
	public int EventPhase = 1;

	// Token: 0x04004103 RID: 16643
	public DayOfWeek EventDay = DayOfWeek.Thursday;

	// Token: 0x04004104 RID: 16644
	public float ToiletCountdown;

	// Token: 0x04004105 RID: 16645
	public float Distance;

	// Token: 0x04004106 RID: 16646
	public float Timer;
}
