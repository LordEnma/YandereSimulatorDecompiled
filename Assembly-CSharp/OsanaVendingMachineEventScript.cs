using System;
using UnityEngine;

// Token: 0x020003E5 RID: 997
public class OsanaVendingMachineEventScript : MonoBehaviour
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x001428FF File Offset: 0x00140AFF
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BCD RID: 7117 RVA: 0x00142924 File Offset: 0x00140B24
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
				if (this.Rival.enabled && this.Rival.SnackPhase == 1)
				{
					Debug.Log("Osana's vending machine event has begun.");
					AudioClipPlayer.Play(this.SpeechClip[0], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.EventSubtitle.text = this.SpeechText[0];
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location;
					this.Rival.CurrentDestination = this.Location;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.EatingSnack = false;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Rival.EmptyHands();
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.VoiceClip != null)
		{
			if (this.VoiceSource == null)
			{
				this.VoiceSource = this.VoiceClip.GetComponent<AudioSource>();
			}
			else
			{
				this.VoiceSource.pitch = Time.timeScale;
			}
		}
		if (this.Rival.DistanceToDestination < this.MinimumDistance)
		{
			this.Rival.MoveTowardsTarget(this.Location.position);
			if (Quaternion.Angle(this.Rival.transform.rotation, this.Location.rotation) > 1f)
			{
				this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location.rotation, 10f * Time.deltaTime);
			}
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
				AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[1];
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Rival.CharacterAnimation[this.EventAnim[1]].time >= this.Rival.CharacterAnimation[this.EventAnim[1]].length)
			{
				this.Rival.CharacterAnimation[this.EventAnim[2]].time = 7f;
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[2]);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[3];
				this.Rival.CharacterAnimation[this.EventAnim[3]].time = 7f;
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 0f;
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[4]);
				this.MinimumDistance = 1f;
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 1f;
				this.OsanaVandalismCollider.SetActive(true);
			}
			else
			{
				this.Location.position = Vector3.MoveTowards(this.Location.position, new Vector3(-2f, 4f, -31.7f), Time.deltaTime * 5f);
			}
			if (this.Rival.CharacterAnimation[this.EventAnim[4]].time > this.Rival.CharacterAnimation[this.EventAnim[4]].length)
			{
				this.Rival.CharacterAnimation[this.EventAnim[4]].time = 0f;
			}
			if (this.Timer > 5.5f)
			{
				this.Rival.CharacterAnimation[this.EventAnim[4]].speed = 0f;
				this.OsanaVandalismCollider.SetActive(false);
			}
			if (this.Timer > 6f)
			{
				AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[5];
				this.Rival.CharacterAnimation[this.EventAnim[5]].time = 0f;
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[5]);
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				this.EndEvent();
			}
		}
		if (this.Clock.Period > this.StartPeriod || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging)
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
			if (this.VoiceSource != null)
			{
				this.VoiceSource.volume = this.Scale;
			}
		}
		else
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			if (this.VoiceSource != null)
			{
				this.VoiceSource.volume = 0f;
			}
		}
		if (this.VoiceClip == null)
		{
			this.EventSubtitle.text = string.Empty;
		}
	}

	// Token: 0x06001BCE RID: 7118 RVA: 0x00143328 File Offset: 0x00141528
	private void EndEvent()
	{
		Debug.Log("Osana's vending machine event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
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
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.OsanaVandalismCollider.SetActive(false);
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x04003087 RID: 12423
	public StudentManagerScript StudentManager;

	// Token: 0x04003088 RID: 12424
	public JukeboxScript Jukebox;

	// Token: 0x04003089 RID: 12425
	public UILabel EventSubtitle;

	// Token: 0x0400308A RID: 12426
	public YandereScript Yandere;

	// Token: 0x0400308B RID: 12427
	public ClockScript Clock;

	// Token: 0x0400308C RID: 12428
	public StudentScript Rival;

	// Token: 0x0400308D RID: 12429
	public Transform Location;

	// Token: 0x0400308E RID: 12430
	public AudioSource VoiceSource;

	// Token: 0x0400308F RID: 12431
	public AudioSource MyAudio;

	// Token: 0x04003090 RID: 12432
	public AudioClip[] SpeechClip;

	// Token: 0x04003091 RID: 12433
	public AudioClip Bang;

	// Token: 0x04003092 RID: 12434
	public string[] SpeechText;

	// Token: 0x04003093 RID: 12435
	public string[] EventAnim;

	// Token: 0x04003094 RID: 12436
	public GameObject OsanaVandalismCollider;

	// Token: 0x04003095 RID: 12437
	public GameObject AlarmDisc;

	// Token: 0x04003096 RID: 12438
	public GameObject VoiceClip;

	// Token: 0x04003097 RID: 12439
	public float MinimumDistance = 0.5f;

	// Token: 0x04003098 RID: 12440
	public float Distance;

	// Token: 0x04003099 RID: 12441
	public float Scale;

	// Token: 0x0400309A RID: 12442
	public float Timer;

	// Token: 0x0400309B RID: 12443
	public DayOfWeek EventDay;

	// Token: 0x0400309C RID: 12444
	public int StartPeriod;

	// Token: 0x0400309D RID: 12445
	public int RivalID = 11;

	// Token: 0x0400309E RID: 12446
	public int Phase;

	// Token: 0x0400309F RID: 12447
	public int Frame;

	// Token: 0x040030A0 RID: 12448
	public bool PlaySound;
}
