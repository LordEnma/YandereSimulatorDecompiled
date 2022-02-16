using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001CF3 RID: 7411 RVA: 0x00158B5C File Offset: 0x00156D5C
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

	// Token: 0x06001CF4 RID: 7412 RVA: 0x00159168 File Offset: 0x00157368
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

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00159224 File Offset: 0x00157424
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

	// Token: 0x04003456 RID: 13398
	public StruggleBarScript StruggleBar;

	// Token: 0x04003457 RID: 13399
	public StalkerYandereScript Yandere;

	// Token: 0x04003458 RID: 13400
	public StalkerPromptScript CatPrompt;

	// Token: 0x04003459 RID: 13401
	public GameObject KnockoutStars;

	// Token: 0x0400345A RID: 13402
	public GameObject Heartbroken;

	// Token: 0x0400345B RID: 13403
	public GameObject[] BonkEffect;

	// Token: 0x0400345C RID: 13404
	public Transform StalkerDoor;

	// Token: 0x0400345D RID: 13405
	public AudioClip CrunchSound;

	// Token: 0x0400345E RID: 13406
	public Animation MyAnimation;

	// Token: 0x0400345F RID: 13407
	public AudioSource Jukebox;

	// Token: 0x04003460 RID: 13408
	public AudioSource MyAudio;

	// Token: 0x04003461 RID: 13409
	public AudioClip StalkerKnockout;

	// Token: 0x04003462 RID: 13410
	public AudioClip StalkerWon;

	// Token: 0x04003463 RID: 13411
	public AudioClip Crunch;

	// Token: 0x04003464 RID: 13412
	public UILabel Subtitle;

	// Token: 0x04003465 RID: 13413
	public AudioClip[] AlarmedClip;

	// Token: 0x04003466 RID: 13414
	public string[] AlarmedText;

	// Token: 0x04003467 RID: 13415
	public float[] AlarmedTime;

	// Token: 0x04003468 RID: 13416
	public AudioClip[] SpeechClip;

	// Token: 0x04003469 RID: 13417
	public string[] SpeechText;

	// Token: 0x0400346A RID: 13418
	public float[] SpeechTime;

	// Token: 0x0400346B RID: 13419
	public Collider[] Boundary;

	// Token: 0x0400346C RID: 13420
	public float MinimumDistance;

	// Token: 0x0400346D RID: 13421
	public float Distance;

	// Token: 0x0400346E RID: 13422
	public float Scale;

	// Token: 0x0400346F RID: 13423
	public float Timer;

	// Token: 0x04003470 RID: 13424
	public bool PlayedAudio;

	// Token: 0x04003471 RID: 13425
	public bool Struggling;

	// Token: 0x04003472 RID: 13426
	public bool Alarmed;

	// Token: 0x04003473 RID: 13427
	public bool Started;

	// Token: 0x04003474 RID: 13428
	public bool Chase;

	// Token: 0x04003475 RID: 13429
	public int SpeechPhase;

	// Token: 0x04003476 RID: 13430
	public int Limit;
}
