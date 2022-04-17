using System;
using UnityEngine;

// Token: 0x020003E1 RID: 993
public class OsanaFridayBeforeClassEvent1Script : MonoBehaviour
{
	// Token: 0x06001BB5 RID: 7093 RVA: 0x0013B344 File Offset: 0x00139544
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || StudentGlobals.StudentSlave == this.RivalID || this.StudentManager.RivalEliminated || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		this.Yoogle.SetActive(false);
	}

	// Token: 0x06001BB6 RID: 7094 RVA: 0x0013B3A8 File Offset: 0x001395A8
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
				if (this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless && this.Rival.Indoors && !this.OtherEvent.enabled)
				{
					Debug.Log("Osana's ''make playlist'' event has begun.");
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location;
					this.Rival.CurrentDestination = this.Location;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 15;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[1];
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Rival.Distracted = true;
				this.Yoogle.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Rival.MoveTowardsTarget(this.Location.position);
			if (Quaternion.Angle(this.Rival.transform.rotation, this.Location.rotation) > 1f)
			{
				this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location.rotation, 10f * Time.deltaTime);
			}
			this.Timer += Time.deltaTime;
			if (Input.GetKeyDown("space"))
			{
				this.Timer += 60f;
			}
			if (this.Timer > 60f)
			{
				this.EndEvent();
			}
		}
		if (this.Rival.Alarmed || this.Clock.HourTime > 8f || this.Rival.Splashed || this.Rival.Dodging)
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

	// Token: 0x06001BB7 RID: 7095 RVA: 0x0013B89C File Offset: 0x00139A9C
	public void EndEvent()
	{
		Debug.Log("Osana's Friday before class event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Rival != null)
		{
			if (this.Rival.enabled && !this.Rival.Alarmed && !this.Rival.Splashed)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.DistanceToDestination = 100f;
				this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.SmartPhoneScreen.enabled = false;
			this.Rival.Ragdoll.Zs.SetActive(false);
			this.Rival.Obstacle.enabled = false;
			this.Rival.Prompt.enabled = true;
			this.Rival.Distracted = false;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			this.Yoogle.SetActive(false);
			this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
			this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
			this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x04002FA7 RID: 12199
	public OsanaFridayBeforeClassEvent2Script OtherEvent;

	// Token: 0x04002FA8 RID: 12200
	public StudentManagerScript StudentManager;

	// Token: 0x04002FA9 RID: 12201
	public JukeboxScript Jukebox;

	// Token: 0x04002FAA RID: 12202
	public UILabel EventSubtitle;

	// Token: 0x04002FAB RID: 12203
	public YandereScript Yandere;

	// Token: 0x04002FAC RID: 12204
	public ClockScript Clock;

	// Token: 0x04002FAD RID: 12205
	public StudentScript Rival;

	// Token: 0x04002FAE RID: 12206
	public Transform Location;

	// Token: 0x04002FAF RID: 12207
	public AudioClip[] SpeechClip;

	// Token: 0x04002FB0 RID: 12208
	public string[] SpeechText;

	// Token: 0x04002FB1 RID: 12209
	public string EventAnim;

	// Token: 0x04002FB2 RID: 12210
	public GameObject AlarmDisc;

	// Token: 0x04002FB3 RID: 12211
	public GameObject VoiceClip;

	// Token: 0x04002FB4 RID: 12212
	public GameObject Yoogle;

	// Token: 0x04002FB5 RID: 12213
	public float Distance;

	// Token: 0x04002FB6 RID: 12214
	public float Scale;

	// Token: 0x04002FB7 RID: 12215
	public float Timer;

	// Token: 0x04002FB8 RID: 12216
	public DayOfWeek EventDay;

	// Token: 0x04002FB9 RID: 12217
	public int RivalID = 11;

	// Token: 0x04002FBA RID: 12218
	public int Phase;

	// Token: 0x04002FBB RID: 12219
	public int Frame;

	// Token: 0x04002FBC RID: 12220
	public Vector3 OriginalPosition;

	// Token: 0x04002FBD RID: 12221
	public Vector3 OriginalRotation;
}
