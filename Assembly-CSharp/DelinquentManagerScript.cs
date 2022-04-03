using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x06001369 RID: 4969 RVA: 0x000B1997 File Offset: 0x000AFB97
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x0600136A RID: 4970 RVA: 0x000B19CC File Offset: 0x000AFBCC
	private void Update()
	{
		this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
		if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, this.Attacker.AggroClips.Length)];
			component.Play();
			this.Aggro = true;
		}
		if (this.Panel.activeInHierarchy && this.Clock.HourTime > this.NextTime[this.Phase])
		{
			if (this.Phase == 3 && this.Clock.HourTime > 7.25f)
			{
				this.TimerMax = 75f;
				this.Timer = 75f;
				this.Phase++;
			}
			else if (this.Phase == 5 && this.Clock.HourTime > 8.5f)
			{
				this.TimerMax = 285f;
				this.Timer = 285f;
				this.Phase++;
			}
			else if (this.Phase == 7 && this.Clock.HourTime > 13.25f)
			{
				this.TimerMax = 15f;
				this.Timer = 15f;
				this.Phase++;
			}
			else if (this.Phase == 9 && this.Clock.HourTime > 13.5f)
			{
				this.TimerMax = 135f;
				this.Timer = 135f;
				this.Phase++;
			}
			if (this.Attacker == null)
			{
				this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
			}
			this.Circle.fillAmount = 1f - this.Timer / this.TimerMax;
			if (this.Timer <= 0f)
			{
				this.Delinquents.SetActive(!this.Delinquents.activeInHierarchy);
				if (this.Phase < 8)
				{
					this.Phase++;
					return;
				}
				this.Delinquents.SetActive(false);
				this.Panel.SetActive(false);
			}
		}
	}

	// Token: 0x0600136B RID: 4971 RVA: 0x000B1C44 File Offset: 0x000AFE44
	public void CheckTime()
	{
		if (this.Clock.HourTime < 13f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 6;
			return;
		}
		if (this.Clock.HourTime < 15.5f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 8;
		}
	}

	// Token: 0x0600136C RID: 4972 RVA: 0x000B1CC8 File Offset: 0x000AFEC8
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C5D RID: 7261
	public GameObject Delinquents;

	// Token: 0x04001C5E RID: 7262
	public GameObject RapBeat;

	// Token: 0x04001C5F RID: 7263
	public GameObject Panel;

	// Token: 0x04001C60 RID: 7264
	public float[] NextTime;

	// Token: 0x04001C61 RID: 7265
	public DelinquentScript Attacker;

	// Token: 0x04001C62 RID: 7266
	public MirrorScript Mirror;

	// Token: 0x04001C63 RID: 7267
	public UILabel TimeLabel;

	// Token: 0x04001C64 RID: 7268
	public ClockScript Clock;

	// Token: 0x04001C65 RID: 7269
	public UISprite Circle;

	// Token: 0x04001C66 RID: 7270
	public float SpeechTimer;

	// Token: 0x04001C67 RID: 7271
	public float TimerMax;

	// Token: 0x04001C68 RID: 7272
	public float Timer;

	// Token: 0x04001C69 RID: 7273
	public bool Aggro;

	// Token: 0x04001C6A RID: 7274
	public int Phase = 1;
}
