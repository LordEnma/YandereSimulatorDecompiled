using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001CFE RID: 7422 RVA: 0x00159B8C File Offset: 0x00157D8C
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

	// Token: 0x06001CFF RID: 7423 RVA: 0x0015A198 File Offset: 0x00158398
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

	// Token: 0x06001D00 RID: 7424 RVA: 0x0015A254 File Offset: 0x00158454
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

	// Token: 0x0400347C RID: 13436
	public StruggleBarScript StruggleBar;

	// Token: 0x0400347D RID: 13437
	public StalkerYandereScript Yandere;

	// Token: 0x0400347E RID: 13438
	public StalkerPromptScript CatPrompt;

	// Token: 0x0400347F RID: 13439
	public GameObject KnockoutStars;

	// Token: 0x04003480 RID: 13440
	public GameObject Heartbroken;

	// Token: 0x04003481 RID: 13441
	public GameObject[] BonkEffect;

	// Token: 0x04003482 RID: 13442
	public Transform StalkerDoor;

	// Token: 0x04003483 RID: 13443
	public AudioClip CrunchSound;

	// Token: 0x04003484 RID: 13444
	public Animation MyAnimation;

	// Token: 0x04003485 RID: 13445
	public AudioSource Jukebox;

	// Token: 0x04003486 RID: 13446
	public AudioSource MyAudio;

	// Token: 0x04003487 RID: 13447
	public AudioClip StalkerKnockout;

	// Token: 0x04003488 RID: 13448
	public AudioClip StalkerWon;

	// Token: 0x04003489 RID: 13449
	public AudioClip Crunch;

	// Token: 0x0400348A RID: 13450
	public UILabel Subtitle;

	// Token: 0x0400348B RID: 13451
	public AudioClip[] AlarmedClip;

	// Token: 0x0400348C RID: 13452
	public string[] AlarmedText;

	// Token: 0x0400348D RID: 13453
	public float[] AlarmedTime;

	// Token: 0x0400348E RID: 13454
	public AudioClip[] SpeechClip;

	// Token: 0x0400348F RID: 13455
	public string[] SpeechText;

	// Token: 0x04003490 RID: 13456
	public float[] SpeechTime;

	// Token: 0x04003491 RID: 13457
	public Collider[] Boundary;

	// Token: 0x04003492 RID: 13458
	public float MinimumDistance;

	// Token: 0x04003493 RID: 13459
	public float Distance;

	// Token: 0x04003494 RID: 13460
	public float Scale;

	// Token: 0x04003495 RID: 13461
	public float Timer;

	// Token: 0x04003496 RID: 13462
	public bool PlayedAudio;

	// Token: 0x04003497 RID: 13463
	public bool Struggling;

	// Token: 0x04003498 RID: 13464
	public bool Alarmed;

	// Token: 0x04003499 RID: 13465
	public bool Started;

	// Token: 0x0400349A RID: 13466
	public bool Chase;

	// Token: 0x0400349B RID: 13467
	public int SpeechPhase;

	// Token: 0x0400349C RID: 13468
	public int Limit;
}
