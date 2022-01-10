using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001CE7 RID: 7399 RVA: 0x00156A34 File Offset: 0x00154C34
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

	// Token: 0x06001CE8 RID: 7400 RVA: 0x00157040 File Offset: 0x00155240
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

	// Token: 0x06001CE9 RID: 7401 RVA: 0x001570FC File Offset: 0x001552FC
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

	// Token: 0x04003441 RID: 13377
	public StruggleBarScript StruggleBar;

	// Token: 0x04003442 RID: 13378
	public StalkerYandereScript Yandere;

	// Token: 0x04003443 RID: 13379
	public StalkerPromptScript CatPrompt;

	// Token: 0x04003444 RID: 13380
	public GameObject KnockoutStars;

	// Token: 0x04003445 RID: 13381
	public GameObject Heartbroken;

	// Token: 0x04003446 RID: 13382
	public GameObject[] BonkEffect;

	// Token: 0x04003447 RID: 13383
	public Transform StalkerDoor;

	// Token: 0x04003448 RID: 13384
	public AudioClip CrunchSound;

	// Token: 0x04003449 RID: 13385
	public Animation MyAnimation;

	// Token: 0x0400344A RID: 13386
	public AudioSource Jukebox;

	// Token: 0x0400344B RID: 13387
	public AudioSource MyAudio;

	// Token: 0x0400344C RID: 13388
	public AudioClip StalkerKnockout;

	// Token: 0x0400344D RID: 13389
	public AudioClip StalkerWon;

	// Token: 0x0400344E RID: 13390
	public AudioClip Crunch;

	// Token: 0x0400344F RID: 13391
	public UILabel Subtitle;

	// Token: 0x04003450 RID: 13392
	public AudioClip[] AlarmedClip;

	// Token: 0x04003451 RID: 13393
	public string[] AlarmedText;

	// Token: 0x04003452 RID: 13394
	public float[] AlarmedTime;

	// Token: 0x04003453 RID: 13395
	public AudioClip[] SpeechClip;

	// Token: 0x04003454 RID: 13396
	public string[] SpeechText;

	// Token: 0x04003455 RID: 13397
	public float[] SpeechTime;

	// Token: 0x04003456 RID: 13398
	public Collider[] Boundary;

	// Token: 0x04003457 RID: 13399
	public float MinimumDistance;

	// Token: 0x04003458 RID: 13400
	public float Distance;

	// Token: 0x04003459 RID: 13401
	public float Scale;

	// Token: 0x0400345A RID: 13402
	public float Timer;

	// Token: 0x0400345B RID: 13403
	public bool PlayedAudio;

	// Token: 0x0400345C RID: 13404
	public bool Struggling;

	// Token: 0x0400345D RID: 13405
	public bool Alarmed;

	// Token: 0x0400345E RID: 13406
	public bool Started;

	// Token: 0x0400345F RID: 13407
	public bool Chase;

	// Token: 0x04003460 RID: 13408
	public int SpeechPhase;

	// Token: 0x04003461 RID: 13409
	public int Limit;
}
