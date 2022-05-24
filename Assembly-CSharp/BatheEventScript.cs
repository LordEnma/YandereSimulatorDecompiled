using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class BatheEventScript : MonoBehaviour
{
	// Token: 0x06000A11 RID: 2577 RVA: 0x00057266 File Offset: 0x00055466
	private void Start()
	{
		this.RivalPhone.SetActive(false);
		if (DateGlobals.Weekday != this.EventDay)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x00057288 File Offset: 0x00055488
	private void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[30];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
					this.EventStudent.CurrentDestination = this.StudentManager.FemaleStripSpot;
					this.EventStudent.Pathfinding.target = this.StudentManager.FemaleStripSpot;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.Pathfinding.speed = 1f;
					this.EventStudent.SpeechLines.Stop();
					this.EventStudent.DistanceToDestination = 100f;
					this.EventStudent.SmartPhone.SetActive(false);
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.InEvent = true;
					this.EventStudent.Private = true;
					this.EventStudent.Prompt.Hide();
					this.EventStudent.Hearts.Stop();
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.canMove = true;
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
			if (this.Clock.HourTime > this.EventTime + 1f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dodging || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
			{
				this.EndEvent();
				return;
			}
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				if (this.EventPhase == 1)
				{
					this.EventStudent.Routine = false;
					this.EventStudent.BathePhase = 1;
					this.EventStudent.Wet = true;
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					if (this.EventStudent.BathePhase == 4)
					{
						this.RivalPhone.SetActive(true);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3 && !this.EventStudent.Wet)
				{
					this.EndEvent();
				}
			}
			if (this.EventPhase == 4)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > this.CurrentClipLength + 1f)
				{
					this.EventStudent.Routine = true;
					this.EndEvent();
				}
			}
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
			if (num < 11f)
			{
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					return;
				}
				this.EventSubtitle.transform.localScale = Vector3.zero;
			}
		}
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x00057708 File Offset: 0x00055908
	private void EndEvent()
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
				this.EventStudent.Pathfinding.canSearch = true;
				this.EventStudent.Pathfinding.canMove = true;
				this.EventStudent.Pathfinding.speed = 1f;
				this.EventStudent.TargetDistance = 1f;
				this.EventStudent.Private = false;
			}
			this.EventStudent.InEvent = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.EventActive = false;
		base.enabled = false;
	}

	// Token: 0x04000ADE RID: 2782
	public StudentManagerScript StudentManager;

	// Token: 0x04000ADF RID: 2783
	public YandereScript Yandere;

	// Token: 0x04000AE0 RID: 2784
	public ClockScript Clock;

	// Token: 0x04000AE1 RID: 2785
	public StudentScript EventStudent;

	// Token: 0x04000AE2 RID: 2786
	public UILabel EventSubtitle;

	// Token: 0x04000AE3 RID: 2787
	public AudioClip[] EventClip;

	// Token: 0x04000AE4 RID: 2788
	public string[] EventSpeech;

	// Token: 0x04000AE5 RID: 2789
	public string[] EventAnim;

	// Token: 0x04000AE6 RID: 2790
	public GameObject RivalPhone;

	// Token: 0x04000AE7 RID: 2791
	public GameObject VoiceClip;

	// Token: 0x04000AE8 RID: 2792
	public bool EventActive;

	// Token: 0x04000AE9 RID: 2793
	public bool EventOver;

	// Token: 0x04000AEA RID: 2794
	public float EventTime = 15.1f;

	// Token: 0x04000AEB RID: 2795
	public int EventPhase = 1;

	// Token: 0x04000AEC RID: 2796
	public DayOfWeek EventDay = DayOfWeek.Thursday;

	// Token: 0x04000AED RID: 2797
	public Vector3 OriginalPosition;

	// Token: 0x04000AEE RID: 2798
	public float CurrentClipLength;

	// Token: 0x04000AEF RID: 2799
	public float Timer;
}
