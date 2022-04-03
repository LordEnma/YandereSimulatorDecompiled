using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StalkerScript : MonoBehaviour
{
	// Token: 0x06001D15 RID: 7445 RVA: 0x0015B600 File Offset: 0x00159800
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

	// Token: 0x06001D16 RID: 7446 RVA: 0x0015BC0C File Offset: 0x00159E0C
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

	// Token: 0x06001D17 RID: 7447 RVA: 0x0015BCC8 File Offset: 0x00159EC8
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

	// Token: 0x040034CD RID: 13517
	public StruggleBarScript StruggleBar;

	// Token: 0x040034CE RID: 13518
	public StalkerYandereScript Yandere;

	// Token: 0x040034CF RID: 13519
	public StalkerPromptScript CatPrompt;

	// Token: 0x040034D0 RID: 13520
	public GameObject KnockoutStars;

	// Token: 0x040034D1 RID: 13521
	public GameObject Heartbroken;

	// Token: 0x040034D2 RID: 13522
	public GameObject[] BonkEffect;

	// Token: 0x040034D3 RID: 13523
	public Transform StalkerDoor;

	// Token: 0x040034D4 RID: 13524
	public AudioClip CrunchSound;

	// Token: 0x040034D5 RID: 13525
	public Animation MyAnimation;

	// Token: 0x040034D6 RID: 13526
	public AudioSource Jukebox;

	// Token: 0x040034D7 RID: 13527
	public AudioSource MyAudio;

	// Token: 0x040034D8 RID: 13528
	public AudioClip StalkerKnockout;

	// Token: 0x040034D9 RID: 13529
	public AudioClip StalkerWon;

	// Token: 0x040034DA RID: 13530
	public AudioClip Crunch;

	// Token: 0x040034DB RID: 13531
	public UILabel Subtitle;

	// Token: 0x040034DC RID: 13532
	public AudioClip[] AlarmedClip;

	// Token: 0x040034DD RID: 13533
	public string[] AlarmedText;

	// Token: 0x040034DE RID: 13534
	public float[] AlarmedTime;

	// Token: 0x040034DF RID: 13535
	public AudioClip[] SpeechClip;

	// Token: 0x040034E0 RID: 13536
	public string[] SpeechText;

	// Token: 0x040034E1 RID: 13537
	public float[] SpeechTime;

	// Token: 0x040034E2 RID: 13538
	public Collider[] Boundary;

	// Token: 0x040034E3 RID: 13539
	public float MinimumDistance;

	// Token: 0x040034E4 RID: 13540
	public float Distance;

	// Token: 0x040034E5 RID: 13541
	public float Scale;

	// Token: 0x040034E6 RID: 13542
	public float Timer;

	// Token: 0x040034E7 RID: 13543
	public bool PlayedAudio;

	// Token: 0x040034E8 RID: 13544
	public bool Struggling;

	// Token: 0x040034E9 RID: 13545
	public bool Alarmed;

	// Token: 0x040034EA RID: 13546
	public bool Started;

	// Token: 0x040034EB RID: 13547
	public bool Chase;

	// Token: 0x040034EC RID: 13548
	public int SpeechPhase;

	// Token: 0x040034ED RID: 13549
	public int Limit;
}
