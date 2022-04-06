using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class OsanaWednesdayLunchEventScript : MonoBehaviour
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x00144244 File Offset: 0x00142444
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x00144278 File Offset: 0x00142478
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null)
			{
				if (this.Rival == null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				if (this.Rival.Bullied)
				{
					base.enabled = false;
				}
				else if ((this.Clock.Period == 3 || this.Clock.Period == 6) && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless)
				{
					Debug.Log("Osana's Wednesday lunchtime event has begun.");
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location;
					this.Rival.CurrentDestination = this.Location;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Rival.EmptyHands();
					this.StartPeriod = this.Clock.Period;
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 17;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				this.Yandere.transform.position = this.Location.position + new Vector3(2f, 0f, 2f);
				this.Rival.transform.position = this.Location.position + new Vector3(1f, 0f, 1f);
			}
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText;
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if ((double)this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 1.33333)
			{
				this.Rival.SmartPhone.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if ((double)this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 6.833333)
			{
				this.Rival.SmartPhone.SetActive(false);
				this.Phase++;
			}
		}
		else if (this.Phase == 4 && this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim].length)
		{
			this.EndEvent();
		}
		if (this.Clock.Period > this.StartPeriod || this.Rival.Alarmed || this.Rival.Splashed)
		{
			this.EndEvent();
		}
		this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
		if (this.Distance - 4f < 15f)
		{
			this.Scale = Mathf.Abs(1f - (this.Distance - 4f) / 15f);
			if (this.Scale < 0f)
			{
				this.Scale = 0f;
			}
			if (this.Scale > 1f)
			{
				this.Scale = 1f;
			}
			this.Jukebox.Dip = 1f - 0.5f * this.Scale;
			this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = this.Scale;
			}
		}
		else
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
			}
		}
		if (this.VoiceClip == null)
		{
			this.EventSubtitle.text = string.Empty;
		}
	}

	// Token: 0x06001BE2 RID: 7138 RVA: 0x00144840 File Offset: 0x00142A40
	private void EndEvent()
	{
		Debug.Log("Osana's Wednesday lunchtime event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
			this.Rival.DistanceToDestination = 100f;
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x040030BD RID: 12477
	public StudentManagerScript StudentManager;

	// Token: 0x040030BE RID: 12478
	public JukeboxScript Jukebox;

	// Token: 0x040030BF RID: 12479
	public UILabel EventSubtitle;

	// Token: 0x040030C0 RID: 12480
	public YandereScript Yandere;

	// Token: 0x040030C1 RID: 12481
	public ClockScript Clock;

	// Token: 0x040030C2 RID: 12482
	public StudentScript Rival;

	// Token: 0x040030C3 RID: 12483
	public Transform Location;

	// Token: 0x040030C4 RID: 12484
	public AudioClip SpeechClip;

	// Token: 0x040030C5 RID: 12485
	public string SpeechText;

	// Token: 0x040030C6 RID: 12486
	public string EventAnim;

	// Token: 0x040030C7 RID: 12487
	public GameObject AlarmDisc;

	// Token: 0x040030C8 RID: 12488
	public GameObject VoiceClip;

	// Token: 0x040030C9 RID: 12489
	public float Distance;

	// Token: 0x040030CA RID: 12490
	public float Scale;

	// Token: 0x040030CB RID: 12491
	public DayOfWeek EventDay;

	// Token: 0x040030CC RID: 12492
	public int StartPeriod;

	// Token: 0x040030CD RID: 12493
	public int RivalID = 11;

	// Token: 0x040030CE RID: 12494
	public int Phase;

	// Token: 0x040030CF RID: 12495
	public int Frame;
}
