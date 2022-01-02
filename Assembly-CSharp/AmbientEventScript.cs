using System;
using UnityEngine;

// Token: 0x020000C6 RID: 198
public class AmbientEventScript : MonoBehaviour
{
	// Token: 0x060009B2 RID: 2482 RVA: 0x0004FF44 File Offset: 0x0004E144
	private void Start()
	{
		if (this.Sitting)
		{
			if (DateGlobals.Weekday != this.EventDay || GameGlobals.Eighties)
			{
				base.enabled = false;
				return;
			}
			if (StudentGlobals.GetStudentGrudge(2) || StudentGlobals.GetStudentGrudge(3))
			{
				this.EventClip = this.GrudgeReaction.EventClip;
				this.EventSpeech = this.GrudgeReaction.EventSpeech;
				this.EventSpeaker = this.GrudgeReaction.EventSpeaker;
				return;
			}
			if (GameGlobals.PoliceYesterday)
			{
				this.EventClip = this.PoliceReaction.EventClip;
				this.EventSpeech = this.PoliceReaction.EventSpeech;
				this.EventSpeaker = this.PoliceReaction.EventSpeaker;
				return;
			}
		}
		else if (DateGlobals.Weekday != this.EventDay || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x00050014 File Offset: 0x0004E214
	private void Update()
	{
		if (!this.EventOn)
		{
			for (int i = 1; i < 3; i++)
			{
				if (this.EventStudent[i] == null)
				{
					this.EventStudent[i] = this.StudentManager.Students[this.StudentID[i]];
				}
				else if (!this.EventStudent[i].Alive || this.EventStudent[i].Slave)
				{
					base.enabled = false;
				}
			}
			if (this.Clock.HourTime > this.StartTime && this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].Indoors && this.EventStudent[2].Indoors && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[2].Pathfinding.canMove)
			{
				if (this.Sitting && this.Yandere.Hiding && this.Yandere.HidingSpot == this.HidingSpot.Spot)
				{
					this.Yandere.PromptBar.ClearButtons();
					this.Yandere.PromptBar.Show = false;
					this.Yandere.Exiting = true;
					this.HidingSpot.Prompt.enabled = false;
					this.HidingSpot.Prompt.Hide();
				}
				this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				this.EventStudent[1].CurrentDestination = this.EventLocation[1];
				this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
				this.EventStudent[1].InEvent = true;
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
				this.EventStudent[2].CurrentDestination = this.EventLocation[2];
				this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
				this.EventStudent[2].InEvent = true;
				if (this.StartTime > 16f)
				{
					this.Yandere.PauseScreen.Hint.QuickID = 49;
					this.Yandere.PauseScreen.Hint.Show = true;
				}
				this.EventOn = true;
				return;
			}
		}
		else
		{
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventLocation[1].parent.position);
			if (this.Clock.HourTime > this.StartTime + 0.5f || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.Yandere.Noticed)
			{
				this.EndEvent();
				return;
			}
			for (int j = 1; j < 3; j++)
			{
				if (!this.EventStudent[j].Pathfinding.canMove && !this.EventStudent[j].Private)
				{
					this.EventStudent[j].Character.GetComponent<Animation>().CrossFade(this.EventStudent[j].IdleAnim);
					this.EventStudent[j].Private = true;
					this.StudentManager.UpdateStudents(0);
				}
			}
			if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
			{
				if (this.Sitting)
				{
					this.EventStudent[1].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.EventStudent[1].CharacterAnimation[this.EventStudent[1].SocialSitAnim].layer = 99;
					this.EventStudent[1].CharacterAnimation.Play(this.EventStudent[1].SocialSitAnim);
					this.EventStudent[1].CharacterAnimation[this.EventStudent[1].SocialSitAnim].weight = 1f;
					this.EventStudent[2].CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.EventStudent[2].CharacterAnimation[this.EventStudent[2].SocialSitAnim].layer = 99;
					this.EventStudent[2].CharacterAnimation.Play(this.EventStudent[2].SocialSitAnim);
					this.EventStudent[2].CharacterAnimation[this.EventStudent[2].SocialSitAnim].weight = 1f;
					this.EventStudent[1].MyController.radius = 0f;
					this.EventStudent[2].MyController.radius = 0f;
					this.RotateSpine = true;
				}
				if (!this.Spoken)
				{
					if (this.Sitting)
					{
						this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade("f02_benchSit_00");
						this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade("f02_benchSit_00");
					}
					else
					{
						this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
						this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
					}
					this.EventStudent[this.EventSpeaker[this.EventPhase]].PickRandomAnim();
					this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].RandomAnim);
					if (!this.Sitting && this.StartTime < 16f && DateGlobals.Weekday == DayOfWeek.Monday && this.EventPhase == 13)
					{
						this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade("jojoPose_00");
					}
					AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Spoken = true;
				}
				else
				{
					int num2 = this.EventSpeaker[this.EventPhase];
					if (this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].time >= this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].length)
					{
						this.EventStudent[num2].PickRandomAnim();
						this.EventStudent[num2].CharacterAnimation.CrossFade(this.EventStudent[num2].RandomAnim);
					}
					this.Timer += Time.deltaTime;
					if (this.Yandere.transform.position.y > this.EventLocation[1].parent.position.y - 1f && this.Yandere.transform.position.y < this.EventLocation[1].parent.position.y + 1f)
					{
						if (this.VoiceClip != null)
						{
							this.VoiceClip.GetComponent<AudioSource>().volume = 1f;
						}
						if (num < 10f)
						{
							if (this.Timer > this.EventClip[this.EventPhase].length)
							{
								this.EventSubtitle.text = string.Empty;
							}
							else
							{
								this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
							}
							this.Scale = Mathf.Abs((num - 10f) * 0.2f);
							if (this.Scale < 0f)
							{
								this.Scale = 0f;
							}
							if (this.Scale > 1f)
							{
								this.Scale = 1f;
							}
							this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
						}
						else if (num < 11f)
						{
							this.EventSubtitle.transform.localScale = Vector3.zero;
							this.EventSubtitle.text = string.Empty;
						}
					}
					else if (this.VoiceClip != null)
					{
						this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
					}
					if (this.Timer > this.EventClip[this.EventPhase].length + this.Delay)
					{
						this.Spoken = false;
						this.EventPhase++;
						this.Timer = 0f;
						if (this.EventPhase == this.EventSpeech.Length)
						{
							this.EndEvent();
						}
					}
				}
				if (this.Private)
				{
					if (num < 5f)
					{
						this.Yandere.Eavesdropping = true;
						return;
					}
					this.Yandere.Eavesdropping = false;
				}
			}
		}
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x00050988 File Offset: 0x0004EB88
	private void LateUpdate()
	{
		if (this.RotateSpine)
		{
			this.EventStudent[1].Head.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			this.EventStudent[1].Neck.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			this.EventStudent[1].Spine.transform.localEulerAngles += new Vector3(0f, 15f, 0f);
			this.EventStudent[1].LeftEye.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
			this.EventStudent[1].RightEye.transform.localEulerAngles += new Vector3(0f, 5f, 0f);
			this.EventStudent[2].Head.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			this.EventStudent[2].Neck.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			this.EventStudent[2].Spine.transform.localEulerAngles += new Vector3(0f, -15f, 0f);
			this.EventStudent[2].LeftEye.transform.localEulerAngles += new Vector3(0f, -5f, 0f);
			this.EventStudent[2].RightEye.transform.localEulerAngles += new Vector3(0f, -5f, 0f);
			this.MouthTimer += Time.deltaTime;
			if (this.MouthTimer > this.TimerLimit)
			{
				this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
				this.MouthTimer = 0f;
			}
			Transform jaw = this.EventStudent[this.EventSpeaker[this.EventPhase]].Jaw;
			Transform lipL = this.EventStudent[this.EventSpeaker[this.EventPhase]].LipL;
			Transform lipR = this.EventStudent[this.EventSpeaker[this.EventPhase]].LipR;
			jaw.localEulerAngles = new Vector3(jaw.localEulerAngles.x, jaw.localEulerAngles.y, Mathf.Lerp(jaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
			lipL.localPosition = new Vector3(lipL.localPosition.x, Mathf.Lerp(lipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), lipL.localPosition.z);
			lipR.localPosition = new Vector3(lipR.localPosition.x, Mathf.Lerp(lipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), lipR.localPosition.z);
		}
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x00050D34 File Offset: 0x0004EF34
	public void EndEvent()
	{
		Debug.Log("An Ambient Event named " + base.gameObject.name + " has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		for (int i = 1; i < 3; i++)
		{
			this.EventStudent[i].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.EventStudent[i].CharacterAnimation.Stop(this.EventStudent[i].SocialSitAnim);
			this.EventStudent[1].MyController.radius = 0.1f;
			if (this.EventStudent[i].Meeting && this.EventStudent[i].Clock.HourTime > this.EventStudent[i].MeetTime)
			{
				this.EventStudent[i].CurrentDestination = this.EventStudent[i].MeetSpot;
				this.EventStudent[i].Pathfinding.target = this.EventStudent[i].MeetSpot;
				this.EventStudent[i].DistanceToDestination = Vector3.Distance(base.transform.position, this.EventStudent[i].CurrentDestination.position);
				this.EventStudent[i].Pathfinding.canSearch = true;
				this.EventStudent[i].Pathfinding.canMove = true;
				this.EventStudent[i].Pathfinding.speed = 4f;
				this.EventStudent[i].SpeechLines.Stop();
				this.EventStudent[i].EmptyHands();
				this.EventStudent[i].Meeting = true;
				this.EventStudent[i].MeetTime = 0f;
			}
			else
			{
				this.EventStudent[i].CurrentDestination = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
				this.EventStudent[i].Pathfinding.target = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
			}
			this.EventStudent[i].InEvent = false;
			this.EventStudent[i].Private = false;
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		if (this.HidingSpot != null)
		{
			this.HidingSpot.Prompt.enabled = true;
		}
		this.EventSubtitle.text = string.Empty;
		this.Yandere.Eavesdropping = false;
		base.enabled = false;
	}

	// Token: 0x040008BE RID: 2238
	public StudentManagerScript StudentManager;

	// Token: 0x040008BF RID: 2239
	public AmbientEventScript GrudgeReaction;

	// Token: 0x040008C0 RID: 2240
	public AmbientEventScript PoliceReaction;

	// Token: 0x040008C1 RID: 2241
	public HidingSpotScript HidingSpot;

	// Token: 0x040008C2 RID: 2242
	public UILabel EventSubtitle;

	// Token: 0x040008C3 RID: 2243
	public YandereScript Yandere;

	// Token: 0x040008C4 RID: 2244
	public ClockScript Clock;

	// Token: 0x040008C5 RID: 2245
	public StudentScript[] EventStudent;

	// Token: 0x040008C6 RID: 2246
	public Transform[] EventLocation;

	// Token: 0x040008C7 RID: 2247
	public AudioClip[] EventClip;

	// Token: 0x040008C8 RID: 2248
	public string[] EventSpeech;

	// Token: 0x040008C9 RID: 2249
	public string[] EventAnim;

	// Token: 0x040008CA RID: 2250
	public int[] EventSpeaker;

	// Token: 0x040008CB RID: 2251
	public GameObject VoiceClip;

	// Token: 0x040008CC RID: 2252
	public bool RotateSpine;

	// Token: 0x040008CD RID: 2253
	public bool Sitting;

	// Token: 0x040008CE RID: 2254
	public bool EventOn;

	// Token: 0x040008CF RID: 2255
	public bool Spoken;

	// Token: 0x040008D0 RID: 2256
	public bool Private;

	// Token: 0x040008D1 RID: 2257
	public int EventPhase;

	// Token: 0x040008D2 RID: 2258
	public float StartTime = 13.001f;

	// Token: 0x040008D3 RID: 2259
	public float Delay = 0.5f;

	// Token: 0x040008D4 RID: 2260
	public float Timer;

	// Token: 0x040008D5 RID: 2261
	public float Scale;

	// Token: 0x040008D6 RID: 2262
	public int[] StudentID;

	// Token: 0x040008D7 RID: 2263
	public DayOfWeek EventDay;

	// Token: 0x040008D8 RID: 2264
	public float MouthTimer;

	// Token: 0x040008D9 RID: 2265
	public float MouthTarget;

	// Token: 0x040008DA RID: 2266
	public float MouthExtent;

	// Token: 0x040008DB RID: 2267
	public float TimerLimit = 0.1f;

	// Token: 0x040008DC RID: 2268
	public float TalkSpeed;

	// Token: 0x040008DD RID: 2269
	public float LipStrength;
}
