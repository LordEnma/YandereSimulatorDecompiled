using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001D27 RID: 7463 RVA: 0x0015C56C File Offset: 0x0015A76C
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

	// Token: 0x06001D28 RID: 7464 RVA: 0x0015CB78 File Offset: 0x0015AD78
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

	// Token: 0x06001D29 RID: 7465 RVA: 0x0015CC34 File Offset: 0x0015AE34
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

	// Token: 0x040034EA RID: 13546
	public StruggleBarScript StruggleBar;

	// Token: 0x040034EB RID: 13547
	public StalkerYandereScript Yandere;

	// Token: 0x040034EC RID: 13548
	public StalkerPromptScript CatPrompt;

	// Token: 0x040034ED RID: 13549
	public GameObject KnockoutStars;

	// Token: 0x040034EE RID: 13550
	public GameObject Heartbroken;

	// Token: 0x040034EF RID: 13551
	public GameObject[] BonkEffect;

	// Token: 0x040034F0 RID: 13552
	public Transform StalkerDoor;

	// Token: 0x040034F1 RID: 13553
	public AudioClip CrunchSound;

	// Token: 0x040034F2 RID: 13554
	public Animation MyAnimation;

	// Token: 0x040034F3 RID: 13555
	public AudioSource Jukebox;

	// Token: 0x040034F4 RID: 13556
	public AudioSource MyAudio;

	// Token: 0x040034F5 RID: 13557
	public AudioClip StalkerKnockout;

	// Token: 0x040034F6 RID: 13558
	public AudioClip StalkerWon;

	// Token: 0x040034F7 RID: 13559
	public AudioClip Crunch;

	// Token: 0x040034F8 RID: 13560
	public UILabel Subtitle;

	// Token: 0x040034F9 RID: 13561
	public AudioClip[] AlarmedClip;

	// Token: 0x040034FA RID: 13562
	public string[] AlarmedText;

	// Token: 0x040034FB RID: 13563
	public float[] AlarmedTime;

	// Token: 0x040034FC RID: 13564
	public AudioClip[] SpeechClip;

	// Token: 0x040034FD RID: 13565
	public string[] SpeechText;

	// Token: 0x040034FE RID: 13566
	public float[] SpeechTime;

	// Token: 0x040034FF RID: 13567
	public Collider[] Boundary;

	// Token: 0x04003500 RID: 13568
	public float MinimumDistance;

	// Token: 0x04003501 RID: 13569
	public float Distance;

	// Token: 0x04003502 RID: 13570
	public float Scale;

	// Token: 0x04003503 RID: 13571
	public float Timer;

	// Token: 0x04003504 RID: 13572
	public bool PlayedAudio;

	// Token: 0x04003505 RID: 13573
	public bool Struggling;

	// Token: 0x04003506 RID: 13574
	public bool Alarmed;

	// Token: 0x04003507 RID: 13575
	public bool Started;

	// Token: 0x04003508 RID: 13576
	public bool Chase;

	// Token: 0x04003509 RID: 13577
	public int SpeechPhase;

	// Token: 0x0400350A RID: 13578
	public int Limit;
}
