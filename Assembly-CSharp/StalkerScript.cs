using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001CD6 RID: 7382 RVA: 0x001557C0 File Offset: 0x001539C0
	private void Update()
	{
		if (!this.Chase)
		{
			this.Distance = Vector3.Distance(this.Yandere.transform.position, base.transform.position);
			if (!this.Alarmed)
			{
				for (int i = 0; i < this.Boundary.Length; i++)
				{
					if (this.Boundary[i].bounds.Contains(this.Yandere.transform.position))
					{
						AudioSource.PlayClipAtPoint(this.CrunchSound, Camera.main.transform.position);
						this.TriggerAlarm();
					}
				}
				if (this.Distance < 0.5f)
				{
					this.TriggerAlarm();
				}
			}
			else
			{
				base.transform.LookAt(this.Yandere.transform.position);
				if (this.Limit == 10 && Vector3.Distance(this.Yandere.transform.position, this.StalkerDoor.position) < 1f)
				{
					this.ChaseNow();
				}
			}
			if (this.Distance >= this.MinimumDistance)
			{
				this.Subtitle.text = "";
				return;
			}
			if (!this.Started)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					this.Subtitle.text = this.SpeechText[0];
					this.MyAudio.clip = this.SpeechClip[0];
					this.MyAudio.Play();
					this.Started = true;
					this.SpeechPhase++;
					return;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				if (!this.Alarmed)
				{
					if (this.SpeechPhase < this.SpeechTime.Length && !this.MyAudio.isPlaying)
					{
						this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
						this.MyAudio.Play();
						this.Subtitle.text = this.SpeechText[this.SpeechPhase];
						this.SpeechPhase++;
					}
				}
				else if (this.SpeechPhase < this.Limit && !this.MyAudio.isPlaying)
				{
					this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
					this.MyAudio.Play();
					this.Subtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
					if (this.Limit == 10 && this.SpeechPhase == this.Limit)
					{
						this.ChaseNow();
					}
				}
				if (this.MyAudio.isPlaying)
				{
					this.Jukebox.volume = 0.1f;
					return;
				}
				this.Jukebox.volume = 1f;
				return;
			}
		}
		else if (!this.Struggling)
		{
			base.transform.LookAt(this.Yandere.transform.position);
			base.transform.Translate(base.transform.forward * Time.deltaTime * 5f, Space.World);
			this.MyAnimation.CrossFade("newSprint_00");
			if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
			{
				this.MyAnimation.CrossFade("struggleB_00");
				this.Yandere.BeginStruggle();
				this.Struggling = true;
				this.StruggleBar.gameObject.SetActive(true);
				this.StruggleBar.Struggling = true;
				this.Subtitle.text = "";
				return;
			}
		}
		else
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.transform.position + this.Yandere.transform.forward * 0.5f, Time.deltaTime * 10f);
			base.transform.rotation = this.Yandere.transform.rotation;
			if (!this.StruggleBar.Struggling)
			{
				if (this.StruggleBar.Yandere.Won)
				{
					if (!this.PlayedAudio)
					{
						AudioSource.PlayClipAtPoint(this.StalkerKnockout, this.Yandere.MainCamera.transform.position);
						this.PlayedAudio = true;
					}
					this.Yandere.MyAnimation.CrossFade("f02_struggleWinA_00");
					this.MyAnimation.CrossFade("struggleWinB_00");
					if (this.MyAnimation["struggleWinB_00"].time >= 0.66666f)
					{
						this.BonkEffect[1].SetActive(true);
					}
					if (this.MyAnimation["struggleWinB_00"].time >= 1.33333f)
					{
						this.KnockoutStars.SetActive(true);
						this.BonkEffect[2].SetActive(true);
					}
					if (this.MyAnimation["struggleWinB_00"].time >= this.MyAnimation["struggleWinB_00"].length)
					{
						this.CatPrompt.BeginCarryingCat();
						this.Yandere.CanMove = true;
						base.enabled = false;
						return;
					}
				}
				else
				{
					if (!this.PlayedAudio)
					{
						AudioSource.PlayClipAtPoint(this.StalkerWon, this.Yandere.MainCamera.transform.position);
						this.PlayedAudio = true;
						this.Jukebox.Stop();
					}
					this.Yandere.MyAnimation.CrossFade("f02_struggleLoseA_00");
					this.MyAnimation.CrossFade("struggleLoseB_00");
					if (this.MyAnimation["struggleLoseB_00"].time >= this.MyAnimation["struggleLoseB_00"].length)
					{
						this.Heartbroken.SetActive(true);
						base.enabled = false;
					}
				}
			}
		}
	}

	// Token: 0x06001CD7 RID: 7383 RVA: 0x00155DCC File Offset: 0x00153FCC
	private void ChaseNow()
	{
		this.SpeechClip = this.AlarmedClip;
		this.SpeechText = this.AlarmedText;
		this.SpeechTime = this.AlarmedTime;
		this.SpeechPhase = 9;
		this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
		this.MyAudio.Play();
		this.Subtitle.text = this.SpeechText[this.SpeechPhase];
		this.SpeechPhase++;
		this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
		this.Yandere.CanMove = false;
		this.Yandere.Chased = true;
		this.Chase = true;
	}

	// Token: 0x06001CD8 RID: 7384 RVA: 0x00155E88 File Offset: 0x00154088
	private void TriggerAlarm()
	{
		this.MyAnimation.CrossFade("readyToFight_00");
		this.SpeechClip = this.AlarmedClip;
		this.SpeechText = this.AlarmedText;
		this.SpeechTime = this.AlarmedTime;
		this.Subtitle.text = "";
		this.Started = false;
		this.Alarmed = true;
		this.SpeechPhase = 0;
		this.Timer = 0f;
		this.MyAudio.Stop();
	}

	// Token: 0x04003408 RID: 13320
	public StruggleBarScript StruggleBar;

	// Token: 0x04003409 RID: 13321
	public StalkerYandereScript Yandere;

	// Token: 0x0400340A RID: 13322
	public StalkerPromptScript CatPrompt;

	// Token: 0x0400340B RID: 13323
	public GameObject KnockoutStars;

	// Token: 0x0400340C RID: 13324
	public GameObject Heartbroken;

	// Token: 0x0400340D RID: 13325
	public GameObject[] BonkEffect;

	// Token: 0x0400340E RID: 13326
	public Transform StalkerDoor;

	// Token: 0x0400340F RID: 13327
	public AudioClip CrunchSound;

	// Token: 0x04003410 RID: 13328
	public Animation MyAnimation;

	// Token: 0x04003411 RID: 13329
	public AudioSource Jukebox;

	// Token: 0x04003412 RID: 13330
	public AudioSource MyAudio;

	// Token: 0x04003413 RID: 13331
	public AudioClip StalkerKnockout;

	// Token: 0x04003414 RID: 13332
	public AudioClip StalkerWon;

	// Token: 0x04003415 RID: 13333
	public AudioClip Crunch;

	// Token: 0x04003416 RID: 13334
	public UILabel Subtitle;

	// Token: 0x04003417 RID: 13335
	public AudioClip[] AlarmedClip;

	// Token: 0x04003418 RID: 13336
	public string[] AlarmedText;

	// Token: 0x04003419 RID: 13337
	public float[] AlarmedTime;

	// Token: 0x0400341A RID: 13338
	public AudioClip[] SpeechClip;

	// Token: 0x0400341B RID: 13339
	public string[] SpeechText;

	// Token: 0x0400341C RID: 13340
	public float[] SpeechTime;

	// Token: 0x0400341D RID: 13341
	public Collider[] Boundary;

	// Token: 0x0400341E RID: 13342
	public float MinimumDistance;

	// Token: 0x0400341F RID: 13343
	public float Distance;

	// Token: 0x04003420 RID: 13344
	public float Scale;

	// Token: 0x04003421 RID: 13345
	public float Timer;

	// Token: 0x04003422 RID: 13346
	public bool PlayedAudio;

	// Token: 0x04003423 RID: 13347
	public bool Struggling;

	// Token: 0x04003424 RID: 13348
	public bool Alarmed;

	// Token: 0x04003425 RID: 13349
	public bool Started;

	// Token: 0x04003426 RID: 13350
	public bool Chase;

	// Token: 0x04003427 RID: 13351
	public int SpeechPhase;

	// Token: 0x04003428 RID: 13352
	public int Limit;
}
